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
    public class AlunoEnemjaAppService : IAlunoEnemAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IAlunoEnemAppService _alunoEnemRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlunoEnemjaAppService(ValidationResult validationResult,
                                        IAlunoEnemAppService alunoEnemRepository,
                                        IAlunoRepository alunoRepository,
                                        IUnitOfWork unitOfWork, 
                                        IMapper mapper)
        {
            _validationResult = validationResult;
            _alunoEnemRepository = alunoEnemRepository;
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _alunoEnemRepository.Dispose();
        }
    }
}