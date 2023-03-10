
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
            
            // //N??o permite efetuar lan??amento em conta corrente n??o ativa
            // if (contaCorrente.Status != ContaCorrenteStatusEnum.ATIVA.ToString())
            // {
            //     _validationResult.AddErrorMessage("Conta corrente do colaborador n??o est?? ativa, portanto, n??o ?? poss??vel efetuar o lan??amento.");
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
            
            //Em caso de mudan??a de status e o status foi passado para liquidado
            //atualizo a data da mudan??a de status e a data da liquida????o do lan??amento
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lan??amento 'LIQUIDADO' ou 'CANCELADO' n??o pode ser atualizado."); 
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

            // //N??o permitir deletar lan??amento 'LIQUIDADO' ou 'CANCELADO'  
            // if (lancamentoDB.Status == LancamentoStatusEnum.LIQUIDADO ||
            //      lancamentoDB.Status == LancamentoStatusEnum.CANCELADO)
            // {
            //     _validationResult.AddErrorMessage("Lan??amento 'LIQUIDADO' ou 'CANCELADO' n??o pode ser deletado."); 
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