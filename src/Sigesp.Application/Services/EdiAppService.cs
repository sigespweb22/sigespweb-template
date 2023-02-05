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
using Sigesp.Application.ViewModels.Selects;
using Sigesp.Domain.Enums;
using Sigesp.Application.ViewModels.Detentos;
using Sigesp.Application.ViewModels.Cards;
using Sigesp.Domain.Models.DataTable;

namespace Sigesp.Application.Services
{
    public class EdiAppService : IEdiAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IEdiRepository _ediRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EdiAppService(ValidationResult validationResult,
                            IEdiRepository ediRepository, 
                            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _validationResult = validationResult;
            _ediRepository = ediRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EdiCardViewModel> GetInfoCardsAsync()
        {
            try
            {
                var result = await _ediRepository
                                        .GetInfoCardsAsync();
                if (result == null)
                    throw new Exception("Nenhum registro encontrado para atualizar as informações dos CARDS");

                var resultMapped = new EdiCardViewModel()
                {
                    TotalImportacoes = result.Count(),
                    EmProcessamento = result.Count(x => x.Status == EdiStatusEnum.PROCESSANDO),
                    Processados = result.Count(x => x.Status == EdiStatusEnum.CONCLUIDO)
                };
               
                return resultMapped;
            }
            catch { throw; }
        }

        public async Task<DataTableServerSideResult<EdiViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            try
            {
                var edis = await _ediRepository
                                    .GetWithDataTableResultAsync(request);
                if (edis == null)
                    throw new Exception();
                
                var result = new DataTableServerSideResult<EdiViewModel>();
                var edisMapped = _mapper
                                    .Map<IEnumerable<EdiViewModel>>(edis.Data);
                
                result.Data = edisMapped.ToList();
                result.Draw = edis.Draw;
                result._iRecordsDisplay = edis._iRecordsDisplay;
                result._iRecordsTotal = edis._iRecordsTotal;

                return result;
            }
            catch { throw; }
        }

        public void Dispose()
        {
            _ediRepository.Dispose();
        }
    }
}