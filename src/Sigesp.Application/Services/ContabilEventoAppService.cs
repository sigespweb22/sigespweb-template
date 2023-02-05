
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Services
{
    public class ContabilEventoAppService : IContabilEventoAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IContabilEventoRepository _contabilEventoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContabilEventoAppService(ValidationResult validationResult,
                                        IContabilEventoRepository contabilEventoRepository,
                                        IUnitOfWork unitOfWork, 
                                        IMapper mapper)
        {
            _validationResult = validationResult;
            _contabilEventoRepository = contabilEventoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ContabilEventoViewModel> GetById(Guid id)
        {
            var contabilEventoMapped = _mapper
                                        .Map<ContabilEventoViewModel>
                                            (_contabilEventoRepository.GetById(id));

            return Task.Run(() => contabilEventoMapped);
        }
        
        public IEnumerable<ContabilEventoViewModel> GetAll()
        {
            var contabilEventosMapped = _mapper
                                            .Map<IEnumerable<ContabilEventoViewModel>>(
                                                    _contabilEventoRepository.GetAll());

            return contabilEventosMapped;
        }
        
        public async Task<IEnumerable<ContabilEventoViewModel>> GetAllAsync()
        {
            var contabilEventos = await _contabilEventoRepository
                                        .GetAllAsync();

            var contabilEventosMapped = _mapper
                                            .Map<IEnumerable<ContabilEventoViewModel>>
                                            (contabilEventos);
            
            return contabilEventosMapped;
        }
        
        public Task<ValidationResult> Add(ContabilEventoViewModel contabilEventoViewModel)
        {
            var contabilEventoMapped = _mapper
                                    .Map<ContabilEvento>(contabilEventoViewModel);
            
            // //Não permite efetuar lançamento em conta corrente não ativa
            // if (contaCorrente.Status != ContaCorrenteStatusEnum.ATIVA.ToString())
            // {
            //     _validationResult.AddErrorMessage("Conta corrente do colaborador não está ativa, portanto, não é possível efetuar o lançamento.");
            //     return _validationResult;
            // }

            _contabilEventoRepository.Add(contabilEventoMapped);
            _unitOfWork.Commit();
        
            return Task.Run(() => _validationResult);
        }
        
        public Task<ValidationResult> Update(ContabilEventoViewModel contabilEventoViewModel)
        {
            var contabilEvento = _contabilEventoRepository
                                            .GetById((Guid) contabilEventoViewModel.Id);
            
            //Em caso de mudança de status e o status foi passado para liquidado
            //atualizo a data da mudança de status e a data da liquidação do lançamento
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lançamento 'LIQUIDADO' ou 'CANCELADO' não pode ser atualizado."); 
            //     return _validationResult;
            // }

            var contabilEventoMapped = _mapper
                                            .Map<ContabilEventoViewModel, ContabilEvento>(contabilEventoViewModel, contabilEvento);

            _contabilEventoRepository.Update(contabilEventoMapped);
            _unitOfWork.Commit();
        
            return Task.Run(() => _validationResult);
        }

        public Task<ValidationResult> Remove(Guid id)
        {
            var contabilEventoId = _contabilEventoRepository
                                        .GetById((Guid) id);

            // //Não permitir deletar lançamento 'LIQUIDADO' ou 'CANCELADO'  
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lançamento 'LIQUIDADO' ou 'CANCELADO' não pode ser deletado."); 
            //     return _validationResult;
            // }

            _contabilEventoRepository.Remove(id);
            _unitOfWork.Commit();

            return Task.Run(() => _validationResult);
        }

        public int GetTotalActiveRecords()
        {
            var total = _contabilEventoRepository.GetTotalActiveRecords();
            return total;
        }

        public async Task<DataTableServerSideResultViewModel<ContabilEventoViewModel>> GetAllWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var contabilEventos = await _contabilEventoRepository
                                                    .GetAllWithDataTableResultAsync(request);

            var contabilEventosMapped = new DataTableServerSideResultViewModel<ContabilEventoViewModel>();
            contabilEventosMapped.Data = new List<ContabilEventoViewModel>();

            foreach (var contabilEvento in contabilEventos.Data)
            {
                var tmp = new ContabilEventoViewModel {
                    Id = contabilEvento.Id,
                    Codigo = contabilEvento.Codigo,
                    Especificacao = contabilEvento.Especificacao
                };

                contabilEventosMapped.Data.Add(tmp);
            }

            contabilEventosMapped.Draw = contabilEventos.Draw;
            contabilEventosMapped.RecordsFiltered = contabilEventos._iRecordsDisplay;
            contabilEventosMapped.RecordsTotal = contabilEventos._iRecordsTotal;
            contabilEventosMapped.Success = true;

            return contabilEventosMapped;
        }

        public void Dispose()
        {
            _contabilEventoRepository.Dispose();
        }
    }
}