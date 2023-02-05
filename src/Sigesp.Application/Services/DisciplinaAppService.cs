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
    public class DisciplinaAppService : IDisciplinaAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DisciplinaAppService(ValidationResult validationResult,
                                    IDisciplinaRepository disciplinaRepository,
                                    IProfessorRepository professorRepository,
                                    IUnitOfWork unitOfWork, 
                                    IMapper mapper)
        {
            _validationResult = validationResult;
            _disciplinaRepository = disciplinaRepository;
            _professorRepository = professorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DisciplinaViewModel> GetAll()
        {
            var disciplinas = _mapper.Map<IEnumerable<DisciplinaViewModel>>(
                                    _disciplinaRepository.GetAll());
            return disciplinas;
        }
        public IEnumerable<DisciplinaViewModel> GetAllWithInclude()
        {
            try
            {
                var disciplinas  = _disciplinaRepository.GetAllWithIncludes();
                var disciplinasMapped = _mapper.Map<IEnumerable<DisciplinaViewModel>>(disciplinas);

                return disciplinasMapped;    
            }
            catch { throw; }
        }
        public async Task<DisciplinaViewModel> GetByIdAsync(string id)
        {
            try
            {
                if (id.IsNullOrEmpty())
                    throw new Exception("Id requerido");

                var disciplina = await _disciplinaRepository.GetByIdAsync(Guid.Parse(id));
                var disciplinaMapped = _mapper.Map<DisciplinaViewModel>(disciplina);
            
                return disciplinaMapped;    
            }
            catch { throw; }
        }
        public ValidationResult Add(DisciplinaViewModel disciplinaViewModel)
        {
            try
            {
                #region Validações campos obrigatórios
                if (disciplinaViewModel.Nome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome disciplina requerido.");
                }

                if (disciplinaViewModel.Fase.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Fase requerida.");
                }

                if (disciplinaViewModel.HoraAula.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Hora aula requerida.");
                }

                if (disciplinaViewModel.CargaHoraria.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Carga horária requerida.");
                }

                if (disciplinaViewModel.Curso.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Curso requerido.");
                }

                if (disciplinaViewModel.ProfessorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Professor requerido.");
                }

                var professorId = _professorRepository.GetIdByNome(disciplinaViewModel.ProfessorNome);
                if (professorId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Nenhum professor encontrado com o nome do professor informado.");
                }

                if (_validationResult.ErrorMessages != null 
                    && _validationResult.ErrorMessages.Any())
                {
                    return _validationResult;
                }
                #endregion Validações campos obrigatórios

                #region Mapeamento do objeto
                var disciplinaMapped = _mapper.Map<Disciplina>(disciplinaViewModel);
                disciplinaMapped.ProfessorId = professorId;

                _disciplinaRepository.Add(disciplinaMapped);
                #endregion Mapeamento do objeto

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult Remove(Guid id)
        {
            try
            {
                _disciplinaRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public ValidationResult Update(DisciplinaViewModel disciplinaViewModel)
        {
            try
            {
                #region Validações campos obrigatórios
                if (disciplinaViewModel.Id == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Id requerido.");
                }

                if (disciplinaViewModel.Nome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Nome disciplina requerido.");
                }

                if (disciplinaViewModel.Fase.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Fase requerida.");
                }

                if (disciplinaViewModel.HoraAula.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Hora aula requerida.");
                }

                if (disciplinaViewModel.CargaHoraria.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Carga horária requerida.");
                }

                if (disciplinaViewModel.Curso.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Curso requerido.");
                }

                if (disciplinaViewModel.ProfessorNome.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Professor requerido.");
                }

                var professorId = _professorRepository.GetIdByNome(disciplinaViewModel.ProfessorNome);
                if (professorId == Guid.Empty)
                {
                    _validationResult.AddErrorMessage("Nenhum professor encontrado com o nome do professor informado.");
                }

                var disciplinaForUpdate = _disciplinaRepository.GetById((Guid) disciplinaViewModel.Id);
                if (disciplinaForUpdate == null)
                {
                    _validationResult.AddErrorMessage("Disciplina não encontrada com o id informado para atualização.");
                }

                if (_validationResult.ErrorMessages != null 
                    && _validationResult.ErrorMessages.Any())
                {
                    return _validationResult;
                }
                #endregion Validações campos obrigatórios

                #region Mapeamento do objeto
                var disciplinaMapped = _mapper
                                        .Map<DisciplinaViewModel, Disciplina>(disciplinaViewModel, disciplinaForUpdate);
                disciplinaForUpdate.ProfessorId = professorId;
                
                _disciplinaRepository.Update(disciplinaForUpdate);
                #endregion Mapeamento do objeto

                #region UnitOfwork - Commit
                _unitOfWork.Commit();
                #endregion

                return _validationResult;
            }
            catch { throw; }
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _disciplinaRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = _disciplinaRepository.GetTotalInativos();
            return inativos;
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _disciplinaRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }

        public void Dispose()
        {
            _disciplinaRepository.Dispose();
        }
    }
}