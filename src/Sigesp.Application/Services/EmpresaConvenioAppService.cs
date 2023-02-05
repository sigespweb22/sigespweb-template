using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;

namespace Sigesp.Application.Services
{
    public class EmpresaConvenioAppService : IEmpresaConvenioAppService
    {
        private readonly IEmpresaConvenioRepository _empresaConvenioRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaConvenioAppService(IEmpresaConvenioRepository empresaConvenioRepository, 
                                            IEmpresaRepository empresaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _empresaConvenioRepository = empresaConvenioRepository;
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmpresaConvenioViewModel> GetById(Guid id)
        {
            var empresaConvenio = _mapper.Map<EmpresaConvenioViewModel>(await _empresaConvenioRepository.GetByIdAsync(id));

            return empresaConvenio;
        }

        public IEnumerable<EmpresaConvenioViewModel> GetAll()
        {
            var empresasConveniosMapper = _mapper.Map<IEnumerable<EmpresaConvenioViewModel>>(
                                                    _empresaConvenioRepository.AsNoTrackingOnlyIsNotDeleted());
            
            return empresasConveniosMapper;
        }
        public async Task<IEnumerable<EmpresaConvenioViewModel>> GetAllAsync()
        {
            // var empresasConveniosDB = await _empresaConvenioRepository.GetAllOnlyIsDeletedTrue();
            var empresasConveniosDB = await _empresaConvenioRepository.GetAllWithIncludeAsync(); 
            var empresasConveniosMapper = _mapper.Map<IEnumerable<EmpresaConvenioViewModel>>(empresasConveniosDB);
            
            return empresasConveniosMapper;
        }
        public IEnumerable<EmpresaConvenioViewModel> GetAllSoftDeleted()
        {
            var empresasConveniosMapper = _mapper.Map<IEnumerable<EmpresaConvenioViewModel>>(
                                                    _empresaConvenioRepository.GetAllSoftDeleted());
            
            return empresasConveniosMapper;
        }
        public void Add(EmpresaConvenioViewModel empresaConvenioViewModel)
        {
            empresaConvenioViewModel.EmpresaId = _empresaRepository.GetIdFromPropertyAny("RazaoSocial", empresaConvenioViewModel.EmpresaRazaoSocial);
            
            var empresaConvenio = _mapper.Map<EmpresaConvenio>(empresaConvenioViewModel);
            
            _empresaConvenioRepository.Add(empresaConvenio);
            _unitOfWork.Commit();
        }
        public void Remove(Guid id)
        {
            _empresaConvenioRepository.Remove(id);
            _unitOfWork.Commit();
        }
        public void Update(EmpresaConvenioViewModel empresaConvenioViewModel)
        {
            var empresaConvenioDB = _empresaConvenioRepository
                                        .GetByIdWithInclude((Guid) empresaConvenioViewModel.Id);

            //Implementação temporária, no futuro implementar via AutoMapper ou um método 
            //genérico no contexto que irá obter todas as foreign keys das entidades envolvidas na operação
            //e atualizá-las caso tenham sido modificadas
            empresaConvenioViewModel.EmpresaId = _empresaRepository.GetIdFromPropertyAny("RazaoSocial", empresaConvenioViewModel.EmpresaRazaoSocial);
            var empresaConvenioMapper = _mapper.Map<EmpresaConvenioViewModel, EmpresaConvenio>(empresaConvenioViewModel, empresaConvenioDB);

            if (empresaConvenioDB.Empresa.Id != empresaConvenioViewModel.EmpresaId)
            {
                empresaConvenioMapper.EmpresaId = empresaConvenioViewModel.EmpresaId;
                empresaConvenioMapper.Empresa = null;
            }

            _empresaConvenioRepository.Update(empresaConvenioMapper);
            _unitOfWork.Commit();
        }

        public EmpresaConvenioViewModel GetByEmpresaCnpj(string cnpj)
        {
            var empresaConvenio = _empresaConvenioRepository.GetByEmpresaCnpj(cnpj);

            return _mapper.Map<EmpresaConvenioViewModel>(empresaConvenio);
        }

        public void Dispose()
        {
            _empresaConvenioRepository.Dispose();
        }
    }
}