using AutoMapper;
using Sigesp.Domain.Interfaces;
using Sigesp.Application.Interfaces;

namespace Sigesp.Application.Services
{
    public class ServidorEstadoAppService : IServidorEstadoAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly IServidorEstadoRepository _seRepository;

        public ServidorEstadoAppService(ValidationResult validationResult,
                                               IUnitOfWork unitOfWork, 
                                               IMapper mapper,
                                               ITenantRepository tenantRepository,
                                               IServidorEstadoRepository seRepository)
        {
            _validationResult = validationResult;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _seRepository = seRepository;
        }

        #region Methods multitenancies
        
        #endregion

        #region Methods that are not tenants
        
        #endregion 
        
        public void Dispose()
        {
            _seRepository.Dispose();
        }
    }
}