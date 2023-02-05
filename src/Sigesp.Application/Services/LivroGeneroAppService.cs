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
using System.Numerics;

namespace Sigesp.Application.Services
{
    public class LivroGeneroAppService : ILivroGeneroAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly ILivroGeneroRepository _livroGeneroRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LivroGeneroAppService(ValidationResult validationResult,
                                ILivroGeneroRepository livroGeneroRepository, 
                                IUnitOfWork unitOfWork, IMapper mapper)
        {
            _validationResult = validationResult;
            _livroGeneroRepository = livroGeneroRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LivroGeneroViewModel> GetByIdAsync(int id)
        {
            try
            {
                var genero = await _livroGeneroRepository.GetByIdAsync(id);
                var generoMapped = _mapper.Map<LivroGeneroViewModel>(genero);
            
                return generoMapped;    
            }
            catch { throw; }
        }
        public async Task<LivroGeneroViewModel> GetByIdAsyncIncludes(int id)
        {
            try
            {
                var genero = await _livroGeneroRepository.GetByIdAsync(id);
                var generoMapped = _mapper.Map<LivroGeneroViewModel>(genero);
            
                return generoMapped;    
            }
            catch { throw; }
        }
        public LivroGeneroViewModel GetByIdIncludes(string id)
        {
            try
            {
                var genero = _livroGeneroRepository.GetByIdIncludes(Guid.Parse(id));
                var generoMapped = _mapper.Map<LivroGeneroViewModel>(genero);
            
                return generoMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<LivroGeneroViewModel>> GetAllAsync()
        {
            try
            {
                var generos = await _livroGeneroRepository.GetAllAsync();
                var generosMapped = _mapper.Map<IEnumerable<LivroGeneroViewModel>>(generos);
            
                return generosMapped;    
            }
            catch { throw; }
        }
        public async Task<IEnumerable<LivroGeneroViewModel>> GetAllAsyncIncludes()
        {
            try
            {
                var generos  = await _livroGeneroRepository.GetAllAsync();
                var generosMapped = _mapper.Map<IEnumerable<LivroGeneroViewModel>>(generos);

                return generosMapped;    
            }
            catch { throw; }
        }
        public IEnumerable<LivroGeneroViewModel> GetAll()
        {
            try
            {
                var generos = _livroGeneroRepository.GetAll();
                var generosMapped = _mapper.Map<IEnumerable<LivroGeneroViewModel>>(generos);
                return generosMapped;    
            }
            catch { throw; }
        }
        public ValidationResult Add(LivroGeneroViewModel livroGeneroViewModel)
        {
            try
            {
                if (_livroGeneroRepository.AlreadyEqualsNome(livroGeneroViewModel.Nome))
                {
                    _validationResult.AddErrorMessage("Gênero já cadastrado e ativo com nome informado.");
                    return _validationResult;
                };

                var genero = _mapper.Map<LivroGenero>(livroGeneroViewModel);

                _livroGeneroRepository.Add(genero);
                _unitOfWork.Commit();
        
                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _livroGeneroRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult Update(LivroGeneroViewModel livroGeneroViewModel)
        {
            try
            {
                var genero = _livroGeneroRepository.GetById((Guid) livroGeneroViewModel.Id);
                var generoMapped = _mapper.Map<LivroGeneroViewModel, LivroGenero>(livroGeneroViewModel, genero);
            
                _livroGeneroRepository.Update(generoMapped);
                
                _unitOfWork.Commit();    

                return _validationResult;
            }
            catch { throw; }            
        }

        public Int64 GetTotalAtivos()
        {
            var ativos = _livroGeneroRepository.GetTotalAtivos();
            return ativos;
        }

        public Int64 GetTotalInativos()
        {
            var inativos = _livroGeneroRepository.GetTotalInativos();
            return inativos;
        }

        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _livroGeneroRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }

        public void Dispose()
        {
            _livroGeneroRepository.Dispose();
        }
    }
}