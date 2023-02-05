using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sigesp.Infra.Data.Context;
using Sigesp.WebUI.Extensions;
using Sigesp.Domain.Models;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.WebUI.Controllers;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Sigesp.Domain.Enums;
using Sigesp.WebUI.Helpers;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Infra.Data.Extensions.DataTable;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Sigesp.Application.ViewModels.Cards;

namespace Sigesp.WebUI.EndPoints
{
    [Route("api/edis")]
    [ApiController]
    public class EdisEndPoint : ApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDetentoAppService _detentoManager;
        private readonly IEdiRepository _ediRepository;
        private readonly IEdiLogRepository _ediLogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWord;
        private readonly SigespDbContext _context;
        private readonly IColaboradorPontoRepository _colaboradorPontoRepository;
        private readonly IColaboradorPontoApontamentoRepository _colaboradorPontoApontamentoRepository;
        private readonly IColaboradorAppService _colaboradorAppService;
        private readonly IEmpresaConvenioAppService _empresaConvenioAppService;
        private readonly IDetentoRepository _detentoRepository;
        private readonly IAlunoEjaRepository _alunoEjaRepository;
        private readonly IAlunoEjaAppService _alunoEjaManager;
        public readonly IDetentoSaidaTemporariaRepository _detentoSTRepository;
        private readonly IAndamentoPenalRepository _apRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly IEdiAppService _ediManager;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoLeitorRepository _alunoLeitorRepository;

        public EdisEndPoint(IWebHostEnvironment webHostEnvironment,
                            IDetentoAppService detentoManager,
                            IEdiRepository ediRepository,
                            IEdiLogRepository ediLogRepository,
                            IMapper mapper,
                            IUnitOfWork unitOfWord,
                            SigespDbContext context,
                            IColaboradorPontoRepository colaboradorPontoRepository,
                            IColaboradorPontoApontamentoRepository colaboradorPontoApontamentoRepository,
                            IColaboradorAppService colaboradorAppService,
                            IEmpresaConvenioAppService empresaConvenioAppService,
                            IDetentoRepository detentoRepository,
                            IAlunoEjaRepository alunoEjaRepository,
                            IAlunoEjaAppService alunoEjaManager,
                            IDetentoSaidaTemporariaRepository detentoSTRepository,
                            IAndamentoPenalRepository apRepository,
                            ILivroRepository livroRepository,
                            ITenantRepository tenantRepository,
                            IMemoryCache memoryCache,
                            IEdiAppService ediManager,
                            IAlunoLeitorRepository alunoLeitorRepository,
                            IColaboradorRepository colaboradorRepository,
                            IAlunoRepository alunoRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _detentoManager = detentoManager;
            _ediRepository = ediRepository;
            _ediLogRepository = ediLogRepository;
            _mapper = mapper;
            _unitOfWord =  unitOfWord;
            _context = context;
            _colaboradorPontoRepository = colaboradorPontoRepository;
            _colaboradorPontoApontamentoRepository = colaboradorPontoApontamentoRepository;
            _colaboradorAppService = colaboradorAppService;
            _colaboradorRepository = colaboradorRepository;
            _empresaConvenioAppService = empresaConvenioAppService;
            _detentoRepository = detentoRepository;
            _alunoEjaRepository = alunoEjaRepository;
            _alunoEjaManager = alunoEjaManager;
            _detentoSTRepository = detentoSTRepository;
            _apRepository = apRepository;
            _livroRepository = livroRepository;
            _tenantRepository = tenantRepository;
            _memoryCache = memoryCache;
            _ediManager = ediManager;
            _alunoLeitorRepository = alunoLeitorRepository;
            _alunoRepository = alunoRepository;
        }

        #region Métodos multitenants
        [HttpGet]
        [Route("get-info-cards")]
        public async Task<IActionResult> GetInfoCards()
        {
            try
            {
                var ediCardViewModel = new EdiCardViewModel();
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());

                if (tenantId != null && tenantId != Guid.Empty)
                {
                    var cacheKey = "Edi - GetInfoCards | TenantId: " + tenantId;
                    var json = _memoryCache.Get(cacheKey);
                    if(json != null)
                    {
                        var edisSerializer = JsonSerializer.Deserialize<EdiCardViewModel>(json.ToString());
                        ediCardViewModel = edisSerializer;
                    }
                    else {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(5));

                        ediCardViewModel = await _ediManager.GetInfoCardsAsync();
                        json = JsonSerializer.Serialize<EdiCardViewModel>(ediCardViewModel);
                        _memoryCache.Set(cacheKey, json, cacheEntryOptions);
                    }
                }
                else
                {
                    ediCardViewModel = await _ediManager.GetInfoCardsAsync();
                }

                return CustomResponse(ediCardViewModel);
            }
            catch { throw; }
        }
        
        /// 
        /// Resumo: 
        ///     Este método ingressa NOVOS, INATIVA e ATUALIZA informações de DETENTOS ATIVOS
        ///     Dados atualizados - GALERIA, CELA E REGIME SAÍDA TEMPORÁRIA
        /// 
        /// Parâmentros:
        ///     Uma coleção de DETENTOS em formato XLS ou XLSX
        /// 
        /// Devoluções:
        ///     Uma tarefa processada assincronamente
        [HttpPost]
        [Route("import-detentos-xls")]
        public async Task<IActionResult> PostImportacaoDetentosXlsAsync(IFormCollection form)
        {
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                var detentosVM = new List<DetentoViewModel>();
                string folderName = "Uploads";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                #region RESOLVE tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                if (tenantId == null || tenantId == Guid.Empty)
                {
                    return CustomResponse("Problemas para resolver a tenância. Tente novamente, caso o problema persista informe a equipe técnica do sistema.");
                }
                #endregion

                var edi = new Edi();

                #region LEITURA e VALIDAÇÕES diversas do arquivo importado - Depois crio uma lista dos registros constantes neste arquivo
                if (file != null)
                {
                    string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                    string fullPath = System.IO.Path.Combine(newPath, file.FileName);
                    
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    
                    //Crio um registro EDI com as informações de importação
                    edi.TenantId = (Guid) tenantId;
                    edi.ArquivoNome = file.FileName;
                    edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                    edi.Status = EdiStatusEnum.PROCESSANDO;
                    edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                    _ediRepository.Add(edi);
                    _unitOfWord.Commit();

                    using(fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                        {
                            if (!reader.MergeCells.IsNullOrEmpty() && reader.MergeCells.Count() > 0)
                            {
                                AbortEdiImportacao(edi.Id, (Guid)tenantId, "Importação abortada! </br>Arquivo possui células mescladas. Padrão não aceito para este tipo de importação.");
                            }

                            while (reader.Read())
                            {
                                if (reader.GetValue(0) != null &&
                                    reader.GetValue(1) != null &&
                                    reader.GetValue(4) != null &&
                                    reader.GetValue(8) != null &&
                                    reader.GetValue(2) != null)
                                {
                                    var tmp = new DetentoViewModel()
                                    {
                                        Ipen = reader.GetValue(0).ToString(),
                                        Nome = StringHelpers.RemoverAcentuacao(reader.GetValue(1).ToString()),
                                        Galeria = reader.GetValue(4).ToString(),
                                        Cela = reader.GetValue(8).ToString(),
                                        Regime = reader.GetValue(2).ToString()
                                    };
                                    
                                    detentosVM.Add(tmp);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ATUALIZAÇÃO dados de GALERIA, CELA e quando necessário REGIME SAÍDA TEMPORÁRIA
                var detentosDM = _detentoManager.GetAll();
                var hasChange = false;

                if (detentosDM == null || detentosDM.Count() <= 0)
                {
                    AbortEdiImportacao(edi.Id, (Guid)tenantId, "Importação abortada! </br>Nenhum DETENTO encontrado em sua UNIDADE para prosseguir com o processamento do EDI.");
                }

                foreach (var detentoDM in detentosDM.ToList())
                {
                    hasChange = false;
                    var detentoFind = detentosVM
                                        .Where(x => x.Ipen == detentoDM.Ipen)
                                        .FirstOrDefault();

                    if (detentoFind != null)
                    {
                        //Continua preso, verificar necessidade de atualização dos dados
                        if (!detentoFind.Nome.Equals(detentoDM.Nome))
                        {
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Nome";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Nome;
                            ediLogViewModel.EntityPropertyNewValue = detentoFind.Nome;
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi

                            detentoDM.Nome = detentoFind.Nome.ToUpper();
                            hasChange = true;
                        }

                        if (!detentoDM.Galeria.Equals(detentoFind.Galeria))
                        {
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Galeria";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Galeria;
                            ediLogViewModel.EntityPropertyNewValue = detentoFind.Galeria;
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi

                            detentoDM.Galeria = detentoFind.Galeria.ToUpper();
                            hasChange = true;
                        }

                        if (!detentoDM.Cela.Equals(detentoFind.Cela))
                        {
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Cela";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Cela;
                            ediLogViewModel.EntityPropertyNewValue = detentoFind.Cela;
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi

                            detentoDM.Cela = detentoFind.Cela;
                            hasChange = true;
                        }

                        /// ATUALIZA para REGIME SAÍDA TEMPORÁRIA
                        if (detentoFind.Regime.Equals("SAÍDA TEMPORÁRIA") && 
                            !detentoDM.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()))
                        {
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Regime";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Regime;
                            ediLogViewModel.EntityPropertyNewValue = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi

                            detentoDM.Regime = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                            detentoDM.IsSaidaTemporaria = true;
                            hasChange = true;
                        }

                        /// RETIRA do REGIME SAÍDA TEMPORÁRIA
                        if (!detentoFind.Regime.Equals("SAÍDA TEMPORÁRIA") &&
                            detentoDM.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()))
                        {
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Regime";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Regime;
                            ediLogViewModel.EntityPropertyNewValue = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi

                            detentoDM.Regime = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                            detentoDM.IsSaidaTemporaria = false;
                            hasChange = true;
                        }

                        if (hasChange)
                        {
                            _detentoManager.Update(detentoDM);                            
                        }

                        var indexForRemove = detentosVM.FindIndex(x => x.Ipen == detentoFind.Ipen);
                        if (indexForRemove != -1)
                            detentosVM.RemoveAt(indexForRemove);
                    }
                    else
                    {
                        /// O DETENTO iterado, não foi localizado no arquivo processado
                        /// portanto, vou inativá-lo por considerar que já foi embora

                        ///  Registro de LOG
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Ipen e Nome";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Ipen + "-" + detentoDM.Nome;
                        ediLogViewModel.Tipo = EdiLogTipoEnum.EXCLUSAO.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);

                        /// Inativação do DETENTO iterado
                        detentoDM.IsDeleted = true;
                        detentoDM.Regime = DetentoRegimeEnum.EGRESSO_EDI.ToString();
                        _detentoManager.Update(detentoDM);

                        /// Atualização das diversas entidades vinculadas ao DETENTO iterado
                        #region Disable childrens entities 

                        if (detentoDM != null && detentoDM.Ipen != null)
                        {
                            var ipenMapped = Convert.ToInt32(detentoDM.Ipen);
                            if (ipenMapped != 0)
                            {
                                #region Colaborador
                                var colaborador = new Colaborador();
                                try
                                {
                                    colaborador = await _colaboradorRepository
                                                            .GetAsync(ipenMapped);
                                    if (colaborador != null)
                                    {
                                        colaborador.IsDeleted = true;
                                        colaborador.Situacao = ColaboradorSituacaoEnum.DEMITIDO;
                                        colaborador.DemissaoOcorrencia = ColaboradorDemissaoOcorrenciaEnum.DEMISSAO_VIA_SISTEMA;
                                        colaborador.DemissaoObservacao = "Houve o egresso do DETENTO via EDI, o que por sua vez, gerou a inativação do colaborador automaticamente.";
                                        colaborador.DemissaoData = DateTime.Now;

                                        _colaboradorRepository.Update(colaborador);

                                        /// create log
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Atualização Colaborador";
                                        ediLogViewModel.EntityProperty = detentoDM.Ipen + " - " + detentoDM.Nome;
                                        ediLogViewModel.EntityPropertyOldValue = "INATIVADO";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                    
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                }
                                catch { throw; }
                                #endregion

                                #region Aluno
                                var aluno = new Aluno();
                                try
                                {
                                    aluno = await _alunoRepository
                                                            .GetAsync(ipenMapped);
                                    if (aluno != null)
                                    {
                                        aluno.IsDeleted = true;
                                        _alunoRepository.Update(aluno);

                                        /// create log
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Atualização Aluno";
                                        ediLogViewModel.EntityProperty = detentoDM.Ipen + "-" + detentoDM.Nome;
                                        ediLogViewModel.EntityPropertyOldValue = "INATIVADO";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                    
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                }
                                catch { throw; }
                                #endregion

                                #region AlunoEja
                                var alunoEja = new AlunoEja();
                                try
                                {
                                    alunoEja = await _alunoEjaRepository
                                                            .GetAsync(ipenMapped);
                                    if (alunoEja != null)
                                    {
                                        alunoEja.IsDeleted = true;
                                        alunoEja.EjaOcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.EGRESSO;
                                        alunoEja.DataOcorrenciaDesistencia = DateTime.Now;
                                        alunoEja.FaseStatus = AlunoEjaFaseStatusEnum.NAO_CONCLUIDA;

                                        /// update disciplinas
                                        foreach (var alunoEjaDisciplina in alunoEja.AlunoEjaDisciplinas)
                                        {
                                            alunoEjaDisciplina.Conceito = AlunoEjaDisciplinaConceitoEnum.REPROVADO;
                                        }

                                        _alunoEjaRepository.Update(alunoEja);

                                        /// create log
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Atualização AlunoEja";
                                        ediLogViewModel.EntityProperty = detentoDM.Ipen + "-" + detentoDM.Nome;
                                        ediLogViewModel.EntityPropertyOldValue = "INATIVADO";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                    
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                }
                                catch { throw; }
                                #endregion

                                #region AlunoLeitor
                                var alunoLeitor = new AlunoLeitor();
                                try
                                {
                                    alunoLeitor = await _alunoLeitorRepository
                                                            .GetAsync(ipenMapped);
                                    if (alunoLeitor != null)
                                    {
                                        alunoLeitor.IsDeleted = true;
                                        alunoLeitor.OcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.EGRESSO;
                                        alunoLeitor.DataOcorrenciaDesistencia = DateTime.Now;

                                        _alunoLeitorRepository.Update(alunoLeitor);

                                        /// create log
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Atualização AlunoLeitor";
                                        ediLogViewModel.EntityProperty = detentoDM.Ipen + "-" + detentoDM.Nome;
                                        ediLogViewModel.EntityPropertyOldValue = "INATIVADO";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                    
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                }
                                catch { throw; }
                                #endregion
                            }
                            else
                            {
                                /// create log
                                ediLogViewModel.EdiId = edi.Id.ToString();
                                ediLogViewModel.EntityName = "Objetos filhos não foram atualizados, uma vez que não foi possível efetuar o mapeamento do IPEN. Informe o erro para equipe técnica do sistema.";
                                ediLogViewModel.EntityProperty = detentoDM.Ipen + "-" + detentoDM.Nome;
                                ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                            
                                EdiLogAddExtensions(ediLogViewModel);
                            }
                        }

                        #endregion
                    }
                }
                #endregion

                #region INGRESSO ou REINGRESSO de DETENTO
                if (detentosVM.Count > 0)
                {
                    var dtAIFull = await _detentoManager
                                            .GetAIFullAsync();

                    foreach (var detentoVM in detentosVM.ToList())
                    { 
                        var ediLogViewModel = new EdiLogViewModel();                   
                        var detentoFind = dtAIFull
                                            .FirstOrDefault(x => x.Ipen == detentoVM.Ipen);

                        if (detentoFind == null)
                        {
                            detentoVM.TenantId = tenantId;
                            detentoVM.Nome = detentoVM.Nome;

                            if (detentoVM.Regime.Equals("SAÍDA TEMPORÁRIA"))
                            {
                                detentoVM.Regime = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                                detentoVM.IsSaidaTemporaria = true;
                            }
                            else
                            {
                                detentoVM.Regime = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                            }

                            await _detentoManager.AddAsync(detentoVM);

                            //Begin - Criação de log para o edi
                            ediLogViewModel.TenantId = (Guid)tenantId;
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Ipen e Nome";
                            ediLogViewModel.EntityPropertyNewValue = detentoVM.Ipen + "-" + detentoVM.Nome;
                            ediLogViewModel.Tipo = EdiLogTipoEnum.INCLUSAO.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);
                            //End - Criação de log para o edi
                        }
                        else
                        {
                            if (detentoFind.IsDeleted)
                            {
                                var detentoForUpdate = await _detentoRepository
                                                                .GetInativoAsync(Int32.Parse(detentoVM.Ipen));
                                if (detentoForUpdate != null)
                                {
                                    detentoForUpdate.IsDeleted = false;
                                    detentoForUpdate.TenantId = (Guid)tenantId;
                                    detentoForUpdate.Nome = detentoVM.Nome.ToUpper();

                                    if (detentoVM.Regime.Equals("SAÍDA TEMPORÁRIA"))
                                    {
                                        detentoForUpdate.Regime = DetentoRegimeEnum.SAIDA_TEMPORARIA;
                                        detentoForUpdate.IsSaidaTemporaria = true;
                                    }
                                    else
                                    {
                                        detentoForUpdate.Regime = DetentoRegimeEnum.RECOLHIDO_EDI;
                                    }
                                    
                                    _detentoRepository.Update(detentoForUpdate);
                                    
                                    //Begin - Criação de log para o edi
                                    ediLogViewModel.TenantId = (Guid)tenantId;
                                    ediLogViewModel.EdiId = edi.Id.ToString();
                                    ediLogViewModel.EntityName = "Detento";
                                    ediLogViewModel.EntityProperty = "Ipen e Nome";
                                    ediLogViewModel.EntityPropertyNewValue = detentoVM.Ipen + " - " + detentoVM.Nome;
                                    ediLogViewModel.Tipo = EdiLogTipoEnum.INCLUSAO.ToString();
                                    
                                    EdiLogAddExtensions(ediLogViewModel);
                                    //End - Criação de log para o edi
                                }
                                else
                                {
                                    //Begin - Criação de log para o edi
                                    ediLogViewModel.TenantId = (Guid)tenantId;
                                    ediLogViewModel.EdiId = edi.Id.ToString();
                                    ediLogViewModel.EntityName = "Detento";
                                    ediLogViewModel.EntityProperty = "Ipen e Nome";
                                    ediLogViewModel.EntityPropertyOldValue = "Problemas ao obter o registro do DETENTO para incluí-lo nesta UNIDADE. Tente novamente, caso o problema persista, inclua este DETENTO manualmente via cadastro de DETENTOS.";
                                    ediLogViewModel.EntityPropertyNewValue = detentoVM.Ipen + "-" + detentoVM.Nome;
                                    ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                    
                                    EdiLogAddExtensions(ediLogViewModel);
                                }                                
                            }
                            else
                            {
                                var tenantNome = await _tenantRepository.GetNomeAsync((Guid) detentoFind.TenantId);
                                var tenantNomeChecked = string.IsNullOrEmpty(tenantNome) ? "'PROBLEMAS AO OBTER A UNIDADE, informe a equipe técnica do sistema'" : tenantNome;

                                //Begin - Criação de log para o edi
                                ediLogViewModel.TenantId = (Guid)tenantId;
                                ediLogViewModel.EdiId = edi.Id.ToString();
                                ediLogViewModel.EntityName = "Detento";
                                ediLogViewModel.EntityProperty = detentoVM.Ipen + "-" + detentoVM.Nome;
                                ediLogViewModel.EntityPropertyNewValue = "Detento não importado! O mesmo, está ativo na UNIDADE <span class='fw-900'><i>" +tenantNomeChecked.ToUpper()+"</i></span>. Solicite a UNIDADE que efetue a saída deste DETENTO, e tente novamente o seu ingresso via EDI, ou manualmente em DETENTOS.";
                                ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                
                                EdiLogAddExtensions(ediLogViewModel);
                                //End - Criação de log para o edi
                            }                            
                        }
                    }
                }
                #endregion

                //Caso tenha chego até aqui
                //atualizo o Edi com sucesso, para portanto, efetuar o
                //commit para salvar todas as mudanças
                var ediUpdate = _ediRepository.GetById(edi.Id);
                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;
                
                _unitOfWord.Commit();
                
                return Ok(new {
                    Data = edi,
                    Success = true
                });
            }
            catch { throw; }
        }

        [HttpPost]
        [Route("detento-update-regime")]
        public async Task<IActionResult> PostDetentoUpdateRegimeAsync(IFormCollection form)
        {
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                List<DetentoViewModel> detentosVM = new List<DetentoViewModel>();
                string folderName = "Uploads/DetentoUpdateRegime";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                #region RESOLVE tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                if (tenantId == null || tenantId == Guid.Empty)
                {
                    throw new Exception("Problemas para resolver a tenância. Tente novamente, caso o problema persista informe a equipe técnica do sistema.");
                }
                #endregion

                #region LEITURA e VALIDAÇÕES diversas do arquivo importado - Depois crio uma lista dos registros constantes neste arquivo
                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                while (reader.Read())
                                {
                                    var ipen = "";
                                    var nome = "";
                                    DetentoRegimeEnum regime = new DetentoRegimeEnum();

                                    //Em caso de prisão civil o regime é alimentos
                                    if (reader.GetValue(0) != null)
                                    {
                                        if (reader.GetValue(0).Equals("PRISÃO CIVIL"))
                                        {
                                            reader.Read();

                                            if (reader.GetValue(0) != null
                                                && reader.GetValue(1) != null
                                                && !reader.GetValue(1).ToString().Contains("ALBERGUE")
                                                && !reader.GetValue(1).ToString().Contains("LIVRAMENTO")
                                                && !reader.GetValue(1).ToString().Contains("ALVARÁ")
                                                && !reader.GetValue(1).ToString().Contains("DIREITO")
                                                && !reader.GetValue(1).ToString().Contains("EVASÃO")
                                                && !reader.GetValue(1).ToString().Contains("FUGA")
                                                && !reader.GetValue(1).ToString().Contains("DOMICILIAR")
                                                && !reader.GetValue(1).ToString().Contains("CONDICIONAL")
                                                && !reader.GetValue(1).ToString().Contains("TRANSFERÊNCIA")
                                                && !reader.GetValue(1).ToString().Contains("DIVERGÊNCIA")
                                                && !reader.GetValue(1).ToString().Contains("SERVIÇOS")
                                                && NumericHelpers.HasNumber(reader.GetValue(0).ToString()))
                                            {
                                                ipen = Helpers.StringHelpers.ExtractDetentoIpen(reader.GetValue(0).ToString());
                                                nome = Helpers.StringHelpers.ExtractDetentoNome(reader.GetValue(0).ToString());
                                                regime = DetentoRegimeEnum.ALIMENTOS;
                                            }
                                        }
                                        else
                                        {
                                            if (reader.GetValue(0) != null
                                                && reader.GetValue(2) != null
                                                && !reader.GetValue(0).Equals("PRONTUÁRIO | NOME")
                                                && !reader.GetValue(2).ToString().Contains("ALBERGUE")
                                                && !reader.GetValue(2).ToString().Contains("LIVRAMENTO")
                                                && !reader.GetValue(2).ToString().Contains("ALVARÁ")
                                                && !reader.GetValue(2).ToString().Contains("DIREITO")
                                                && !reader.GetValue(2).ToString().Contains("EVASÃO")
                                                && !reader.GetValue(2).ToString().Contains("FUGA")
                                                && !reader.GetValue(2).ToString().Contains("DOMICILIAR")
                                                && !reader.GetValue(2).ToString().Contains("CONDICIONAL")
                                                && !reader.GetValue(2).ToString().Contains("TRANSFERÊNCIA")
                                                && !reader.GetValue(2).ToString().Contains("DIVERGÊNCIA")
                                                && !reader.GetValue(2).ToString().Contains("SERVIÇOS")
                                                && NumericHelpers.HasNumber(reader.GetValue(0).ToString()))
                                            {
                                                ipen = Helpers.StringHelpers.ExtractDetentoIpen(reader.GetValue(0).ToString());
                                                nome = Helpers.StringHelpers.ExtractDetentoNome(reader.GetValue(0).ToString());
                                                regime = Helpers.EdiHelpers.GetDetentoRegimeEnumByRegime(reader.GetValue(2).ToString().Trim());

                                                //Faz uma busca dos textos (EXECUÇÃO SUSPENSA E INCIDENTE DISCIPLINAR)
                                                //afim de identificar tais regimes, visto que, ao localizar, 
                                                //deverá excluir todos os registros de datas de saída temporária do detento
                                                var rgme = reader.GetValue(2).ToString().Trim();

                                                if (rgme.Contains("EXECUÇÃO SUSPENSA") ||
                                                    rgme.Contains("INCIDENTE DISCIPLINAR"))
                                                {
                                                    //Agora excluo as datas de saída temporária do detento
                                                    var detentosDatasST = _detentoSTRepository
                                                                            .GetAllByDetentoIpen(Convert.ToInt32(ipen));
                                                    if (detentosDatasST != null &&
                                                        detentosDatasST.Count() > 0)
                                                    {
                                                        foreach (var item in detentosDatasST)
                                                        {
                                                            _detentoSTRepository.Remove(item.Id);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (!ipen.IsNullOrEmpty() && !regime.Equals(0))
                                        {
                                            detentosVM.Add(new DetentoViewModel
                                            {
                                                Ipen = ipen,
                                                Nome = nome,
                                                Regime = regime.ToString()
                                            });
                                        }
                                    }                                    
                                }
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                #endregion

                //Crio um registro EDI com as informações de importação
                var edi = new Edi();
                edi.TenantId = (Guid) tenantId;
                edi.ArquivoNome = file.FileName;
                edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                edi.Status = EdiStatusEnum.PROCESSANDO;
                _ediRepository.Add(edi);
                _unitOfWord.Commit();

                //Obtenho todos os detentos ativos
                var detentosDM = _detentoManager.GetAll();
                var hasChange = false;

                //Inicío a atualização dos dados dos recolhidos
                foreach (var detentoDM in detentosDM.ToList())
                {
                    hasChange = false;
                    var detentoFind = detentosVM
                                        .Where(x => x.Ipen == detentoDM.Ipen)
                                        .FirstOrDefault();

                    if (detentoFind != null)
                    {
                        //Continua preso, verificar necessidade de atualização dos dados
                        if (!detentoFind.Regime.Equals(detentoDM.Regime))
                        {                           
                            //Begin - Criação de log para o edi
                            var ediLogViewModel = new EdiLogViewModel();
                            ediLogViewModel.EdiId = edi.Id.ToString();
                            ediLogViewModel.EntityName = "Detento";
                            ediLogViewModel.EntityProperty = "Regime";
                            ediLogViewModel.EntityPropertyOldValue = detentoDM.Regime;
                            ediLogViewModel.EntityPropertyNewValue = detentoFind.Regime;
                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                            
                            EdiLogAddExtensions(ediLogViewModel);

                            if (detentoFind.Regime.Equals(DetentoRegimeEnum.PROVISORIO))
                            {
                                //Begin - Criação de log para o edi
                                ediLogViewModel.EdiId = edi.Id.ToString();
                                ediLogViewModel.EntityName = "Detento";
                                ediLogViewModel.EntityProperty = "IsProvisorio";
                                ediLogViewModel.EntityPropertyOldValue = detentoDM.IsProvisorio.ToString();
                                ediLogViewModel.EntityPropertyNewValue = "true";
                                ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                
                                EdiLogAddExtensions(ediLogViewModel);

                                detentoDM.IsProvisorio = true;
                            }
                            else
                            {
                                ediLogViewModel.EdiId = edi.Id.ToString();
                                ediLogViewModel.EntityName = "Detento";
                                ediLogViewModel.EntityProperty = "IsProvisorio";
                                ediLogViewModel.EntityPropertyOldValue = detentoDM.IsProvisorio.ToString();
                                ediLogViewModel.EntityPropertyNewValue = "false";
                                ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                
                                EdiLogAddExtensions(ediLogViewModel);

                                detentoDM.IsProvisorio = false;
                            }
                            //End - Criação de log para o edi

                            detentoDM.Regime = detentoFind.Regime;
                            hasChange = true;
                        }

                        if (hasChange)
                        {
                            _detentoManager.Update(detentoDM);
                        }
                    }
                }
                //End code for update data and regime change

                //Caso tenha chego até aqui
                //atualizo o Edi com sucesso, para portanto, efetuar o
                //commit salvando todas as modificações no banco
                var ediUpdate = _ediRepository.GetById(edi.Id);
                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;
                
                _unitOfWord.Commit();
                
                return Ok(new {
                    Data = edi,
                    Success = true
                });
            }
            catch { throw; }
        }
        
        [HttpPost]
        [Route("lista")]
        public async Task<IActionResult> Lista([FromForm] DataTableServerSideRequest request)
        {
            try
            {
                var result = await _ediManager
                                    .GetWithDataTableResultAsync(request);
                return Ok(new {
                    data = result.Data,
                    Draw = result.Draw,
                    RecordsFiltered  = result._iRecordsDisplay,
                    RecordsTotal = result._iRecordsTotal,
                    Success = true
                });    
            }
            catch { throw; }
        }
        #endregion Métodos multitenants

        #region Métodos not multitenants
        
        #endregion Métodos not multitenants

        #region Métodos pendentes para implementar tenancy
        [HttpPost]
        [Route("detento-update-st")]
        public IActionResult PostDetentoUpdateST(IFormCollection form)
        {           
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                List<DetentoViewModel> detentosVM = new List<DetentoViewModel>();
                string folderName = "Uploads/DetentoUpdateRegime";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                //Crio um registro EDI com as informações de importação
                                var edi = new Edi();
                                edi.ArquivoNome = file.FileName;
                                edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                                edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                                edi.Status = EdiStatusEnum.PROCESSANDO;
                                _ediRepository.Add(edi);
                                _unitOfWord.Commit();

                                DataSet result = reader.AsDataSet();

                                if (result == null)
                                    AbortEdiImportacao(edi.Id, "Importação abortada!"+
                                                               "</br>Problemas na leitura do arquivo!"+
                                                               "Gere um novo arquivo e tente novamente."+
                                                               "</br>Persistindo o problema, informe a equipe técnica do sistema.");

                                DataTable dt = result.Tables[0];

                                if (dt == null)
                                    AbortEdiImportacao(edi.Id, "Importação abortada!"+
                                                               "</br>Arquivo não possui uma planilha ativa em seu interior!"+
                                                               "Gere um novo arquivo e tente novamente."+
                                                               "</br>Persistindo o problema, informe a equipe técnica do sistema.");

                                #region Remoção de todos os registros anteriores
                                var detentosST = _detentoSTRepository
                                                    .GetAll();
                                _detentoSTRepository.RemoveAll(detentosST);
                                #endregion Remoção de todos os registros anteriores

                                //Exception fora de intervalo
                                //System.IndexOutOfRangeException
                                var rows = dt.Rows.Count;
                                for (var i = 1; i < rows; i++)
                                {
                                    int ipen = 0; 

                                    var tmpSTPrevista = new DateTime();
                                    var tmpoSTRetornoPrevisto = new DateTime();
                                    var ediLogViewModel = new EdiLogViewModel();

                                    #region Begin - Obtenho o IPEN
                                    if (!(dt.Rows[i][0] is DBNull)
                                        && NumericHelpers.HasNumber(dt.Rows[i][0].ToString().Trim()))
                                    {
                                        try {
                                            ipen = Convert
                                                    .ToInt32(StringHelpers
                                                    .ExtractDetentoIpen(dt.Rows[i][0].ToString().Trim()));
                                        } catch { throw; }
                                    } else
                                    {
                                        var ix = 0;
                                        while ((dt.Rows[i - ix][0] is DBNull))
                                        {
                                            ix++;

                                            if (!(dt.Rows[i - ix][0] is DBNull))
                                            {
                                                try {
                                                    ipen = Convert
                                                        .ToInt32(StringHelpers
                                                        .ExtractDetentoIpen(dt.Rows[i - ix][0].ToString().Trim()));
                                                    break;
                                                } catch { throw; }
                                            }
                                        }
                                    }

                                    //Verifica se o ipen é válido
                                    if (ipen != 0
                                        && !_detentoManager.IsAlreadyByIpen(ipen))
                                    {
                                        //Registrar logs
                                        //Begin - Criação de log para o edi                                        
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Detento";
                                        ediLogViewModel.EntityPropertyNewValue = "Nenhum detento encontrado para atualizar data prevista para saída e retorno de saída temporária com o IPEN " + ipen + " informado no arquivo de importação.";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                        
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                    #endregion End - Obtenho o IPEN

                                    #region Begin - Obtenção das datas (One to One)
                                    String tmpSTPrevistaTemp;
                                    String tmpoSTRetornoPrevistoTemp;
                                    if (!(dt.Rows[i][1] is DBNull) &&
                                        !(dt.Rows[i][3] is DBNull) &&
                                        DateHelpers
                                                .IsDateStringValid(dt.Rows[i][1].ToString()) &&
                                        DateHelpers
                                                .IsDateStringValid(dt.Rows[i][3].ToString()))
                                    {
                                        tmpSTPrevistaTemp = dt.Rows[i][1].ToString().Substring(0, 10);
                                        tmpoSTRetornoPrevistoTemp = dt.Rows[i][3].ToString().Substring(0, 10);

                                        #region Convert for date
                                        if (!string.IsNullOrEmpty(tmpSTPrevistaTemp)) tmpSTPrevista = Convert.ToDateTime(tmpSTPrevistaTemp);
                                        if (!string.IsNullOrEmpty(tmpoSTRetornoPrevistoTemp)) tmpoSTRetornoPrevisto = Convert.ToDateTime(tmpoSTRetornoPrevistoTemp);
                                        #endregion
                                    }
                                    #endregion End

                                    #region Begin - Atualização dos dados do DETENTO
                                    if (ipen != 0)
                                    {
                                        var detentoId = _detentoRepository
                                                            .GetIdByIpen(ipen);
                                        if (detentoId == null ||
                                             detentoId == Guid.Empty)
                                        {
                                            ediLogViewModel.EdiId = edi.Id.ToString();
                                            ediLogViewModel.EntityName = "Detento";
                                            ediLogViewModel.EntityProperty = "Detento com o IPEN número "+ipen+" não encontrado para atualizar os dados de saída temporária.";
                                            ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                            
                                            EdiLogAddExtensions(ediLogViewModel);
                                        }
                                        else
                                        {
                                            //Antes de adicionar, verificar se há registro para o Id e excluir todos
                                            // var detentosST = _detentoSTRepository
                                            //                     .GetAllByDetentoIpen(ipen);
                                            
                                            // if (detentosST != null)
                                            // {
                                            //     _detentoSTRepository.RemoveAll(detentosST);
                                            // }
                                            
                                            RegistraLog.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "DetentoSaidaTemporaria");
                                            RegistraLog.Log("Registro de log de auditoria detento id ==> " + detentoId + "");
                                            
                                            var detentoST = new DetentoSaidaTemporaria();
                                            detentoST.DetentoId = (Guid) detentoId;
                                            detentoST.SaidaPrevista = tmpSTPrevista;
                                            detentoST.RetornoPrevisto = tmpoSTRetornoPrevisto;

                                            _detentoSTRepository.Add(detentoST);

                                            //Registrar logs
                                            //Begin - Criação de log para o edi                                        
                                            ediLogViewModel.EdiId = edi.Id.ToString();
                                            ediLogViewModel.EntityName = "Detento";
                                            ediLogViewModel.EntityProperty = "STPrevista e STRetornoPrevisto";                                        
                                            ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                            
                                            EdiLogAddExtensions(ediLogViewModel);

                                            detentoId = new Guid();
                                        }
                                    }                                    
                                    #endregion Begin - Atualização dos dados do DETENTO  
                                }

                                // Caso tenha chego até aqui 
                                // atualizo o Edi com sucesso, para portanto, efetuar o
                                // commit salvando todas as modificações no banco    
                                var ediUpdate = _ediRepository.GetById(edi.Id);
                                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;

                                _unitOfWord.Commit();
                            }
                        }
                    } catch { throw; }
                }
            } catch { throw; }

            return Ok(new {
                Data = "",
                Result = true
            });
        }
        
        [HttpPost]
        [Route("ap-endereco-telefone-st")]
        public IActionResult PostApEnderecoTelefoneST(IFormCollection form)
        {           
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                List<DetentoViewModel> detentosVM = new List<DetentoViewModel>();
                string folderName = "Uploads/AndamentoPenalEnderecoTelefoneSaidaTemporaria";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                //Crio um registro EDI com as informações de importação
                                var edi = new Edi();
                                edi.ArquivoNome = file.FileName;
                                edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                                edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                                edi.Status = EdiStatusEnum.PROCESSANDO;
                                _ediRepository.Add(edi);
                                _unitOfWord.Commit();

                                DataSet result = reader.AsDataSet();
                                DataTable dt = result.Tables[0];

                                Regex enderecoPattern = new Regex(@"\[D](.*)");
                                Regex ipenPattern = new Regex(@"^[0-9]{6}\s");
                                
                                Regex celularPattern = new Regex(@"(.*)[Celular]:");
                                Regex residencialPattern = new Regex(@"(.*)[Residencial]:");
                                Regex paraContatoPattern = new Regex(@"(.*)[Para Contato]:");
                                Regex comercialPattern = new Regex(@"(.*)[Comercial]:");
                                
                                var regexes = new List<Regex>();
                                regexes.Add(celularPattern);
                                regexes.Add(residencialPattern);
                                regexes.Add(paraContatoPattern);
                                regexes.Add(comercialPattern);

                                var rows = dt.Rows.Count;
                                for (var i = 1; i < rows; i++)
                                {
                                    var ipen = 0;
                                    var endereco = "";
                                    var telefone = "";
                                    var ediLogViewModel = new EdiLogViewModel();

                                    #region Begin - Obtenho o IPEN
                                    if (!(dt.Rows[i][0] is DBNull)
                                        && ipenPattern.IsMatch(dt.Rows[i][0].ToString()))
                                    {   
                                        try {
                                            ipen = Convert
                                                    .ToInt32(ipenPattern.Match(dt.Rows[i][0].ToString()).Value.Trim());
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }

                                    //Verifica se o ipen é válido
                                    if (ipen != 0
                                        && !_detentoManager.IsAlreadyByIpen(ipen))
                                    {

                                        //Registrar logs
                                        //Begin - Criação de log para o edi                                        
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Detento";
                                        ediLogViewModel.EntityPropertyNewValue = "Nenhum detento encontrado para atualizar data prevista para saída e retorno de saída temporária com o IPEN " + ipen + " informado no arquivo de importação.";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                        
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                    #endregion End - Obtenho o IPEN

                                    #region Begin - Obtenho o ENDEREÇO e TELEFONE
                                    if (ipen != 0
                                        && ipen.ToString().Count() == 6)
                                    {
                                        while ((dt.Rows[i + 1][0] is DBNull))
                                        {
                                            i++;
                                        }

                                        if (!(dt.Rows[i + 1][0] is DBNull)
                                            && enderecoPattern.IsMatch(dt.Rows[i + 1][0].ToString()))
                                        {
                                            try {
                                                var enderecoMath = enderecoPattern.Match(dt.Rows[i + 1][0].ToString()).Value.Trim();
                                                endereco = enderecoMath.Replace("[D]", "").Trim();
                                            } catch { throw; }

                                            try {
                                                var telefoneMath = enderecoPattern.Match(dt.Rows[i + 1][1].ToString()).Value.Trim();
                                                telefone = telefoneMath.Replace("[D]", "").Trim();

                                                RegistraLog.Log("Registro de log de EDI Endereço/Telefone ==> " + ipen + ": "+ endereco + " | " + telefone);
                                            } catch { throw; }
                                        }
                                    }
                                    #endregion End - Obtenho o ENDEREÇO e TELEFONE

                                    #region Begin - Persistência dos dados                                    
                                    if (ipen == 0)
                                    {
                                        continue;
                                    }
                                    
                                    var andamentoPenalForUpdate = new AndamentoPenal();
                                    andamentoPenalForUpdate = _apRepository
                                                                    .GetByDetentoIpen(ipen);
                                    
                                    if (andamentoPenalForUpdate == null ||
                                         andamentoPenalForUpdate.Id == null || 
                                         andamentoPenalForUpdate.Id == Guid.Empty)
                                    {
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "AndamentoPenal";
                                        ediLogViewModel.EntityProperty = "Não foi encontrado registro no andamento penal para atualização de endereço com o IPEN número "+ipen+" informado.";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                        
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }
                                    else
                                    {
                                        // RegistraLog.Log(String.Format($"{"Log criado em "} : {DateTime.Now}"), "AndamentoPenal_EDI_Atualização_Endereço");
                                        RegistraLog.Log("Registro de log de auditoria ==> IPEN: " + ipen + " | " + endereco + " | " + telefone);
                                        
                                        andamentoPenalForUpdate.EnderecoCompleto = endereco;

                                        foreach (var tmp in regexes)
                                        {
                                            switch (tmp.Match(telefone).Value)
                                            {
                                                case "Celular:":
                                                    andamentoPenalForUpdate.Telefone = telefone.Replace("Celular", "Telefone");
                                                    break;
                                                case "Residencial:":
                                                    andamentoPenalForUpdate.Telefone = telefone.Replace("Residencial", "Telefone");
                                                    break;
                                                case "Para Contato:":
                                                    andamentoPenalForUpdate.Telefone = telefone.Replace("Para Contato", "Telefone");
                                                    break;
                                                case "Comercial:":
                                                    andamentoPenalForUpdate.Telefone = telefone.Replace("Para Contato", "Telefone");
                                                    break;
                                                default:
                                                    if (telefone.IsNullOrEmpty())
                                                        andamentoPenalForUpdate.Telefone = "NÃO POSSUI TELEFONE";
                                                    break;
                                            }
                                        }

                                        _apRepository.Update(andamentoPenalForUpdate);

                                        //Registrar logs
                                        //Begin - Criação de log para o edi
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "AndamentoPenal";
                                        ediLogViewModel.EntityProperty = "EnderecoCompleto e Telefone";
                                        ediLogViewModel.EntityPropertyOldValue = "Atualização de endereço e telefone";
                                        ediLogViewModel.EntityPropertyNewValue = "IPEN: " + ipen + " | " + endereco + " | " + andamentoPenalForUpdate.Telefone;
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                                        
                                        EdiLogAddExtensions(ediLogViewModel);

                                        andamentoPenalForUpdate = null;
                                    }
                                    #endregion End - Persistência dos dados
                                }

                                // Caso tenha chego até aqui 
                                // atualizo o Edi com sucesso, para portanto, efetuar o
                                // commit salvando todas as modificações no banco    
                                var ediUpdate = _ediRepository.GetById(edi.Id);
                                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;

                                _unitOfWord.Commit();
                            }
                        }
                    } catch { throw; }
                }
            } catch { throw; }

            return Ok(new {
                Data = "",
                Result = true
            });
        }

        [HttpPost]
        [Route("importacao-livros")]
        public IActionResult PostImportacaoLivros(IFormCollection form)
        {           
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                string folderName = "Uploads/ImportacaoLivros";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                //Crio um registro EDI com as informações de importação
                                var edi = new Edi();
                                edi.ArquivoNome = file.FileName;
                                edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                                edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                                edi.Status = EdiStatusEnum.PROCESSANDO;
                                _ediRepository.Add(edi);
                                _unitOfWord.Commit();

                                DataSet result = reader.AsDataSet();
                                DataTable dt = result.Tables[0];

                                var rows = dt.Rows.Count;
                                for (var i = 1; i < rows; i++)
                                {
                                    var ediLogViewModel = new EdiLogViewModel();
                                    var livro = new Livro();

                                    #region Begin - Obtenho um ID
                                    try {
                                        livro.Id = Guid.NewGuid();
                                        // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                    } catch { throw; }
                                    #endregion End - Obtenho o TÍTULO LIVRO

                                    #region Begin - Obtenho o TÍTULO LIVRO
                                    if (!(dt.Rows[i][0] is DBNull))
                                    {   
                                        try {
                                            livro.Titulo = dt.Rows[i][0].ToString().Trim();
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho o TÍTULO LIVRO

                                    #region Begin - Obtenho a LOCALIZAÇÃO
                                    if (!(dt.Rows[i][1] is DBNull))
                                    {
                                        try {
                                            livro.Localizacao = Convert
                                                                    .ToInt32(dt.Rows[i][1].ToString().Trim());
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho a LOCALIZAÇÃO

                                    #region Begin - Obtenho a PROPRIEDADE
                                    if (!(dt.Rows[i][2] is DBNull))
                                    {
                                        try {
                                            livro.Propriedade = dt.Rows[i][2].ToString().Trim();
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho a PROPRIEDADE

                                    #region Begin - Obtenho a IsDisponivel
                                    if (!(dt.Rows[i][3] is DBNull))
                                    {
                                        try {
                                            livro.IsDisponivel = dt.Rows[i][3].ToString().Trim() == "1" ? true : false;
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho a IsDisponivel

                                    #region Begin - Obtenho a LivroAutorId
                                    if (!(dt.Rows[i][4] is DBNull))
                                    {
                                        try {
                                            livro.LivroAutorId = Guid.Parse(dt.Rows[i][4].ToString().Trim());
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho a LivroAutorId

                                    #region Begin - Obtenho a LivroGeneroId
                                    if (!(dt.Rows[i][5] is DBNull))
                                    {
                                        try {
                                            livro.LivroGeneroId = Guid.Parse(dt.Rows[i][5].ToString().Trim());
                                            // RegistraLog.Log("Registro de log de auditoria ipen número ==> " + ipen + "");
                                        } catch { throw; }
                                    }
                                    #endregion End - Obtenho a LivroGeneroId

                                    #region Begin - Validações antes do mapeamento e persistência dos dados
                                    if (livro.LivroAutorId == null ||
                                        livro.LivroAutorId == Guid.Empty ||
                                        livro.LivroGeneroId == null ||
                                        livro.LivroGeneroId == Guid.Empty)
                                    {
                                        ediLogViewModel.EdiId = edi.Id.ToString();
                                        ediLogViewModel.EntityName = "Edi - Importação Livros";
                                        ediLogViewModel.EntityProperty = "Livro título " + livro.Titulo + " não importado. LivroAutorId ou LivroGeneroId não informado (s)";
                                        ediLogViewModel.Tipo = EdiLogTipoEnum.INCONSISTENCIA.ToString();
                                        
                                        EdiLogAddExtensions(ediLogViewModel);
                                    }

                                    _livroRepository.Add(livro);
                                    RegistraLog.Log("Registro de log de auditoria de inserção de livro ==> TÍTULO INSERIDO: " + livro.Titulo + "");

                                    //Registrar logs
                                    //Begin - Criação de log para o edi
                                    ediLogViewModel.EdiId = edi.Id.ToString();
                                    ediLogViewModel.EntityName = "Edi - Importação livros";
                                    ediLogViewModel.EntityProperty = "Livros";
                                    ediLogViewModel.EntityPropertyOldValue = "Título: " + livro.Titulo;
                                    ediLogViewModel.Tipo = EdiLogTipoEnum.INCLUSAO.ToString();
                                        
                                    EdiLogAddExtensions(ediLogViewModel);
                                    _unitOfWord.Commit();
                                    #endregion Begin - Validações antes do mapeamento e persistência dos dados
                                }

                                // Caso tenha chego até aqui 
                                // atualizo o Edi com sucesso, para portanto, efetuar o
                                // commit salvando todas as modificações no banco    
                                var ediUpdate = _ediRepository.GetById(edi.Id);
                                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;

                                _unitOfWord.Commit();
                            }
                        }
                    } catch { throw; }
                }
            } catch { throw; }

            return Ok(new {
                Data = "",
                Result = true
            });
        }

        [HttpPost]
        [Route("colaborador-import-ponto")]
        public IActionResult PostColaboradorImportPonto(IFormCollection form)
        {
            try
            {
                // Task<int> taskA = Task.Run(() => Processfile(form));
                IFormFile file = form.Files[0];
                FileStream fileStream;
                List<DetentoViewModel> detentosVM = new List<DetentoViewModel>();
                string folderName = "Uploads/DetentoUpdateRegime";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                // Crio um registro EDI com as informações de importação
                                var edi = new Edi();
                                edi.ArquivoNome = file.FileName;
                                edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
                                edi.FullPath = System.IO.Path.Combine(newPath, file.FileName);
                                edi.Status = EdiStatusEnum.PROCESSANDO;
                                _ediRepository.Add(edi);
                                _unitOfWord.Commit();

                                //Validações arquivo
                                //Padrão de colunas: 33 colunas fixas com dados
                                if (reader.FieldCount > 33)
                                    AbortEdiImportacao(edi.Id, "Arquivo excede o total de colunas (com dados) permitidas. </br>Número máximo de colunas com dados é de 33.");

                                //Variáveis globais com dados do header do arquivo
                                //CNPJ convenio
                                //Data inicio e fim
                                //Mês referencia
                                //Ano referência
                                //Tota dias do mês referência
                                string cnpj = "";
                                DateTime dataInicio = new DateTime();
                                DateTime dataFim = new DateTime();    
                                int mesReferencia = 0;
                                int anoReferencia = 0;
                                int diasMes = 0;

                                while (reader.Read())
                                {
                                    try
                                    {
                                        //Extrair CNPJ
                                        if (reader.GetValue(0) != null)
                                            if (reader.GetValue(0).ToString().Contains("CNPJ"))
                                                if (reader.GetValue(1) != null)
                                                {
                                                    if (reader.GetValue(1).ToString().Trim().Length == 14)
                                                    {
                                                        cnpj = reader.GetValue(1).ToString().Trim().Substring(0, 14);
                                                    }
                                                    else
                                                    {
                                                        AbortEdiImportacao(edi.Id, "CNPJ inválido! Campo CNPJ deve conter 14 caracteres numéricos.");
                                                    }
                                                }
                                                else
                                                {
                                                    AbortEdiImportacao(edi.Id, "CNPJ vazio! Campo CNPJ deve conter 14 caracteres numéricos, compondo um CNPJ válido.");
                                                }

                                        //Extrair data inicio e fim do período
                                        if (reader.GetValue(0) != null
                                            && reader.GetValue(0).ToString().Equals("Período datas:")
                                            && reader.GetValue(1) != null)
                                        {
                                            if (DateHelpers.IsDateStringValid(reader.GetValue(1).ToString().Trim().Substring(0, 10))
                                                && DateHelpers.IsDateStringValid(reader.GetValue(1).ToString().Trim().Substring(13, 10)))
                                            {
                                                dataInicio = Convert.ToDateTime(reader.GetValue(1).ToString().Trim().Substring(0, 10));
                                                dataFim = Convert.ToDateTime(reader.GetValue(1).ToString().Trim().Substring(13, 10));

                                                mesReferencia = dataInicio.Month;
                                                anoReferencia = dataInicio.Year;
                                                diasMes = System.DateTime.DaysInMonth(anoReferencia, mesReferencia);
                                            }
                                            else
                                            {
                                                AbortEdiImportacao(edi.Id, "<strong>Período datas</strong> fora do padrão aceito. </br>Favor ajustar para o padrão correto: 01/01/0001 a 01/01/0001");
                                            }
                                                        
                                            
                                            //Validação data - Data início não pode ser maior que data final
                                            if (dataInicio.Date > dataFim.Date)
                                                AbortEdiImportacao(edi.Id, "<strong>Período datas</strong> possui data início maior que data final.'");
                                        }

                                        //Início dos apontamentos a partir da extração do ipen
                                        //obtenção de um colaborador e seu convênio
                                        if (reader.GetValue(0) != null
                                            && NumericHelpers.HasNumber(reader.GetValue(0).ToString()))
                                        {
                                            if (reader.GetValue(0).ToString().Length == 6)
                                            {
                                                int ipen = 0;
                                                var colaborador = new ColaboradorViewModel();

                                                ipen = Convert.ToInt32(reader.GetValue(0).ToString().Trim());
                                                
                                                //Validar ipen
                                                if (!_detentoManager.IsAlreadyByIpen(ipen))
                                                {
                                                    AbortEdiImportacao(edi.Id, "Importação abortada! </br>Nenhum colaborador localizado para apontamento de ponto com o ipen " + ipen + " infomado.");
                                                }
                                                else
                                                {
                                                    //Iniciar os apontamentos
                                                    //Obter empresa convênio com o cnpj informado
                                                    var empresaConvenio = _empresaConvenioAppService.GetByEmpresaCnpj(cnpj);

                                                    if (empresaConvenio == null)
                                                        AbortEdiImportacao(edi.Id, "Importação abortada! </br>Não foi possível obter um convênio com o CNPJ informado no arquivo de importação.");

                                                    colaborador = _colaboradorAppService.GetByDetentoIpenAndEmpresaConvenioId(ipen, empresaConvenio.Id.ToString());
                                                    if (colaborador == null)
                                                    {
                                                        AbortEdiImportacao(edi.Id, "Importação abortada! </br>Colaborador com o ipen número " + ipen + " não cadastrado ou há nenhum colaborador admitido no convênio com o CNPJ informado no arquivo de importação.");
                                                    }
                                                    else
                                                    {
                                                        //Verifica se ja há ponto registrado
                                                        //para o mesmo período e o mesmo convênio
                                                        if (_colaboradorPontoRepository.IsAlreadyDataInicioDataFimEmpresaConvenio(dataInicio,
                                                                                                                                  dataFim,
                                                                                                                                  (Guid) empresaConvenio.Id))
                                                            AbortEdiImportacao(edi.Id, "Importação abortada! </br>Já há um registro de ponto para o CNPJ e Período datas informados no arquivo.");
                                                        
                                                        var colaboradorPonto = new ColaboradorPonto
                                                        {
                                                            ColaboradorId = (Guid) colaborador.Id,
                                                            PeriodoReferencia = mesReferencia.ToString(),
                                                            PeriodoDataInicio = dataInicio,
                                                            PeriodoDataFim = dataFim,
                                                            EdiId = edi.Id,
                                                            EmpresaConvenioId = colaborador.EmpresaConvenioId
                                                        };
                                                        
                                                        _colaboradorPontoRepository.Add(colaboradorPonto);

                                                        var colaboradorPontApontamentos = new ColaboradorPontoApontamento();
                                                        ColaboradorPontoApontamentoEnum cpae = new ColaboradorPontoApontamentoEnum();
                                                        
                                                        //Loop de apontamentos
                                                        var dateDay = dataInicio.Day;
                                                        for (var i = 2; i < reader.FieldCount; i++)
                                                        {
                                                            if (reader.GetValue(i) != null)
                                                            {
                                                                try {
                                                                    cpae = _mapper.Map<ColaboradorPontoApontamentoEnum>(reader.GetValue(i).ToString());
                                                                } catch { AbortEdiImportacao(edi.Id, "Importação abortada! </br>Apontamento na linha " + (reader.Depth + 1) + ", está fora do padrão reconhecido! Verifique a tabela com as siglas corretas e informe um apontamento válido."); }

                                                                DateTime dataApontamento = new DateTime();
                                                                try {
                                                                    dataApontamento = new DateTime(anoReferencia, mesReferencia, dateDay);
                                                                } catch { AbortEdiImportacao(edi.Id, "Importação abortada! Problemas ao obter uma data de apontamento. Tente novamente a importação"); }

                                                                var cpa = new ColaboradorPontoApontamento
                                                                {
                                                                    ColaboradorPontoId = colaboradorPonto.Id,
                                                                    Data = dataApontamento,
                                                                    Tipo = cpae
                                                                };

                                                                dateDay++;
                                                                _colaboradorPontoApontamentoRepository.Add(cpa);
                                                                
                                                                //Begin - Criação de log para o edi
                                                                var ediLogViewModel = new EdiLogViewModel();
                                                                ediLogViewModel.EdiId = edi.Id.ToString();
                                                                ediLogViewModel.EntityName = "ColaboradorPontoApontamento";
                                                                ediLogViewModel.EntityProperty = "Tipo";
                                                                ediLogViewModel.EntityPropertyOldValue = cpa.Data.ToString();
                                                                ediLogViewModel.EntityPropertyNewValue = cpae.ToString();
                                                                ediLogViewModel.Tipo = EdiLogTipoEnum.INCLUSAO.ToString();
                                                                
                                                                EdiLogAddExtensions(ediLogViewModel);
                                                            }
                                                        }

                                                         

                                                    }                                                           
                                                }
                                            }
                                            else
                                            {
                                                AbortEdiImportacao(edi.Id, "Importação abortada! </br>Ipen " + reader.GetValue(0).ToString() + " inválido!");
                                            }
                                        }
                                    } catch { throw; }
                                }
                                
                                //Caso tenha chego até aqui
                                //atualizo o Edi com sucesso, para portanto, efetuar o
                                //commit salvando todas as modificações no banco
                                var ediUpdate = _ediRepository.GetById(edi.Id);
                                ediUpdate.Status = EdiStatusEnum.CONCLUIDO;

                                _unitOfWord.Commit();
                            }
                        }
                    } catch { throw; }
                }

                return Ok(new {
                    Data = "",
                    Success = true
                });
            }
            catch { throw; }
        }

        [HttpPost]
        [Route("logs-list")]
        public async Task<IActionResult> LogsList([FromForm] DataTableServerSideRequest request)
        {
            try
            {
                if (request.Id.IsNullOrEmpty())
                {
                    throw new Exception("Não foi possível obter o EdiId para listar os logs do EDI. Favor informar equipe técnica do sistema com o código do erro: Erro=1501.");
                }

                var result = await _context.EdisLogs
                                    .Where(x => x.EdiId == Guid.Parse(request.Id))
                                    .GetDatatableResultAsync(request);
            
                var dataMapped = _mapper.Map<IEnumerable<EdiLogViewModel>>(result.Data.OrderByDescending(x => x.CreatedAt));
                
                var data = new {
                    data = dataMapped
                };

                return Ok(new {
                    Data = data,
                    Draw = result.Draw,
                    RecordsFiltered  = result._iRecordsDisplay,
                    RecordsTotal = result._iRecordsTotal,
                    Success = true
                });
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        [Route("download-file/")]
        [HttpPost]
        public FileContentResult DownloadFile([FromBody]string id)
        {
            byte[] Excel = null;

            //Obterno o nome do arquivo
            var edi = _ediRepository.GetById(Guid.Parse(id));
            string fullPath = edi.FullPath;

            Excel = System.IO.File.ReadAllBytes(fullPath);

            var response = new FileContentResult(Excel, "text/xls");
            // response.FileDownloadName = edi.ArquivoNome;
            
            return response;
        }

        private void EdiLogAddExtensions(EdiLogViewModel ediLogView)
        {
            var ediLog = new EdiLog();

            var ediMapped = _mapper.Map<EdiLog>(ediLogView);
            _ediLogRepository.AddAsync(ediMapped);
        }

        private void AbortEdiImportacao(Guid ediId, Guid tenantId, string exception)
        {
            try
            {
                //Primeiro cria um log para o edi
                var ediLog = new EdiLog();
                
                ediLog.TenantId = tenantId;
                ediLog.Tipo = EdiLogTipoEnum.INCONSISTENCIA;
                ediLog.EdiId = ediId;
                ediLog.EntityPropertyNewValue= exception;

                _ediLogRepository.Add(ediLog);
                
                //Agora atualiza o status do edi já criado
                var ediForUpdate = _ediRepository
                                        .GetById(ediId);
                ediForUpdate.Status = EdiStatusEnum.NAO_PROCESSADO;

                _ediRepository.Update(ediForUpdate);

                _unitOfWord.Commit();
                throw new Exception(exception);
            }
            catch { throw; }
        }

        private void AbortEdiImportacao(Guid ediId, string exception)
        {
            try
            {
                //Primeiro cria um log para o edi
                var ediLog = new EdiLog();
                
                ediLog.Tipo = EdiLogTipoEnum.INCONSISTENCIA;
                ediLog.EdiId = ediId;
                ediLog.EntityPropertyNewValue= exception;

                _ediLogRepository.Add(ediLog);
                _unitOfWord.Commit();
                
                //Agora atualiza o status do edi já criado
                var ediForUpdate = _ediRepository
                                        .GetById(ediId);
                ediForUpdate.Status = EdiStatusEnum.NAO_PROCESSADO;
                
                _ediRepository.Update(ediForUpdate);

                _unitOfWord.Commit();

                throw new Exception(exception);
            }
            catch { throw; }
        }

        private async Task<int> Processfile(IFormFile file, FileStream fileStream)
        {
            List<DetentoViewModel> detentosVM = new List<DetentoViewModel>();

            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
            {
                if (!reader.MergeCells.IsNullOrEmpty() && reader.MergeCells.Count() > 0)
                {
                    // return BadRequest(new
                    // {
                    //     Message = "Documento com células mescladas não é aceito para esta tipo de importação.",
                    //     Success = false
                    // });
                }

                while (reader.Read())
                {
                    detentosVM.Add(new DetentoViewModel
                    {
                        Ipen = reader.GetValue(0).ToString(),
                        Nome = StringHelpers.RemoverAcentuacao(reader.GetValue(1).ToString()),
                        Galeria = reader.GetValue(4).ToString(),
                        Cela = reader.GetValue(8).ToString(),
                        Regime = reader.GetValue(2).ToString(),
                    });
                }
            }
            
            //Begin code for update data and regime change

            //Crio um registro EDI com as informações de importação
            var edi = new Edi();
            edi.ArquivoNome = file.FileName;
            edi.ArquivoExtensao = System.IO.Path.GetExtension(file.FileName).ToLower();
            edi.Status = EdiStatusEnum.PROCESSANDO;
            await Task.Run(() => _ediRepository.AddAsync(edi));
            await Task.Run(() => _unitOfWord.CommitAsync());

            var detentosDM = await Task.Run(() => _detentoManager.GetAll());
            var hasChange = false;

            //Inicío a atualização de dados dos recolhidos
            foreach (var detentoDM in detentosDM.ToList())
            {
                hasChange = false;
                var detentoFind = detentosVM
                                    .Where(x => x.Ipen == detentoDM.Ipen)
                                    .FirstOrDefault();

                if (detentoFind != null)
                {
                    //Continua preso, verificar necessidade de atualização dos dados
                    if (!detentoFind.Nome.Equals(detentoDM.Nome))
                    {
                        //Begin - Criação de log para o edi
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Nome";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Nome;
                        ediLogViewModel.EntityPropertyNewValue = detentoFind.Nome;
                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);
                        //End - Criação de log para o edi

                        detentoDM.Nome = detentoFind.Nome;
                        hasChange = true;
                    }

                    if (!detentoDM.Galeria.Equals(detentoFind.Galeria))
                    {
                        //Begin - Criação de log para o edi
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Galeria";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Galeria;
                        ediLogViewModel.EntityPropertyNewValue = detentoFind.Galeria;
                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);
                        //End - Criação de log para o edi

                        detentoDM.Galeria = detentoFind.Galeria.ToUpper();
                        hasChange = true;
                    }

                    if (!detentoDM.Cela.Equals(detentoFind.Cela))
                    {
                        //Begin - Criação de log para o edi
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Cela";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Cela;
                        ediLogViewModel.EntityPropertyNewValue = detentoFind.Cela;
                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);
                        //End - Criação de log para o edi

                        detentoDM.Cela = detentoFind.Cela;
                        hasChange = true;
                    }

                    if (detentoFind.Regime.Equals("SAÍDA TEMPORÁRIA") && 
                        !detentoDM.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()))
                    {
                        //Begin - Criação de log para o edi
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Regime";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Regime;
                        ediLogViewModel.EntityPropertyNewValue = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);
                        //End - Criação de log para o edi

                        detentoDM.Regime = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                        detentoDM.IsSaidaTemporaria = true;
                        hasChange = true;
                    }

                    if (!detentoFind.Regime.Equals("SAÍDA TEMPORÁRIA") &&
                        detentoDM.Regime.Equals(DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString()))
                    {
                        //Begin - Criação de log para o edi
                        var ediLogViewModel = new EdiLogViewModel();
                        ediLogViewModel.EdiId = edi.Id.ToString();
                        ediLogViewModel.EntityName = "Detento";
                        ediLogViewModel.EntityProperty = "Regime";
                        ediLogViewModel.EntityPropertyOldValue = detentoDM.Regime;
                        ediLogViewModel.EntityPropertyNewValue = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                        ediLogViewModel.Tipo = EdiLogTipoEnum.MUDANCA.ToString();
                        
                        EdiLogAddExtensions(ediLogViewModel);
                        //End - Criação de log para o edi

                        detentoDM.Regime = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                        detentoDM.IsSaidaTemporaria = false;
                        hasChange = true;
                    }

                    if (hasChange)
                    {
                        _detentoManager.Update(detentoDM);
                    }
                }
                else
                {
                    //Begin - Criação de log para o edi
                    var ediLogViewModel = new EdiLogViewModel();
                    ediLogViewModel.EdiId = edi.Id.ToString();
                    ediLogViewModel.EntityName = "Detento";
                    ediLogViewModel.EntityProperty = "Ipen e Nome";
                    ediLogViewModel.EntityPropertyOldValue = detentoDM.Ipen + "-" + detentoDM.Nome;
                    ediLogViewModel.Tipo = EdiLogTipoEnum.EXCLUSAO.ToString();
                    
                    EdiLogAddExtensions(ediLogViewModel);
                    //End - Criação de log para o edi
                    
                    detentoDM.Regime = DetentoRegimeEnum.EGRESSO_EDI.ToString();
                    _detentoManager.Update(detentoDM);
                    _detentoManager.Remove((Guid)detentoDM.Id);
                }
            }
            //End code for update data and regime change

            //Begin code for inclusão data
            foreach (var detentoVM in detentosVM.ToList())
            {
                var detentoFind = detentosDM
                                    .Where(x => x.Ipen == detentoVM.Ipen)
                                    .FirstOrDefault();

                if (detentoFind == null)
                {
                    detentoVM.Nome = detentoVM.Nome;

                    if (detentoVM.Regime.Equals("SAÍDA TEMPORÁRIA"))
                    {
                        detentoVM.Regime = DetentoRegimeEnum.SAIDA_TEMPORARIA.ToString();
                        detentoVM.IsSaidaTemporaria = true;
                    }       
                    else
                    {
                        detentoVM.Regime = DetentoRegimeEnum.RECOLHIDO_EDI.ToString();
                    }

                    await _detentoManager.AddAsync(detentoVM);

                    //Begin - Criação de log para o edi
                    var ediLogViewModel = new EdiLogViewModel();
                    ediLogViewModel.EdiId = edi.Id.ToString();
                    ediLogViewModel.EntityName = "Detento";
                    ediLogViewModel.EntityProperty = "Ipen e Nome";
                    ediLogViewModel.EntityPropertyNewValue = detentoVM.Ipen + "-" + detentoVM.Nome;
                    ediLogViewModel.Tipo = EdiLogTipoEnum.INCLUSAO.ToString();
                    
                    EdiLogAddExtensions(ediLogViewModel);
                    //End - Criação de log para o edi
                }
            }
            //End code for update data and regime change

            //Caso tenha chego até aqui
            //atualizo o Edi com sucesso, para portanto, efetuar o
            //commit para salvar todas as mudanças
            var ediUpdate = _ediRepository.GetById(edi.Id);
            ediUpdate.Status = EdiStatusEnum.CONCLUIDO;
            
            // _unitOfWord.Commit();
            return await _unitOfWord.CommitAsync();
        }
        #endregion Métodos pendentes para implementar tenancy

        #region Método auxiliar para identificar registros duplicados que serão excluídos manualmente posteriormente via banco
        [HttpPost]
        [Route("delete-detentos-duplicados")]
        public IActionResult PostDeleteDetentosDuplicados(IFormCollection form)
        {           
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                string folderName = "Uploads/DetentoUpdateRegime";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                var tra = 0;
                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                DataSet result = reader.AsDataSet();
                                DataTable dt = result.Tables[0];

                                var rows = dt.Rows.Count;
                                
                                for (var i = 0; i < rows; i++)
                                {
                                    var ipen = 0;

                                    try {
                                        if (!(dt.Rows[i][0] is DBNull))
                                            ipen = Convert.ToInt32(dt.Rows[i][0]);
                                    } catch { throw; }

                                    IEnumerable<Detento> detentos = new List<Detento>();
                                    if(ipen > 0)
                                          detentos = _detentoRepository
                                                            .GetByIpenAtivoInativo(ipen);
                                    
                                    //Testar para todos os includes, caso registro não possua
                                    //nenhum registro filho eu altero a galeria
                                    if (detentos != null &&
                                        detentos.Count() > 0)
                                    {
                                        foreach (var detento in detentos)
                                        {
                                            if (detento.Colaboradores.Count() <= 0)
                                                if (detento.AndamentoPenal == null)
                                                    if (detento.ListaAmarela == null)
                                                        if (detento.Aluno == null)
                                                        {
                                                            detento.Galeria = "AP";
                                                            _detentoRepository.Update(detento);
                                                            _unitOfWord.Commit();
                                                            tra++;
                                                        }
                                        }
                                    }
                                }
                            }
                        }
                    } catch { throw; }
                }

                return Ok(new {
                    Data = tra,
                    Result = true
                });

            } catch { throw; }
        }

        /// Só faz update em detentos inativos
        [HttpPost]
        [Route("detentos-update-and-tenant-change")]
        public IActionResult PostDetentosUpdateAndTenantChange(IFormCollection form)
        {           
            try
            {
                IFormFile file = form.Files[0];
                FileStream fileStream;
                string folderName = "Uploads/DetentoUpdateMiscellaneous";
                string webRootPath = _webHostEnvironment.WebRootPath;
                string newPath = System.IO.Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                var tra = 0;
                if (file != null)
                {
                    try
                    {
                        string sFileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                        string fullPath = System.IO.Path.Combine(newPath, file.FileName);

                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        
                        using(fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            
                            using (var reader = ExcelReaderFactory.CreateReader(fileStream))
                            {
                                DataSet result = reader.AsDataSet();
                                DataTable dt = result.Tables[0];

                                var rows = dt.Rows.Count;
                                
                                for (var i = 0; i < rows; i++)
                                {
                                    var ipen = 0;
                                    Guid tenantId = new Guid();

                                    try {
                                        if (!(dt.Rows[i][0] is DBNull))
                                            ipen = Convert.ToInt32(dt.Rows[i][0]);
                                    } catch { throw; }

                                    try {
                                        if (!(dt.Rows[i][1] is DBNull))
                                            tenantId = Guid.Parse(dt.Rows[i][1].ToString());
                                    } catch { throw; }

                                    if(ipen > 0 && tenantId != Guid.Empty)
                                    {
                                        var detento = _detentoRepository
                                                            .GetInativoByIpen(ipen);
                                        if (detento != null)
                                        {
                                            detento.IsDeleted = false;
                                            detento.Nome = detento.Nome.ToUpper();
                                            detento.TenantId = (Guid) tenantId;

                                            try
                                            {
                                                _detentoRepository.Update(detento);
                                            }
                                            catch { throw; }
                                            _unitOfWord.Commit();
                                            tra++;
                                        }
                                    }
                                }
                            }
                        }
                    } catch { throw; }
                }

                return Ok(new {
                    Data = tra,
                    Result = true
                });

            } catch { throw; }
        }
        #endregion Método auxiliar para identificar registros duplicados que serão excluídos manualmente posteriormente via banco
    }
}