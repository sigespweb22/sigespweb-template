using System.Threading;
using System.Security.Cryptography;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Application.Extensions;
using Sigesp.Domain.Models.DataTable;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Reports;

namespace Sigesp.Application.Services
{
    public class ListaAmarelaAppService : IListaAmarelaAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IListaAmarelaRepository _listaAmarelaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDetentoAppService _detentoManager;
        private readonly IDetentoRepository _detentoRepository;

        public ListaAmarelaAppService(ValidationResult validationResult,
                                        IListaAmarelaRepository listaAmarelaRepository, 
                                        IUnitOfWork unitOfWork, 
                                        IMapper mapper,
                                        IDetentoAppService detentoManager,
                                        IDetentoRepository detentoRepository)
        {
            _validationResult = validationResult;
            _listaAmarelaRepository = listaAmarelaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _detentoManager = detentoManager;
            _detentoRepository = detentoRepository;
        }

        public async Task<DataTableServerSideResult<ListaAmarelaViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var listasAmarela = await _listaAmarelaRepository
                                                    .GetWithDataTableResultAsync(request);

            var listasAmarelaMapped = new DataTableServerSideResult<ListaAmarelaViewModel>();
            listasAmarelaMapped.Data = new List<ListaAmarelaViewModel>();

            foreach (var listaAmarela in listasAmarela.Data.ToList())
            {
                var tmp = new ListaAmarelaViewModel {
                    Id = listaAmarela.Id,
                    RevisaoIpenData = listaAmarela.RevisaoIpenData.ToString("yyyy-MM-dd"),
                    DataPrisao = listaAmarela.DataPrisao.ToString("yyyy-MM-dd"),
                    Artigos = listaAmarela.Artigos,
                    Comarca = listaAmarela.Comarca,
                    PenaAno = listaAmarela.PenaAno,
                    PenaMes = listaAmarela.PenaMes,
                    PenaDia = listaAmarela.PenaDia,
                    CondenacaoTipo = listaAmarela.CondenacaoTipo.ToString(),
                    DiasMedidaDisciplinar = listaAmarela.DiasMedidaDisciplinar,
                    AcaoPenal = listaAmarela.AcaoPenal,
                    DataPrevisaoBeneficio = listaAmarela.DataPrevisaoBeneficio.ToString("yyyy-MM-dd"),
                    DataProgressao = listaAmarela.DataProgressao.ToString("yyyy-MM-dd"),
                    PrevisaoBeneficioObservacao = listaAmarela.PrevisaoBeneficioObservacao,
                    DetentoNome = listaAmarela.Detento.Nome,
                    DetentoIpen = listaAmarela.Detento.Ipen.ToString(),
                    DataSaidaPrevista = listaAmarela.DataSaidaPrevista.ToString("yyyy-MM-dd"),          
                };

                foreach (var instrumentoPrisao in listaAmarela.InstrumentosPrisao)
                {
                    var enumMapped = Enum.GetName(typeof(InstrumentoPrisaoTipoEnum), instrumentoPrisao);
                    tmp.InstrumentosPrisao.Add(enumMapped);
                }

                listasAmarelaMapped.Data.Add(tmp);
            }

            listasAmarelaMapped.Draw = listasAmarela.Draw;
            listasAmarelaMapped._iRecordsDisplay = listasAmarela._iRecordsDisplay;
            listasAmarelaMapped._iRecordsTotal = listasAmarela._iRecordsTotal;

            return listasAmarelaMapped;
        }
        public ListaAmarelaViewModel GetByDetentoNome(string nome)
        {
            var listaAmarela = _listaAmarelaRepository.GetByDetentoNome(nome);
            var listaAmarelaMapped = _mapper.Map<ListaAmarelaViewModel>(listaAmarela);

            return listaAmarelaMapped;
        }
        public ListaAmarelaViewModel GetByDetentoIpen(string ipen)
        {
            var listaAmarela = _listaAmarelaRepository.GetByDetentoIpen(Convert.ToInt32(ipen));
            var listaAmarelaMapped = _mapper.Map<ListaAmarelaViewModel>(listaAmarela);

            return listaAmarelaMapped;
        }
        public async Task<IEnumerable<ListaAmarelaViewModel>> GetAllAsync()
        {
            var listasAmarela = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(
                                            await _listaAmarelaRepository.GetAllOnlyIsDeletedTrue());
            return listasAmarela;
        }
        public IEnumerable<ListaAmarelaViewModel> GetAll()
        {
            var listasAmarela = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(
                                    _listaAmarelaRepository.GetAll());
                                    
            return listasAmarela;
        }
        public IEnumerable<ListaAmarelaViewModel> GetAllWithInclude()
        {
            var listasAmarela = _listaAmarelaRepository.GetAllWithInclude();
            var listasAmarelaMapped = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(listasAmarela);
                                    
            return listasAmarelaMapped;
        }
        public IEnumerable<ListaAmarelaViewModel> GetAllWithIgnoreFilter()
        {
            var listasAmarela = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(
                                    _listaAmarelaRepository
                                    .GetAllWithIgnoreFilter());
                                    
            return listasAmarela;
        }
        public ValidationResult Add(ListaAmarelaViewModel listaAmarelaViewModel)
        {
            try
            {
                if (listaAmarelaViewModel.DetentoIpen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Ipen requerido.");
                    return _validationResult;
                }

                var detento = _detentoRepository
                                        .GetForUpdateByIpen(Convert.ToInt32(listaAmarelaViewModel.DetentoIpen));
                if (detento == null)
                {
                    _validationResult.AddErrorMessage("Nenhum detento encontrado com o nome/ipen informado para atualização do REGIME DETENTO (via Lista Amarela).");
                    return _validationResult;
                }

                if (_listaAmarelaRepository.AlreadyAtivoByDetentoIpen(detento.Ipen))
                {
                    _validationResult.AddErrorMessage("Já existe um registro ativo com o IPEN informado.");
                    return _validationResult;                    
                }

                if (listaAmarelaViewModel.Id != null &&
                    listaAmarelaViewModel.Id != Guid.Empty)
                {
                    var lancamentoDB = _listaAmarelaRepository
                                            .GetInativoByIdWithInclude((Guid) listaAmarelaViewModel.Id);

                    listaAmarelaViewModel.DetentoId = lancamentoDB.DetentoId;
                    listaAmarelaViewModel.IsDeleted = false;

                    var listaAmarelaMapper = _mapper.Map<ListaAmarelaViewModel, ListaAmarela>
                                                    (listaAmarelaViewModel, lancamentoDB);

                    var detentoForUpdate = _detentoRepository.GetById(detento.Id);
                    detentoForUpdate.Regime = (DetentoRegimeEnum)Enum.Parse(typeof(DetentoRegimeEnum), listaAmarelaViewModel.DetentoRegime);
                    
                    _detentoRepository.Update(detentoForUpdate);
                    _listaAmarelaRepository.Update(listaAmarelaMapper);
                }
                else
                {
                    listaAmarelaViewModel.DetentoId = detento.Id;
                    listaAmarelaViewModel.DetentoViewModel = null;
                    listaAmarelaViewModel.DetentoIpen = null;
                    listaAmarelaViewModel.DetentoNome = null;

                    var listaAmarelaMapped = _mapper.Map<ListaAmarela>(listaAmarelaViewModel);
                    detento.Regime = (DetentoRegimeEnum)Enum.Parse(typeof(DetentoRegimeEnum), listaAmarelaViewModel.DetentoRegime);

                    _detentoRepository.Update(detento);
                    _listaAmarelaRepository.Add(listaAmarelaMapped);   
                }

                _unitOfWork.Commit();
                return _validationResult;
            }
            catch (System.Exception ex)
            {
                _validationResult.AddErrorMessage(ex.Message);
                return _validationResult;
            }
        }
        public ValidationResult Remove(Guid id)
        {
            //Não permitir deletar lançamento 'LIQUIDADO' ou 'CANCELADO'  
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lançamento 'LIQUIDADO' ou 'CANCELADO' não pode ser deletado."); 
            //     return _validationResult;
            // }

            _listaAmarelaRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public ValidationResult Update(ListaAmarelaViewModel listaAmarelaViewModel)
        {
            try
            {
                var lancamentoDB = _listaAmarelaRepository
                                        .GetByIdWithInclude((Guid) listaAmarelaViewModel.Id);

                listaAmarelaViewModel.DetentoId = lancamentoDB.DetentoId;
                var listaAmarelaMapper = _mapper.Map<ListaAmarelaViewModel, ListaAmarela>
                                                (listaAmarelaViewModel, lancamentoDB);

                var detento = _detentoRepository.GetById((Guid) listaAmarelaViewModel.DetentoId);
                detento.Regime = (DetentoRegimeEnum)Enum.Parse(typeof(DetentoRegimeEnum), listaAmarelaViewModel.DetentoRegime);
                
                _detentoRepository.Update(detento);
                _listaAmarelaRepository.Update(listaAmarelaMapper);
                
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException != null)
                    _validationResult.AddErrorMessage(ex.InnerException.Message);
                _validationResult.AddErrorMessage(ex.Message);

                return _validationResult;
            }
        }
        public ListaAmarelaViewModel ResgatarInativoByIpen(int ipen)
        {
            try
            {
                var resgatarInativoByIpen = _listaAmarelaRepository
                                                .ResgatarInativoByIpen(ipen);
                var resgatarInativoByIpenMapped = _mapper.Map<ListaAmarelaViewModel>(resgatarInativoByIpen);
                
                return resgatarInativoByIpenMapped;
            }
            catch { throw; }            
        }
        public async Task<ValidationResult> EnableDisableById(string id)
        {
            try
            {
                var listaAmarela = _listaAmarelaRepository
                                    .GetByIdWithIgnoreFilter(Guid.Parse(id));

                if (listaAmarela.IsDeleted)
                {
                    listaAmarela.IsDeleted = false;
                } 
                else
                {
                    listaAmarela.IsDeleted = true;
                }

                _listaAmarelaRepository.Update(listaAmarela);
                await _unitOfWork.CommitAsyncVR();

                return _validationResult;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public IEnumerable<ListaAmarelaViewModel> GetAllByFilterReportPrevisaoBeneficio(ListaAmarelaFilterReportPrevisaoBeneficioViewModel listaAmarelaFilterReportPrevisaoBeneficioViewModel)
        {
            var listasAmarela = new List<ListaAmarela>();

            var regimeMapped = 
                    listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime != null ? (DetentoRegimeEnum)Enum.Parse(typeof(DetentoRegimeEnum), listaAmarelaFilterReportPrevisaoBeneficioViewModel.Regime, true) : 0;

            //Filtro 1 - Possui regime + data previsão benefício
            if (regimeMapped != 0 && 
                    listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio != null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeDataPrevisaoBeneficio(regimeMapped, 
                                                                         Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio),
                                                                         Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioFim)).ToList();
            }
            //Filtro 2 - Possui regime + nenhuma data
            else if (regimeMapped != 0 
                        && listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio == null
                        && listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataSaidaPrevistaInicio == null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegime(regimeMapped).ToList();
            }
            //Filtro 3 - Não possui regime + possui data previsão benefício
            else if (regimeMapped == 0
                && listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio != null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByDataPrevisaoBeneficio(Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioInicio),
                                                                   Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataPrevisaoBeneficioFim)).ToList();
            }
            //Filtro 4 - Possui regime "ALIMENTOS OU PRISAO_TEMPORARIA" + data saída prevista
            else if (regimeMapped == DetentoRegimeEnum.ALIMENTOS || regimeMapped == DetentoRegimeEnum.PRISAO_TEMPORARIA
                        && listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataSaidaPrevistaInicio != null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeAlimentosPrisaoTemporariaDataSaidaPrevista(regimeMapped,
                                                                                                Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataSaidaPrevistaInicio),
                                                                                                Convert.ToDateTime(listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataSaidaPrevistaFim)).ToList();
            }
            //Filtro 5 - Possui regime "ALIMENTOS OU PRISAO_TEMPORARIA" + nenhuma data
            else if (regimeMapped == DetentoRegimeEnum.ALIMENTOS || regimeMapped == DetentoRegimeEnum.PRISAO_TEMPORARIA
                        && listaAmarelaFilterReportPrevisaoBeneficioViewModel.DataSaidaPrevistaInicio == null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeAlimentosPrisaoTemporaria(regimeMapped).ToList();
            }
            //Filtro 6 - Não possui regime + nenhuma data
            else 
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeAll().ToList();
            }

            return _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(listasAmarela);
        }
        public IEnumerable<ListaAmarelaViewModel> GetAllByFilterReportDataIngresso(ListaAmarelaFilterReportDataIngressoViewModel listaAmarelaFilterReportDataIngressoViewModel)
        {
            var listasAmarela = new List<ListaAmarela>();

            var regimeMapped = 
                    listaAmarelaFilterReportDataIngressoViewModel.Regime != null ? (DetentoRegimeEnum)Enum.Parse(typeof(DetentoRegimeEnum), listaAmarelaFilterReportDataIngressoViewModel.Regime, true) : 0;

            //Filtro 1 - Possui regime + data ingresso
            if (regimeMapped != 0 && 
                    listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio != null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeDataIngresso(regimeMapped, 
                                                                Convert.ToDateTime(listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio),
                                                                Convert.ToDateTime(listaAmarelaFilterReportDataIngressoViewModel.DataIngressoFim)).ToList();
            }
            //Filtro 2 - Possui regime + nenhuma data
            else if (regimeMapped != 0 
                        && listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio == null
                        && listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio == null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeToDataIngresso(regimeMapped).ToList();
            }
            //Filtro 3 - Não possui regime + possui data ingresso
            else if (regimeMapped == 0
                && listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio != null)
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByDataIngresso(Convert.ToDateTime(listaAmarelaFilterReportDataIngressoViewModel.DataIngressoInicio),
                                                          Convert.ToDateTime(listaAmarelaFilterReportDataIngressoViewModel.DataIngressoFim)).ToList();
            }
            //Filtro 6 - Não possui regime + nenhuma data
            else 
            {
                listasAmarela = _listaAmarelaRepository
                                    .GetAllByRegimeAllToDataIngresso().ToList();
            }

            return _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(listasAmarela);
        }
        public IEnumerable<ListaAmarelaViewModel> GetAllAguardandoTransferencia()
        {
            var listasAmarelas = _listaAmarelaRepository.GetAllAguardandoTransferencia();
            var listasAmarelasMapped = _mapper.Map<IEnumerable<ListaAmarelaViewModel>>(listasAmarelas);

            return listasAmarelasMapped;
        }
        public TotalizadorCondenacaoTipoViewModel TotalizadorByCondenacaoTipo()
        {
            var listasAmarelas = _listaAmarelaRepository.TotalizadorByCondenacaoTipo();
            var listasAmarelasGroupBy = listasAmarelas.GroupBy(x => x.CondenacaoTipo);
            var tctvm = new TotalizadorCondenacaoTipoViewModel();
            tctvm.CondenacoesTipo = new List<Condenacao>();
            
            foreach (var item in listasAmarelasGroupBy)
            {
                var tmp = new Condenacao()
                {
                    Tipo = item.Key.ToString(),
                    Total = item.Count()
                };

                tctvm.CondenacoesTipo.Add(tmp);
                tctvm.TotalRegistros = tctvm.TotalRegistros + item.Count();
            }

            tctvm.CondenacoesTipo = tctvm.CondenacoesTipo.OrderByDescending(x => x.Total).ToList();
            return tctvm;
        }
        
        public void Dispose()
        {
            _listaAmarelaRepository.Dispose();
        }
    }
}