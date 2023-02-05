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
using Sigesp.Application.ViewModels.Reports;
using Sigesp.Infra.Data.Context;

namespace Sigesp.Application.Services
{
    public class DetentoSaidaTemporariaAppService : IDetentoSaidaTemporariaAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IDetentoSaidaTemporariaRepository _detentoSTRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DetentoSaidaTemporariaAppService(ValidationResult validationResult,
                                                IDetentoSaidaTemporariaRepository detentoSTRepository,
                                                IListaAmarelaRepository listaAmarelaRepository,
                                                IUnitOfWork unitOfWork, IMapper mapper)
        {
            _validationResult = validationResult;
            _detentoSTRepository = detentoSTRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DetentoSaidaTemporariaViewModel> GetAllByFilterReportSaidasPrevistas(ListaAmarelaFilterReportSaidasPrevistasViewModel listaAmarelaFilterReportSaidasPrevistasViewModel)
        {
            var detentos = new List<Detento>();

            if (listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTInicio == null)
                listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTInicio = "0001-01-01 00:00:00";

            if (listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTFim == null)
                listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTFim = "0001-01-01 00:00:00";

            var detentosST = _detentoSTRepository
                                .GetAllByFilterReportSaidasPrevistas(Convert.ToDateTime(listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTInicio),
                                                                     Convert.ToDateTime(listaAmarelaFilterReportSaidasPrevistasViewModel.DataSaidaPrevistaSTFim),
                                                                     listaAmarelaFilterReportSaidasPrevistasViewModel.OpcaoOrdenacaoSelect2).ToList();

            return _mapper.Map<IEnumerable<DetentoSaidaTemporariaViewModel>>(detentosST);
        }

        
        public void Dispose()
        {
            _detentoSTRepository.Dispose();
        }
    }
}