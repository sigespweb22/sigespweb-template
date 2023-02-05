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
    public class AndamentoPenalAppService : IAndamentoPenalAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IAndamentoPenalRepository _andamentoPenalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDetentoRepository _detentoRepository;

        public AndamentoPenalAppService(ValidationResult validationResult,
                                        IAndamentoPenalRepository andamentoPenalRepository, 
                                        IUnitOfWork unitOfWork, 
                                        IMapper mapper,
                                        IDetentoRepository detentoRepository)
        {
            _validationResult = validationResult;
            _andamentoPenalRepository = andamentoPenalRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _detentoRepository = detentoRepository;
        }

        public AndamentoPenalViewModel GetByIdWithInclude(string id)
        {
            try
            {
                var andamentoPenal = _andamentoPenalRepository.GetByIdWithInclude(Guid.Parse(id));
                var andamentoPenalMapped = _mapper.Map<AndamentoPenalViewModel>(andamentoPenal);
                
                return andamentoPenalMapped;
            }
            catch { throw; }            
        }

        public async Task<DataTableServerSideResult<AndamentoPenalViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var andamentoPenal = await _andamentoPenalRepository
                                                    .GetWithDataTableResultAsync(request);

            var andamentoPenalMapped = new DataTableServerSideResult<AndamentoPenalViewModel>();
            andamentoPenalMapped.Data = new List<AndamentoPenalViewModel>();

            foreach (var item in andamentoPenal.Data.ToList())
            {
                var tmp = new AndamentoPenalViewModel {
                    Id = item.Id,
                    DataEventoPrincipal = item.DataEventoPrincipal.ToString("yyyy-MM-dd"),
                    Status = item.Status.ToString("yyyy-MM-dd"),
                    Historico = item.Historico,
                    Observacao = item.Observacao,
                    Pec = item.Pec,
                    IsDeleted = item.IsDeleted,
                    DetentoId = item.Detento.Id,
                    DetentoNome = item.Detento.Nome,
                    DetentoGaleria = item.Detento.Galeria,
                    DetentoCela = item.Detento.Cela.ToString(),
                    DetentoIpen = item.Detento.Ipen.ToString(),
                    DetentoRegime = item.Detento.Regime.ToString()
                };

                andamentoPenalMapped.Data.Add(tmp);
            }

            andamentoPenalMapped.Draw = andamentoPenal.Draw;
            andamentoPenalMapped._iRecordsDisplay = andamentoPenal._iRecordsDisplay;
            andamentoPenalMapped._iRecordsTotal = andamentoPenal._iRecordsTotal;

            return andamentoPenalMapped;
        }
        public AndamentoPenalViewModel GetByDetentoNome(string nome)
        {
            var andamentoPenal = _andamentoPenalRepository
                                    .GetByDetentoNome(nome);
            var andamentoPenalMapped = _mapper.Map<AndamentoPenalViewModel>(andamentoPenal);

            return andamentoPenalMapped;
        }
        public AndamentoPenalViewModel GetByDetentoIpen(string ipen)
        {
            var andamentoPenal = _andamentoPenalRepository
                                .GetByDetentoIpen(Convert.ToInt32(ipen));
            var andamentoPenalMapped = _mapper.Map<AndamentoPenalViewModel>(andamentoPenal);

            return andamentoPenalMapped;
        }
        public async Task<IEnumerable<AndamentoPenalViewModel>> GetAllAsync()
        {
            var andamentoPenal = _mapper.Map<IEnumerable<AndamentoPenalViewModel>>(
                                            await _andamentoPenalRepository
                                                        .GetAllOnlyIsDeletedTrue());
            return andamentoPenal;
        }
        public IEnumerable<AndamentoPenalViewModel> GetAll()
        {
            var andamentoPenal = _mapper.Map<IEnumerable<AndamentoPenalViewModel>>(
                                    _andamentoPenalRepository.GetAll());
                                    
            return andamentoPenal;
        }
        public IEnumerable<AndamentoPenalViewModel> GetAllWithInclude()
        {
            var andamentoPenal = _andamentoPenalRepository
                                    .GetAllWithInclude();
            var andamentoPenalMapped = _mapper.Map<IEnumerable<AndamentoPenalViewModel>>(andamentoPenal);
                                    
            return andamentoPenalMapped;
        }
        public IEnumerable<AndamentoPenalViewModel> GetAllWithIgnoreFilter()
        {
            var andamentoPenal = _mapper.Map<IEnumerable<AndamentoPenalViewModel>>(
                                    _andamentoPenalRepository
                                        .GetAllWithIgnoreFilter());
                                    
            return andamentoPenal;
        }
        public ValidationResult Add(AndamentoPenalViewModel andamentoPenalViewModel)
        {
            try
            {
                var detento = _detentoRepository
                                    .GetById((Guid) andamentoPenalViewModel.DetentoId);
            
                if (detento == null)
                {
                    _validationResult.AddErrorMessage("Nenhum detento encontrado com o id detento informado.");
                    return _validationResult;
                }

                //Verifico se já há algum registro desativado no andamento penal com o detento informado
                var detentoAndamentoPenal = _andamentoPenalRepository
                                                    .GetByDetentoId((Guid) detento.Id);

                if (detentoAndamentoPenal == null)
                {
                    var andamentoPenalMapped = _mapper
                                                 .Map<AndamentoPenal>(andamentoPenalViewModel);
                    andamentoPenalMapped.Detento = detento;

                    _andamentoPenalRepository.Add(andamentoPenalMapped);
                }
                else
                {
                    if (!detentoAndamentoPenal.IsDeleted)
                    {
                        _validationResult.AddErrorMessage("Já existe um registro ativo no andamento penal para o detento informado.");
                        return _validationResult;
                    }
                    else
                    {
                        detentoAndamentoPenal.IsDeleted = false;
                        andamentoPenalViewModel.DetentoId = detentoAndamentoPenal.DetentoId;
                        andamentoPenalViewModel.Id = detentoAndamentoPenal.Id;

                        var apMapper = _mapper.Map<AndamentoPenalViewModel, AndamentoPenal>
                                                    (andamentoPenalViewModel, detentoAndamentoPenal);

                        _andamentoPenalRepository.Update(apMapper);
                    }
                }

                _unitOfWork.Commit();
                return _validationResult;
            }
            catch { throw; }
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

            _andamentoPenalRepository.Remove(id);
            _unitOfWork.Commit();

            return _validationResult;
        }
        public ValidationResult Update(AndamentoPenalViewModel andamentoPenalViewModel)
        {
            try
            {
                var apDB = _andamentoPenalRepository
                                .GetByIdWithouIncludes((Guid) andamentoPenalViewModel.Id);

                andamentoPenalViewModel.DetentoId = apDB.DetentoId;
                var apMapper = _mapper.Map<AndamentoPenalViewModel, AndamentoPenal>
                                                (andamentoPenalViewModel, apDB);

                _andamentoPenalRepository.Update(apMapper);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<ValidationResult> EnableDisableById(string id)
        {
            try
            {
                var ap = _andamentoPenalRepository
                                    .GetByIdWithIgnoreFilter(Guid.Parse(id));

                if (ap.IsDeleted)
                {
                    ap.IsDeleted = false;
                } 
                else
                {
                    ap.IsDeleted = true;
                }

                _andamentoPenalRepository.Update(ap);
                await _unitOfWork.CommitAsyncVR();

                return _validationResult;
            }
            catch { throw; }
        }
        public Int64 GetTotalByStatus(AndamentoPenalStatusEnum status)
        {
            try
            {
                // var statusMapped = (AndamentoPenalStatusEnum)Enum.Parse(typeof(AndamentoPenalStatusEnum), status);
                var total = _andamentoPenalRepository.GetTotalByStatus(status);
                
                return total;
            }
            catch { throw; }            
        }
        public Int64 GetTotal()
        {
            try
            {
                var total = _andamentoPenalRepository.GetTotal();
                return total;
            }
            catch { throw; }
        }
        public bool AlreadyAtivoByIpen(int ipen)
        {
            var alreadyAtivoByIpen = _andamentoPenalRepository
                                        .AlreadyAtivoByIpen(ipen);
            return alreadyAtivoByIpen;
        }
        public AndamentoPenalViewModel RescueInactiveByIpen(int ipen)
        {
            try
            {
                var rescueInactiveByIpen = _andamentoPenalRepository
                                                .RescueInactiveByIpen(ipen);
                var rescueInactiveByIpenMapped = _mapper.Map<AndamentoPenalViewModel>(rescueInactiveByIpen);
                
                return rescueInactiveByIpenMapped;
            }
            catch { throw; }
        }

        public void Dispose()
        {
            _andamentoPenalRepository.Dispose();
        }
    }
}