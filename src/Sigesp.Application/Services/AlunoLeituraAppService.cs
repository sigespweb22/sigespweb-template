using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Extensions;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Requests;
using Sigesp.Application.ViewModels.Responses;
using Sigesp.Application.Helpers;
using Sigesp.Infra.Data.Extensions;
using Sigesp.Application.ViewModels.Forms;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Application.ViewModels.Relatorios;
using Sigesp.Application.ViewModels.Oficios.Educacao;
using System.Globalization;
using Sigesp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Application.Services
{
    public class AlunoLeituraAppService : IAlunoLeituraAppService
    {
        private readonly SigespDbContext _context;
        private readonly ValidationResult _validationResult;
        private readonly IAlunoLeituraRepository _alunoLeituraRepository;
        private readonly IAlunoLeitorRepository _alunoLeitorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAlunoLeituraCronogramaRepository _alcRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly AlunoLeituraChaveGenerator _chaveLeituraGenerator;
        private readonly ITenantRepository _tenantRepository;
        private readonly IFormularioLeituraDicaEscritaRepository _flDicaEscritaRepository;
        private readonly IFormularioLeituraPerguntaGrupoRepository _flPerguntaGrupoRepository;
        private readonly ISequenciaOficioAppService _soManager;

        public AlunoLeituraAppService(ValidationResult validationResult,
                                      IAlunoLeituraRepository alunoLeituraRepository,
                                      IAlunoLeitorRepository alunoLeitorRepository,
                                      IUnitOfWork unitOfWork, IMapper mapper,
                                      IAlunoLeituraCronogramaRepository alcRepository,
                                      ILivroRepository livroRepository,
                                      AlunoLeituraChaveGenerator chaveLeituraGenerator,
                                      ITenantRepository tenantRepository,
                                      IFormularioLeituraDicaEscritaRepository flDicaEscritaRepository,
                                      IFormularioLeituraPerguntaGrupoRepository flPerguntaGrupoRepository,
                                      ISequenciaOficioAppService soManager,
                                      SigespDbContext context)
        {
            _validationResult = validationResult;
            _alunoLeituraRepository = alunoLeituraRepository;
            _alunoLeitorRepository = alunoLeitorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _alcRepository = alcRepository;
            _livroRepository = livroRepository;
            _chaveLeituraGenerator = chaveLeituraGenerator;
            _tenantRepository = tenantRepository;
            _flDicaEscritaRepository = flDicaEscritaRepository;
            _flPerguntaGrupoRepository = flPerguntaGrupoRepository;
            _soManager = soManager;
            _context = context;
        }

        #region Multitenants methods
        public async Task<FormularioLeituraFormModel> GetAllForFormsLeituraAsync(AlunoLeituraFormsLeiturasRequestModel alunoLeituraFormsLeiturasRequestModel)
        {
            #region Validações de obrigatoriedade
            try
            {
                if (string.IsNullOrEmpty(alunoLeituraFormsLeiturasRequestModel.CronogramaId) &&
                    alunoLeituraFormsLeiturasRequestModel.LeiturasIds.Count() <= 0)
                {
                    throw new Exception("Cronograma requerido.");
                }
                    
                if (string.IsNullOrEmpty(alunoLeituraFormsLeiturasRequestModel.Galeria) &&
                    alunoLeituraFormsLeiturasRequestModel.LeiturasIds.Count() <= 0)
                {
                    throw new Exception("Galeria requerida.");
                }

                if (string.IsNullOrEmpty(alunoLeituraFormsLeiturasRequestModel.DicaEscritaId))
                {
                    throw new Exception("Dica de escrita requerida.");
                }

                if (string.IsNullOrEmpty(alunoLeituraFormsLeiturasRequestModel.PerguntaGrupoId))
                {
                    throw new Exception("Grupo de pergunta requerido.");
                }
            }
            catch { throw; }
            #endregion

            #region Resolve Tenancy e obtenção dos dados
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeitura> leiturasDB = new List<AlunoLeitura>();

            /// 1º Filtro - Ocorre quando selecionado as leituras para geração de formulários
            if (alunoLeituraFormsLeiturasRequestModel.LeiturasIds.Count() >= 1)
            {
                try
                {
                    leiturasDB = await _alunoLeituraRepository
                                            .GetAllForFormsLeituraAsync(alunoLeituraFormsLeiturasRequestModel.LeiturasIds);
                }
                catch { throw; }
            }
            else
            /// 2º Filtro - Ocorre quando não selecionado nenhuma leitura e informado galeria, cronograma e opcionalmente cela
            {
                var celas = EnumExtensions<CelaEnum>.GetNumbers(alunoLeituraFormsLeiturasRequestModel.Celas);
                if (celas.Count() >= 1)
                {
                    try
                    {
                        leiturasDB = await _alunoLeituraRepository
                                                    .GetAllForFormsLeituraAsync((Guid) tenantId,
                                                                                Guid.Parse(alunoLeituraFormsLeiturasRequestModel.CronogramaId),
                                                                                alunoLeituraFormsLeiturasRequestModel.Galeria,
                                                                                celas);
                    }
                    catch { throw; }
                }
                else
                {
                    try
                    {
                        leiturasDB = await _alunoLeituraRepository
                                                    .GetAllForFormsLeituraAsync((Guid) tenantId,
                                                                                Guid.Parse(alunoLeituraFormsLeiturasRequestModel.CronogramaId),
                                                                                alunoLeituraFormsLeiturasRequestModel.Galeria);
                    }
                    catch { throw; }
                }
            }
            #endregion

            #region Mapeamento dos dados antes da geração dos forms
            
            /// Mapeamento dos dados das leituras - Dados dos alunos e dos livros
            var result = new FormularioLeituraFormModel();
            result.DadosLeituras = new List<AlunoLeituraForFormModel>();

            try
            {
                result.DadosLeituras = _mapper
                                        .Map<IEnumerable<AlunoLeituraForFormModel>>(leiturasDB).ToList();
            }
            catch { throw new Exception("Problemas no mapeamento do objeto. Tente novamente, caso o problema persista, informe o erro a equipe técnica do sistema."); }            
            #endregion

            /// Mapeamento dos dados das leituras - Dados Dica de escrita e perguntas
            try
            {
                result.FormularioLeituraDicaEscrita = await _flDicaEscritaRepository
                                                                .GetAsync(Guid.Parse(alunoLeituraFormsLeiturasRequestModel.DicaEscritaId));
                result.FormularioLeituraPerguntaGrupo = await _flPerguntaGrupoRepository
                                                                .GetAsync(Guid.Parse(alunoLeituraFormsLeiturasRequestModel.PerguntaGrupoId));
            }
            catch { throw; }

            /// Mapeamento dos dados das leituras - Dados da Unidade Prisional
            try
            {
                result.DadosUnidadePrisional = await _tenantRepository
                                                            .GetByIdAsync((Guid) tenantId);
            }
            catch { throw; }          
            return result;
        }
        public async Task<RelatorioAvaliacaoViewModel> GetAllForRelAvaliacaoAsync(AlunoLeituraRelAvaliacaoRequestModel alunoLeituraRelAvaliacaoRequestModel)
        {
            #region Required validations
            try
            {
                if (string.IsNullOrEmpty(alunoLeituraRelAvaliacaoRequestModel.PeriodoAvaliacao) &&
                    alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count() <= 0)
                {
                    throw new Exception("Período avaliação requerido.");
                }

                if (string.IsNullOrEmpty(alunoLeituraRelAvaliacaoRequestModel.CronogramaId) &&
                    alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count() <= 0)
                {
                    throw new Exception("Cronograma requerido.");
                }
                
                // if (string.IsNullOrEmpty(alunoLeituraRelAvaliacaoRequestModel.Galeria) &&
                //     alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count() <= 0)
                // {
                //     throw new Exception("Galeria requerida.");
                // }
            }
            catch { throw; }
            #endregion

            #region Tenancy resolve and get data
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeitura> leiturasDB = new List<AlunoLeitura>(); 

            /// 1º Filtro - Ocorre quando selecionado as leituras para geração de formulários
            if (alunoLeituraRelAvaliacaoRequestModel.LeiturasIds != null &&
                    alunoLeituraRelAvaliacaoRequestModel.LeiturasIds.Count() > 0)
            {
                try
                {
                    leiturasDB = await _alunoLeituraRepository
                                            .GetAllForRelAvaliacaoAsync(alunoLeituraRelAvaliacaoRequestModel.LeiturasIds);
                }
                catch { throw; }
            }
            else
            {
                Guid cronogramaId;
                try
                {
                    Guid.TryParse(alunoLeituraRelAvaliacaoRequestModel.CronogramaId, out cronogramaId);
                }
                catch { throw;}

                try
                {
                    #region Evaluation period resolve
                    DateTime periodoInicio;
                    DateTime periodoFim;
                    String periodoInicioSubs;
                    String periodoFimSubs;
                    CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
                    DateTimeFormatInfo dtfi = culture.DateTimeFormat;            

                    try
                    {
                        periodoInicioSubs = alunoLeituraRelAvaliacaoRequestModel.PeriodoAvaliacao.Substring(0, 16);
                        periodoFimSubs = alunoLeituraRelAvaliacaoRequestModel.PeriodoAvaliacao.Substring(19, 16);
                    }
                    catch (Exception ex) { throw ex; }

                    try
                    {
                        periodoInicio = DateTime.ParseExact(periodoInicioSubs, "dd/MM/yyyy HH:mm", dtfi);
                        periodoFim = DateTime.ParseExact(periodoFimSubs, "dd/MM/yyyy HH:mm", dtfi);
                    }
                    catch (Exception ex) { throw ex; }
                    #endregion
                    leiturasDB = await _alunoLeituraRepository
                                            .GetAllForRelAvaliacaoAsync((Guid) tenantId,
                                                                        cronogramaId,
                                                                        alunoLeituraRelAvaliacaoRequestModel.Galeria,
                                                                        periodoInicio,
                                                                        periodoFim);
                }
                catch { throw; }
            }
            #endregion

            foreach (var tmp in leiturasDB)
            {
                Console.WriteLine(tmp.AlunoLeitor.Aluno.Detento.Nome);
                Console.WriteLine(tmp.AlunoLeitor.Aluno.Detento.Ipen);
                Console.WriteLine(tmp.ChaveLeitura);
                Console.WriteLine(tmp.AlunoLeitor.Aluno.Detento.Galeria);
                Console.WriteLine(tmp.DataAvaliacao);
                Console.WriteLine(tmp.IsAvaliado);
            }

            #region Mapper before generate rels
            /// Mapeamento dos dados das leituras - Dados dos alunos e dos livros
            var result = new RelatorioAvaliacaoViewModel();
            result.DadosLeituras = new List<AlunoLeituraForRelatorioAvaliacao>();

            try
            {
                result.DadosLeituras = _mapper
                                        .Map<IEnumerable<AlunoLeituraForRelatorioAvaliacao>>(leiturasDB).ToList();
            }
            catch { throw new Exception("Problemas no mapeamento do objeto. Tente novamente, caso o problema persista, informe o erro a equipe técnica do sistema."); }
            #endregion

            /// Mapeamento dos dados das leituras - Dados da Unidade Prisional
            try
            {
                result.DadosUnidadePrisional = await _tenantRepository
                                                            .GetByIdAsync((Guid) tenantId);
            }
            catch { throw; }          
            return result;
        }
        public async Task<IEnumerable<AlunoLeituraViewModel>> GetAllAsync()
        {
            #region Resolve Tenancy e obtenção dos dados
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            IEnumerable<AlunoLeitura> alunosLeituras = new List<AlunoLeitura>();

            try
            {
                alunosLeituras = await _alunoLeituraRepository
                                            .GetAllAsync((Guid) tenantId);
            }
            catch { throw; }
            #endregion

            #region Mapeamento dos objetos
            var alunoLeiturasMapped = new List<AlunoLeituraViewModel>();
            try
            {
                alunoLeiturasMapped = _mapper
                                            .Map<IEnumerable<AlunoLeituraViewModel>>(alunosLeituras).ToList();
            }
            catch { throw; }
            #endregion

            #region Method return
            return alunoLeiturasMapped;
            #endregion
        }
        public async Task<DataTableServerSideResult<AlunoLeituraViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            var als = new DataTableServerSideResult<AlunoLeitura>();
            try
            {
                request.TenantId = (Guid) tenantId;
                als = await _alunoLeituraRepository
                                    .GetWithDataTableResultAsync(request);
            }
            catch { throw new Exception("Problemas ao obter uma UNIDADE PRISIONAL para o usuário logado. <br><br>Faça login novamente, caso o problema persista, informe a equipe técnica do sistema."); }
            
            var result = new DataTableServerSideResult<AlunoLeituraViewModel>();
            var alsMapped = _mapper
                                  .Map<IEnumerable<AlunoLeituraViewModel>>(als.Data).ToSafeList();

            result.Data = alsMapped;
            result.Draw = als.Draw;
            result._iRecordsDisplay = als._iRecordsDisplay;
            result._iRecordsTotal = als._iRecordsTotal;
            return result;
        }
        public async Task<ValidationResult> UpdateAsync(AlunoLeituraViewModel alunoLeituraViewModel)
        {
            try
            {
                #region Validações dados requeridos
                if (alunoLeituraViewModel.AlunoLeitorIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AlunoLeitorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.LivroId == null ||
                    alunoLeituraViewModel.LivroId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Livro requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.LeituraTipo.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Tipo leitura requerida.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AnoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ano referência requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.PeriodoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Período referência requerido.");
                    return _validationResult;
                }
                #endregion Validações dados requeridos

                #region Resolve tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Validações cronogramas
                var hasCronograma = await _alcRepository
                                              .HasCronogramaByAnoAndPeriodoReferenciaAsync(
                                                (Guid) tenantId,
                                                Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                                Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia)
                                            );

                if (!hasCronograma)
                {
                    _validationResult.AddErrorMessage("Nenhum cronograma encontrado para o ANO e PERÍODO REFERÊNCIA informado.");
                    return _validationResult;
                }
                #endregion Validações cronogramas

                #region Validações dados para foreignkey
                var alunoLeitor = _alunoLeitorRepository
                                    .GetByDetentoIpen(Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen));

                if (alunoLeitor == null)
                {
                    _validationResult.AddErrorMessage("Aluno leitor não encontrado com o IPEN informado.");
                    return _validationResult;
                }

                var livro = _livroRepository
                                .GetAtivoInativoById((Guid) alunoLeituraViewModel.LivroId);

                if (livro == null)
                {
                    _validationResult.AddErrorMessage("Livro não encontrado com o LivroId informado.");
                    return _validationResult;
                }

                var cronograma = await _alcRepository
                                            .GetByAnoAndPeriodoReferenciaAsync((Guid)tenantId,
                                                                               Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                                                               Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia));

                if (cronograma == null)
                {
                    _validationResult.AddErrorMessage("Cronograma de leitura não encontrado com o ANO e PERÍODO REFERÊNCIA informado.");
                    return _validationResult;
                }
                #endregion Validações dados encontrados

                #region Validações duplicidade de registro
                //Não permitir leitura para o mesmo ano e periodo referência
                if (alunoLeituraViewModel.LeituraTipo 
                        == LeituraTipoEnum.LEITURA_REMICAO.ToString())
                {
                    var asapr = _alunoLeituraRepository
                                .AlreadySameAnoAndPeriodoReferenciaById(
                                    (Guid) alunoLeituraViewModel.Id,
                                    Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen),
                                    Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                    Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia),
                                    Enum.Parse<LeituraTipoEnum>(alunoLeituraViewModel.LeituraTipo));
                    if (asapr)
                    {
                        _validationResult
                                .AddErrorMessage("Já existe uma leitura para o reeducando, com o ano e período referência informados.");
                        return _validationResult;
                    }

                    //Não permitir leitura para o mesmo título no tipo leitura LEITURA_REMISSÃO
                    var ast = _alunoLeituraRepository
                                    .AlreadySameTituloById(
                                        (Guid) alunoLeituraViewModel.Id,
                                        Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen),
                                        livro.Id,
                                        Enum.Parse<LeituraTipoEnum>(alunoLeituraViewModel.LeituraTipo));
                    if (ast)
                    {
                        _validationResult
                                .AddErrorMessage("Já existe uma leitura para o reeducando, com o título e tipo leitura LEITURA REMISSÃO.");
                        return _validationResult;
                    }
                }                
                #endregion Validações duplicidade de registro

                #region Mapeamento e persistência dos dados
                var alunoLeituraDB = _alunoLeituraRepository
                                        .GetByIdWithoutIncludes((Guid) alunoLeituraViewModel.Id);
                if (alunoLeituraDB == null)
                {
                    _validationResult.AddErrorMessage("Leitura não encontrada para edição com o ID informado. Tente novamente, caso o problema persista informe a equipe técnica do sistema.");
                    return _validationResult;
                }

                alunoLeituraViewModel.AlunoLeitorId = alunoLeitor.Id;
                alunoLeituraViewModel.LivroId = livro.Id;
                alunoLeituraViewModel.AlunoLeituraCronogramaId = cronograma.Id;
                
                var alunoLeituraMapped = _mapper
                                            .Map<AlunoLeituraViewModel,
                                                 AlunoLeitura>(alunoLeituraViewModel, alunoLeituraDB);
                
                _alunoLeituraRepository.Update(alunoLeituraMapped);
                #endregion Mapeamento e persistência dos dados

                #region Indisponibilizar o livro da leitura adicionada
                livro.IsDisponivel = false;
                _livroRepository.Update(livro);
                #endregion Indisponibilizar o livro da leitura adicionada

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<ValidationResult> AddAsync(AlunoLeituraViewModel alunoLeituraViewModel)
        {
            try
            {
                #region Validações dados requeridos
                if (alunoLeituraViewModel.AlunoLeitorIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AlunoLeitorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.LivroId == null ||
                    alunoLeituraViewModel.LivroId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Livro requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.LeituraTipo.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Tipo leitura requerida.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AnoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ano referência requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.PeriodoReferencia.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Período referência requerido.");
                    return _validationResult;
                }
                #endregion Validações dados requeridos

                #region Resolve tenancy
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Validações cronogramas
                var hasCronograma = await _alcRepository
                                            .HasCronogramaByAnoAndPeriodoReferenciaAsync((Guid) tenantId,
                                                                                         Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                                                                         Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia)
                                                                                         );
                if (!hasCronograma)
                {
                    _validationResult.AddErrorMessage("Nenhum cronograma encontrado para o ANO e PERÍODO REFERÊNCIA informado.");
                    return _validationResult;
                }
                #endregion Validações cronogramas

                #region Validações dados para foreignkey
                var alunoLeitor = _alunoLeitorRepository
                                    .GetByDetentoIpen(Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen));

                if (alunoLeitor == null)
                {
                    _validationResult.AddErrorMessage("Aluno leitor não encontrado com o IPEN informado.");
                    return _validationResult;
                }

                var livro = _livroRepository
                                .GetAtivoInativoById((Guid) alunoLeituraViewModel.LivroId);

                if (livro == null)
                {
                    _validationResult.AddErrorMessage("Livro não encontrado com o LivroId informado.");
                    return _validationResult;   
                }

                var cronograma = await _alcRepository
                                                .GetByAnoAndPeriodoReferenciaAsync((Guid) tenantId,
                                                                                    Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                                                                    Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia));

                if (cronograma == null)
                {
                    _validationResult.AddErrorMessage("Cronograma de leitura não encontrado com o ANO e PERÍODO REFERÊNCIA informado.");
                    return _validationResult;
                }
                #endregion Validações dados encontrados

                #region Validações duplicidade de registro
                //Não permitir leitura para o mesmo ano e periodo referência
                if (alunoLeituraViewModel.LeituraTipo 
                        == LeituraTipoEnum.LEITURA_REMICAO.ToString())
                {
                    var asapr = _alunoLeituraRepository
                                    .AlreadySameAnoAndPeriodoReferencia(
                                        Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen),
                                        Convert.ToInt32(alunoLeituraViewModel.AnoReferencia),
                                        Convert.ToInt32(alunoLeituraViewModel.PeriodoReferencia),
                                        Enum.Parse<LeituraTipoEnum>(alunoLeituraViewModel.LeituraTipo));
                    if (asapr)
                    {
                        _validationResult
                                .AddErrorMessage("Já existe uma leitura para o reeducando, ano e período referência informados.");
                        return _validationResult;
                    }

                    //Não permitir leitura para o mesmo título no tipo leitura LEITURA_REMISSÃO
                    var ast = _alunoLeituraRepository
                                    .AlreadySameTitulo(
                                        Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen),
                                        livro.Id,
                                        livro.Titulo,
                                        Enum.Parse<LeituraTipoEnum>(alunoLeituraViewModel.LeituraTipo));
                    if (ast)
                    {
                        _validationResult
                                .AddErrorMessage("Já existe uma leitura para o reeducando, título e tipo leitura LEITURA REMISSÃO.");
                        return _validationResult;
                    }

                    var astById = _alunoLeituraRepository
                                        .AlreadySameTituloById(
                                            Convert.ToInt32(alunoLeituraViewModel.AlunoLeitorIpen),
                                            livro.Id,
                                            Enum.Parse<LeituraTipoEnum>(alunoLeituraViewModel.LeituraTipo));
                    if (astById)
                    {
                        _validationResult
                                .AddErrorMessage("Já existe uma leitura para o reeducando, título e tipo leitura LEITURA REMISSÃO.");
                        return _validationResult;
                    }
                }                
                #endregion Validações duplicidade de registro

                #region Get chave leitura
                var chaveLeitura = await _chaveLeituraGenerator
                                                .GenerateNextChaveLeituraAsync((Guid) tenantId);
                alunoLeituraViewModel.ChaveLeitura = chaveLeitura.ToString();

                if (alunoLeituraViewModel.ChaveLeitura.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Não foi possível gerar uma chave de leitura. Tente mais tarde, caso o problema persista informa a equipe técnica do sistema.");
                    return _validationResult;
                }
                #endregion Get chave leitura

                #region Mapeamento e persistência dos dados
                var alunoLeituraMapped = new AlunoLeitura();
                try
                {
                    alunoLeituraMapped = _mapper
                                                .Map<AlunoLeitura>(alunoLeituraViewModel);
                }
                catch { throw; }

                alunoLeituraMapped.AlunoLeitorId = alunoLeitor.Id;
                alunoLeituraMapped.LivroId = livro.Id;
                alunoLeituraMapped.AlunoLeituraCronogramaId = cronograma.Id;
                alunoLeituraMapped.TenantId = (Guid)tenantId;

                try
                {
                    _alunoLeituraRepository.Add(alunoLeituraMapped);    
                }
                catch { throw; }
                #endregion Mapeamento e persistência dos dados

                #region Indisponibilizar o livro da leitura adicionada
                livro.IsDisponivel = false;
                _livroRepository.Update(livro);
                #endregion Indisponibilizar o livro da leitura adicionada

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<Int64> GetTotalByAvaliacaoConceitoAsync(AlunoLeituraAvaliacaoConceitoEnum avlC)
        {
            #region Tenancy resolve
            Guid tenantId;
            try
            {
                tenantId = (Guid)StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch { throw; }
            #endregion

            #region Get total
            Int64 result;
            try
            {
                result = await _alunoLeituraRepository.GetTotalByAvaliacaoConceitoAsync(tenantId, avlC);
            }
            catch { throw; }
            #endregion

            return result;
        }
        public async Task<Int64> GetTotalByLeituraTipoAsync(LeituraTipoEnum lt)
        {
            #region Tenancy resolve
            Guid tenantId;
            try
            {
                var tenantIdFromDB = await _tenantRepository.GetTenantIdAsync();
                tenantId = (Guid)StringHelpers.ExtractTenantId(tenantIdFromDB);
            }
            catch { throw; }
            #endregion

            #region Get total
            Int64 result;
            try
            {
                result = await _alunoLeituraRepository.GetTotalByLeituraTipoAsync(tenantId, lt);
            }
            catch { throw; }
            #endregion

            return result;
        }
        public async Task<OficioEducacaoLeituraViewModel> GetOficioLeituraAsync(List<string> leiturasIds)
        {
            #region Required validations
            if (leiturasIds == null || leiturasIds.Count() <= 0)
                throw new ArgumentException("Ao menos uma leitura é requerida.");    
            #endregion

            #region Get data leitura
            IEnumerable<AlunoLeitura> pureResult = new List<AlunoLeitura>();
            try
            {
                pureResult = await _alunoLeituraRepository.GetForOficioLeituraAsync(leiturasIds);
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            #region Validations data leitura
            /// check to null or empty
            if (pureResult == null || pureResult.Count() <= 0)
                return null;
            
            try
            {
                /// check leituras to oficio
                if (pureResult.Any(x => x.HasOficio))
                    throw new Exception("Uma ou mais leitura selecionada já possui ofício, verifique.");
                
                /// check leituras to same leitor
                if (pureResult.GroupBy(x => x.AlunoLeitor.Aluno.Detento.Ipen).Count() > 1)
                    throw new Exception("As leituras selecionadas não são do mesmo leitor, verifique.");
                
                /// check leituras to conceito diff aprovado
                if (pureResult.Any(x => x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.DESISTENCIA) ||
                    pureResult.Any(x => x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.PENDENTE))
                    throw new Exception("Uma ou mais leitura selecionada possui conceito DESISTENCIA ou PENDENTE, verifique.</br></br>É permitido criação de ofício somente para leituras de conceito: </br>APROVADO e NÃO CUMPRIMENTO.");
                
                /// check leituras to conceito only insuficiente, only desistencia, only não cumprimento, or both
                if (!pureResult.Any(x => x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO))
                    throw new Exception("Ao menos uma leitura selecionada deve ter conceito APROVADO.");
                
                /// check if reeducando is provisório
                var pec = pureResult.Select(x => x.AlunoLeitor.Aluno.Detento.AndamentoPenal.Pec).FirstOrDefault();
                if (string.IsNullOrEmpty(pec))
                {
                    throw new Exception("Reeducando provisório. </br></br> Não é permitido criar ofício para reeducando nesta condição.");
                }
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Get sequência ofício
            var so =  new SequenciaOficioViewModel();
            try
            {
                so = _soManager.CriarNova();
                if (so == null)
                    throw new Exception("Problemas ao obter uma sequência de ofício. Tente novamente, persistindo o problema informe a equipe técnica do sistema.");
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            #region Get tenant data
            Guid tenantId;
            try
            {
                tenantId =  (Guid) StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            }
            catch (Exception ex) { throw ex; }
            
            var tenant = new Tenant();
            try
            {
                tenant = await _tenantRepository.GetForOficioLeituraAsync(tenantId);
            }
            catch (Exception ex) { throw ex; }
            #endregion

            #region Mapper
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(DateTime.Now.Month)).ToLower();
            
            var result = new OficioEducacaoLeituraViewModel();
            result.Leituras = new List<OficioEducacaoLeitura>();
            try
            {
                result.OficioNumero = so.Sequencia.ToString();
                result.OficioData = "Criciúma, " + DateTime.Now.Day.ToString() + " de " + mes + " de " + DateTime.Now.Year + ".";
                result.DetentoNome = pureResult.Select(x => x.AlunoLeitor.Aluno.Detento.Nome).FirstOrDefault();
                result.DetentoIpen = pureResult.Select(x => x.AlunoLeitor.Aluno.Detento.Ipen).FirstOrDefault().ToString();
                result.DetentoPec = pureResult.Select(x => x.AlunoLeitor.Aluno.Detento.AndamentoPenal.Pec).FirstOrDefault().Replace(" ", "");
                result.OficioRemicao = (pureResult.Count(x => x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO) * 4).ToString();
                
                foreach (var leitura in pureResult.ToList())
                {
                    try
                    {
                        var item = new OficioEducacaoLeitura
                        {
                            Id = leitura.Id,
                            AnoReferencia = leitura.AlunoLeituraCronograma.AnoReferencia,
                            PeriodoReferenciaSequencia = leitura.AlunoLeituraCronograma.PeriodoReferencia,
                            PeriodoReferencia = leitura.AlunoLeituraCronograma.PeriodoInicio.ToString("dd/MM/yyyy") + " a " + leitura.AlunoLeituraCronograma.PeriodoFim.ToString("dd/MM/yyyy"),
                            TituloLivro = leitura.Livro.Titulo,
                            LeituraRemicao = leitura.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.APROVADO ? 4.ToString() : "0",
                            Conceito = leitura.AvaliacaoConceito.ToString()
                        };
                        result.Leituras.Add(item);    
                    }
                    catch (Exception ex) { throw ex; }
                }
                
                result.Tenant =  new Tenant()
                {
                    NomeExibicao = tenant.NomeExibicao,
                    OficioLeituraAssinaturaNome = tenant.OficioLeituraAssinaturaNome,
                    OficioLeituraAssinaturaCargo = tenant.OficioLeituraAssinaturaCargo,
                    OficioLeituraAssinaturaMatricula = tenant.OficioLeituraAssinaturaMatricula,
                    EnderecoLogradouro = tenant.EnderecoLogradouro,
                    EnderecoLogradouroNumero = tenant.EnderecoLogradouroNumero,
                    EnderecoBairro = tenant.EnderecoBairro,
                    EnderecoCEP = tenant.EnderecoCEP,
                    EnderecoCidade = tenant.EnderecoCidade,
                    EnderecoEstado = tenant.EnderecoEstado,
                    TelefoneDDD = tenant.TelefoneDDD,
                    TelefoneNumero = tenant.TelefoneNumero,
                    EmailPrincipal = tenant.EmailPrincipal,
                    OficioLeituraVocativo1 = tenant.OficioLeituraVocativo1,
                    OficioLeituraVocativo2 = tenant.OficioLeituraVocativo2,
                    OficioLeituraVocativo3 = tenant.OficioLeituraVocativo3
                };
            }
            catch (Exception ex) { throw ex; }
            #endregion
            
            return result;
        }
        #endregion

        #region Is not multitenants methods
        public async Task<Guid> GetCronogramaIdAsync(Guid alunoLeituraId)
        {
            #region Required validations
            if (alunoLeituraId == null || alunoLeituraId == Guid.Empty)
                throw new ArgumentException("Id da leitura requerido.");
            #endregion

            Guid result;
            try
            {
                result = await _alunoLeituraRepository.GetCronogramaIdAsync(alunoLeituraId);
            }
            catch { throw; }
            return result;
        }
        #endregion

        #region Métodos pendentes para implementar tenancy
        public async Task<AlunoLeituraViewModel> GetByIdAsync(string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    throw new Exception("Id requerido");

                var alunoLeitura = await _alunoLeituraRepository.GetByIdAsync(Guid.Parse(id));
                var alunoLeituraMapped = _mapper.Map<AlunoLeituraViewModel>(alunoLeitura);
            
                return alunoLeituraMapped;    
            }
            catch { throw; }
        }
        public AlunoLeituraViewModel GetByIdIncludes(string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    throw new Exception("Id requerido");

                var alunoLeitura = _alunoLeituraRepository.GetByIdIncludes(Guid.Parse(id));
                var alunoLeituraMapped = _mapper.Map<AlunoLeituraViewModel>(alunoLeitura);
            
                return alunoLeituraMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<AlunoLeituraViewModel>> GetAllAsyncIncludes()
        {
            try
            {
                var alunoLeituras  = await _alunoLeituraRepository.GetAllAsync();
                var alunoLeiturasMapped = _mapper.Map<IEnumerable<AlunoLeituraViewModel>>(alunoLeituras);

                return alunoLeiturasMapped;    
            }
            catch { throw; }
        }
        public IEnumerable<AlunoLeituraViewModel> GetAllWithInclude()
        {
            try
            {
                var alunoLeituras  = _alunoLeituraRepository.GetAllWithIncludes();
                var alunoLeiturasMapped = _mapper.Map<IEnumerable<AlunoLeituraViewModel>>(alunoLeituras);

                return alunoLeiturasMapped;    
            }
            catch { throw; }
        }
        public async Task<AlunoLeituraNovosResponseViewModel> AddsAsync(AlunoLeituraNovosRequestViewModel 
                                                       alunoLeituraNovosRequestViewModel)
        {
            try
            {
                var _response = new AlunoLeituraNovosResponseViewModel();
                
                #region Validações dados requeridos
                if (alunoLeituraNovosRequestViewModel.LeituraTipo.IsNullOrEmpty())
                {
                    _response.AddErrorMessage("Tipo leitura requerido.");
                    return _response;
                }

                if (alunoLeituraNovosRequestViewModel.Galeria.IsNullOrEmpty())
                {
                    _response.AddErrorMessage("Galeria requerida.");
                    return _response;
                }

                if (alunoLeituraNovosRequestViewModel.Cronograma.IsNullOrEmpty())
                {
                    _response.AddErrorMessage("Cronograma requerido.");
                    return _response;
                }
                #endregion Validações dados requeridos

                #region Resolve Tenany
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Validações cronogramas
                bool hasCronograma;
                try
                {
                    hasCronograma = await _alcRepository
                                            .HasCronogramaByIdAsync((Guid) tenantId, 
                                                                    Guid.Parse(alunoLeituraNovosRequestViewModel.Cronograma));
                }
                catch { throw; }

                if (!hasCronograma)
                {
                    _response.AddErrorMessage("Nenhum cronograma encontrado com o NOME do cronograma informado para geração das leituras.");
                    return _response;
                }
                #endregion Validações cronogramas

                #region Validações dados para foreignkey
                var cronograma =  new AlunoLeituraCronograma();
                try
                {
                    cronograma = await _alcRepository
                                            .GetByIdAsync((Guid) tenantId, 
                                                           Guid.Parse(alunoLeituraNovosRequestViewModel.Cronograma));
                }
                catch { throw; }
                if (cronograma == null)
                {
                    _response.AddErrorMessage("Cronograma de leitura não encontrado com o NOME informado para geração das leituras.");
                    return _response;
                }
                #endregion Validações dados encontrados

                #region Aplicação de filtro
                int countLeituras = 0;
                var leitores = new List<AlunoLeitor>();

                if (alunoLeituraNovosRequestViewModel.Celas == null ||
                    alunoLeituraNovosRequestViewModel.Celas.Count() <= 0)
                {
                    //Filtro galeria
                    leitores = _alunoLeitorRepository
                                        .GetAllByDetentoGaleria(alunoLeituraNovosRequestViewModel.Galeria)
                                        .ToList();
                }
                else
                {
                    //Filtro galeria e cela
                    var celas = new List<int>();

                    foreach (var cela in alunoLeituraNovosRequestViewModel.Celas)
                    {
                        var celaConverted = Convert.ToInt32(Enum.Parse<CelaEnum>(cela));
                        celas.Add(celaConverted);
                    }

                    leitores = _alunoLeitorRepository
                                        .GetAllRemoveRangeCelas(celas,
                                                                alunoLeituraNovosRequestViewModel.Galeria)
                                        .ToList();
                }
                #endregion Aplicação de filtro

                #region Criação das leituras
                if (leitores.Count() > 0)
                {
                    #region Validação de quantitativo de acervo para geração de leituras
                    //É necessário um quantitativo mínimo de 1/3 de livros disponíveis
                    //sobre o total de leitores para a geração da leitura
                    var livrosDisponiveis = _livroRepository
                                                        .GetTotalDisponiveis();

                   if (livrosDisponiveis < leitores.Count())
                    {
                        _response.AddErrorMessage("Leituras não criadas! QUANTITATIVO BAIXO DE LIVROS: para mais detalhes verifique no rodapé a tabela de ocorrências.");
                        return _response;
                    }
                    #endregion Validação de quantitativo de acervo para geração de leituras
                    
                    foreach (var leitor in leitores.ToList())
                    {
                        //Caso o tipo leitura seja LEITURA_REMICAO
                        //verificar se já não existe leitura deste tipo
                        //para o leitor
                        if (alunoLeituraNovosRequestViewModel.LeituraTipo ==
                            LeituraTipoEnum.LEITURA_REMICAO.ToString())
                        {
                            var alreadyLeitura = _alunoLeituraRepository
                                                    .AlreadySameCronograma(cronograma.Id,
                                                                            leitor.Aluno.Detento.Ipen);

                            if (alreadyLeitura)
                            {
                                _response.AddErrorMessage(leitor.Aluno.Detento.Ipen + " - " + 
                                                          leitor.Aluno.Detento.Nome + ": Leitura não criada! JÁ POSSUI LEITURA PARA O CRONOGRAMA informado");
                                continue;
                            }
                        }

                        //Não permitir leitura duplicada pelo TÍTULO ou livroId
                        var leitorTitulosLidos = _alunoLeituraRepository
                                                    .GetAllTitulosLidos(leitor.Aluno.Detento.Ipen,
                                                                        LeituraTipoEnum.LEITURA_REMICAO);
                        
                        //Caso não possua nenhuma leitura, obter
                        //qualquer título com base no gênero do leitor
                        var getTitulo = new Livro();
                        if (!leitorTitulosLidos.IsNullOrEmpty() &&
                            leitorTitulosLidos.Count() > 0)
                        {
                            getTitulo = _livroRepository
                                                .GetOneTituloDisponivelRemovingList(leitorTitulosLidos, leitor.LivroGenero.Nome);
                        }
                        else
                        {
                            getTitulo = _livroRepository
                                                .GetOneTituloDisponivel(leitor.LivroGenero.Nome);
                        }
                        
                        if (getTitulo != null && getTitulo.Id != Guid.Empty)
                        {
                            //Montar leitura para add
                            var leitura = new AlunoLeitura();
                            leitura.TenantId = (Guid) tenantId;
                            leitura.AlunoLeitorId = leitor.Id;
                            leitura.LeituraTipo = Enum.Parse<LeituraTipoEnum>(alunoLeituraNovosRequestViewModel.LeituraTipo);
                            leitura.LivroId = getTitulo.Id;
                            leitura.AlunoLeituraCronogramaId = cronograma.Id;

                            #region Get chave leitura
                            leitura.ChaveLeitura = await _chaveLeituraGenerator
                                                            .GenerateNextChaveLeituraAsync((Guid) tenantId);

                            if (leitura.ChaveLeitura == 0)
                            {
                                _response.AddErrorMessage(leitor.Aluno.Detento.Ipen + " - " + 
                                                      leitor.Aluno.Detento.Nome + ": Leitura não criada! NÃO FOI POSSÍVEL OBTER UMA CHAVE DE LEITURA. Tente mais tarde, caso o problema persista informe a equipe técnica do sistema");
                                continue;
                            }
                            #endregion Get chave leitura

                            _alunoLeituraRepository.Add(leitura);

                            //Indisponibilização do livro adicionado na leitura
                            getTitulo.IsDisponivel = false;
                            _livroRepository.Update(getTitulo);

                            #region UnitOfwork - Commit
                            countLeituras++;
                            _unitOfWork.Commit();
                            #endregion
                        }
                        else
                        {
                            _response.AddErrorMessage(leitor.Aluno.Detento.Ipen + " - " + 
                                                      leitor.Aluno.Detento.Nome + ": Leitura não criada! NÃO FOI POSSÍVEL OBTER UM TÍTULO DE LIVRO para criar a leitura");
                            continue;
                        }
                    }
                }
                else
                {
                    _response.AddErrorMessage("Nenhum leitor encontrado com a GALERIA e CELAS informadas, para criação das leituras.");
                }
                #endregion Criação das leituras

                _response.TotalLeiturasCriadas = countLeituras;
                _response.Cronograma = cronograma.Nome;
                _response.LeituraTipo = alunoLeituraNovosRequestViewModel.LeituraTipo;
                
                foreach (var item in alunoLeituraNovosRequestViewModel.Celas)
                {
                    _response.Celas = item + "; " + _response.Celas;
                }
                
                _response.Galeria = alunoLeituraNovosRequestViewModel.Galeria;
                
                #region Retorno em caso de sucesso
                return _response;
                #endregion Retorno em caso de sucesso
            } 
            catch { throw; }
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _alunoLeituraRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public virtual void DetachLocal(Func<Entity, bool> predicate)
        {
            var local = _context.Set<Entity>().Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
        }
        public ValidationResult Avaliar(AlunoLeituraViewModel alunoLeituraViewModel)
        {
            try
            {
                #region Validações dados requeridos
                if (alunoLeituraViewModel.Id == null ||
                    alunoLeituraViewModel.Id == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio1.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Adequação do texto ao gênero requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio2.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Coesão e Coerência requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio3.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Comprovação da leitura requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio4.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Compreensão do conteúdo requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio5.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Linguagem clara e objetiva requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio6.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Variedade de vocabulário requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoCriterio7.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ortografia e aspectos gramaticais requerido.");
                    return _validationResult;
                }

                if (alunoLeituraViewModel.AvaliacaoConceito.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Conceito requerido.");
                    return _validationResult;
                }
                #endregion Validações dados requeridos

                #region Validações gerais
                if (alunoLeituraViewModel.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.NAO_CUMPRIMENTO.ToString() &&
                    alunoLeituraViewModel.AvaliacaoConceitoJustificativa.IsNullOrEmpty() ||
                    alunoLeituraViewModel.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.INSUFICIENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoConceitoJustificativa.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Conceitos: 'NÃO CUMPRIMENTO OU INSUFICIENTE', requer uma justificativa.");
                    return _validationResult;
                }

                #endregion Validações gerais

                #region Validações localização de registro para atualização
                var alunoLeitura = _alunoLeituraRepository
                                        .GetByIdIncludes((Guid) alunoLeituraViewModel.Id);

                if (alunoLeitura == null)
                {
                    _validationResult.AddErrorMessage("Nenhuma LEITURA encontrada para avaliação com o ID informado. \nTente novamente mais tarde, caso o problema persista informe a equipe técnica do sistema.");
                    return _validationResult;
                }
                
                #endregion

                #region Check to 3 NÃO CUMPRIMENTOS consecutivos
                // check se possui 3 NÃO CUMPRIMENTOS consecutivos
                // caso tenha, inativar leitor e não permitir incluí-lo 
                if (alunoLeituraViewModel.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.NAO_CUMPRIMENTO.ToString())
                {
                    // definição de consecutividade: são 3 leituras sequentes com o mesmo conceito, para o mesmo ano
                    var udlsnc = new List<AlunoLeitura>();
                    var currentPeriodo = alunoLeitura.AlunoLeituraCronograma.PeriodoReferencia;

                    try
                    {
                        udlsnc = _context.AlunosLeituras
                                            .Include(x => x.AlunoLeituraCronograma)
                                            .Where(x => x.AlunoLeitorId == alunoLeitura.AlunoLeitorId &&
                                                   x.AvaliacaoConceito == AlunoLeituraAvaliacaoConceitoEnum.NAO_CUMPRIMENTO &&
                                                   x.AlunoLeituraCronograma.AnoReferencia.Year == DateTime.Now.Year).ToList();
                    }
                    catch { throw; }

                    // prevPR - Período referência anterior ao corrente
                    // prevPrevPR - Período referência anterior ao anterior
                    var prevPR = currentPeriodo - 1;
                    var prevPrevPR = prevPR - 1;
    
                    if (prevPR != 0 && prevPrevPR != 0)
                    {
                        var getPrevLeitura = udlsnc.FirstOrDefault(x => x.AlunoLeituraCronograma.PeriodoReferencia == prevPR);
                        var getPrevPrevLeitura = udlsnc.FirstOrDefault(x => x.AlunoLeituraCronograma.PeriodoReferencia == prevPrevPR);
                        
                        // check to sequentiality
                        if (getPrevLeitura != null && getPrevPrevLeitura != null)
                        {
                            var leitor = new AlunoLeitor();
                            try
                            {
                                leitor = _context
                                            .AlunosLeitores
                                            .IgnoreQueryFilters()
                                            .FirstOrDefault(x => x.Id == alunoLeitura.AlunoLeitorId);
                            }
                            catch { throw; }

                            if (leitor == null)
                                throw new Exception("Leitor não foi localizado. Tente novamente, persistindo o erro informe a equipe técnica do sistema.");
                            
                            leitor.IsDeleted = true;
                            leitor.OcorrenciaDesistencia = AlunoLeitorOcorrenciaDesistenciaEnum.BLOQUEIO_AUTOMATICO_NAO_CUMPRIMENTO;
                            leitor.DataOcorrenciaDesistencia = DateTime.Now;
                            leitor.LockoutEndByOcorrencia = DateTime.Now.AddMonths(3);
                            leitor.AlunoLeituras = null;

                            _context.AlunosLeitores.Update(leitor);
                        }
                    }
                }
                #endregion

                #region Validação de conceito informado sem algum critério não informado
                if (alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio1 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio2 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio3 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio4 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio5 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio6 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString() ||
                    alunoLeituraViewModel.AvaliacaoConceito !=
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString() &&
                    alunoLeituraViewModel.AvaliacaoCriterio7 == 
                    AlunoLeituraAvaliacaoCriterioEnum.PENDENTE.ToString())
                {
                    _validationResult.AddErrorMessage("Você está informando um CONCEITO para avaliação, portanto, todos os CRITÉRIOS DE AVALIAÇÃO são obrigatórios");
                    return _validationResult;
                }
                #endregion Validação de conceito informado sem algum critério não informado

                #region Caso o conceito seja não avaliado, passar todos os critérios para 0
                if (alunoLeituraViewModel.AvaliacaoConceito ==
                    AlunoLeituraAvaliacaoConceitoEnum.PENDENTE.ToString())
                {
                    alunoLeituraViewModel.AvaliacaoCriterio1 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio2 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio3 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio4 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio5 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio6 = "0";
                    alunoLeituraViewModel.AvaliacaoCriterio7 = "0";
                }
                #endregion Caso o conceito seja não avaliado, passar todos os critérios para 0

                #region Mapeamento e persistência dos dados
                alunoLeituraViewModel.LeituraTipo = alunoLeitura.LeituraTipo.ToString();
                alunoLeituraViewModel.ChaveLeitura = alunoLeitura.ChaveLeitura.ToString();

                alunoLeituraViewModel.AlunoLeitorId = alunoLeitura.AlunoLeitor.Id;
                alunoLeituraViewModel.LivroId = alunoLeitura.Livro.Id;
                alunoLeituraViewModel.AlunoLeituraCronogramaId = alunoLeitura.AlunoLeituraCronograma.Id;
                var alunoLeituraMapped = _mapper
                                            .Map<AlunoLeituraViewModel, AlunoLeitura>
                                                (alunoLeituraViewModel, alunoLeitura);

                alunoLeituraMapped.DataAvaliacao = DateTime.Now;
                alunoLeituraMapped.IsAvaliado = true;

                // _context.DetachLocal(alunoLeituraMapped, alunoLeituraMapped.Id.ToString());
                // https://stackoverflow.com/questions/36856073/the-instance-of-entity-type-cannot-be-tracked-because-another-instance-of-this-t
                var local = _context.Set<AlunoLeitura>()
                                .Local
                                .FirstOrDefault(entry => entry.Id.Equals(alunoLeituraMapped.Id));

                // check if local is not null 
                if (local != null)
                {
                    // detach
                    _context.Entry(local).State = EntityState.Detached;
                }
                // set Modified flag in your entry
                _context.Entry(alunoLeituraMapped).State = EntityState.Modified;

                _alunoLeituraRepository.Update(alunoLeituraMapped);
                #endregion Mapeamento e persistência dos dados

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _alunoLeituraRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = _alunoLeituraRepository.GetTotalInativos();
            return inativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _alunoLeituraRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }
        public bool AlreadyAlunoLeitorAtivoByIpen(int ipen)
        {
            var alreadyByIpen = _alunoLeituraRepository.AlreadyAlunoLeitorAtivoByIpen(ipen);
            return alreadyByIpen;
        }
        public async Task<AlunoLeituraViewModel> GetByChaveLeituraAsync(string chaveLeitura)
        {
            try
            {
                #region Required validations
                if (chaveLeitura.IsNullOrEmpty())
                    throw new ArgumentException("Chave leitura requerida.");

                if (chaveLeitura.Count() >= 11)
                    throw new Exception("Limite máximo de caracter ultrapassado. <br><br>Informe no máximo 10 caracteres para a chave da leitura");
                #endregion
            }
            catch { throw; }

            Int64 chlMapped;
            try
            {
                chlMapped = Int64.Parse(chaveLeitura);
                if (chlMapped == 0)
                    throw new Exception("Problemas ao converter a CHAVE DE LEITURA. Tente novamente, caso o problema persista informe a equipe técnica do sistema.");
            }
            catch { throw; }

            #region Tenancy resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            #endregion

            var result = new AlunoLeitura();
            try
            {
                result = await _alunoLeituraRepository
                                    .GetByChaveLeituraAsync((Guid) tenantId, chlMapped);
            }
            catch { throw; }

            #region Mapped
            var resultMapped = new AlunoLeituraViewModel();
            try 
            {
                resultMapped = _mapper.Map<AlunoLeituraViewModel>(result);
            }
            catch { throw; }
            #endregion
            return resultMapped;
        }
        public ValidationResult GetLivroForEdicao(string alunoLeituraId)
        {
            try
            {
                #region Validações de obrigatoriedade
                if (alunoLeituraId.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Id da leitura requerido");
                    return _validationResult;
                }
                #endregion Validações de obrigatoriedade

                var idMapped = Guid.Parse(alunoLeituraId);
                if (idMapped == null ||
                    idMapped == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Problemas ao converter o ID da LEITURA. Tente novamente, caso o problema persista informe a equipe técnica do sistema.");
                    return _validationResult;
                }

                var result = _alunoLeituraRepository
                                    .GetLivroForEdicao(idMapped);
                
                if (result != null)
                {
                    var resultMapped = _mapper.Map<LivroViewModel>(result);
                    _validationResult.AddObject(resultMapped);
                }

                return _validationResult;
            }
            catch { throw; }
        }
        #endregion

        public void Dispose()
        {
            _alunoLeituraRepository.Dispose();
        }
    }
}