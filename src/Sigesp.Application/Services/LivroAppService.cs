using System.ComponentModel;
using System.Dynamic;
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
using Sigesp.Domain.Models.DataTable;
using Sigesp.Application.ViewModels.Requests;
using System.Web;
using System.Text;
using Sigesp.Infra.Data.Extensions;

namespace Sigesp.Application.Services
{
    public class LivroAppService : ILivroAppService
    {
        private readonly ValidationResult _validationResult;
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroGeneroRepository _livroGeneroRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAlunoLeituraRepository _alRepository;
        private readonly IAlunoLeitorRepository _alunoLeitorRepository;
        private readonly ITenantRepository _tenantRepository;

        public LivroAppService(ValidationResult validationResult,
                                ILivroRepository livroRepository, 
                                ILivroAutorRepository livroAutorRepository, 
                                ILivroGeneroRepository livroGeneroRepository, 
                                IUnitOfWork unitOfWork, IMapper mapper,
                                IAlunoLeituraRepository alRepository,
                                IAlunoLeitorRepository alunoLeitorRepository,
                                ITenantRepository tenantRepository)
        {
            _validationResult = validationResult;
            _livroRepository = livroRepository;
            _livroAutorRepository = livroAutorRepository;
            _livroGeneroRepository = livroGeneroRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _alRepository = alRepository;
            _alunoLeitorRepository = alunoLeitorRepository;
            _tenantRepository = tenantRepository;
        }

        public IEnumerable<LivroViewModel> GetAllDisponiveis(int ipen)
        {
            try
            {
                var livros = _livroRepository
                                .GetAllDisponiveis()
                                .ToList();
                
                IEnumerable<LivroViewModel> livrosMapped = new List<LivroViewModel>();

                if (livros.Count() <= 0)
                    return livrosMapped;

                var leituras = _alRepository.GetAllByIpen(ipen);
                var leitorGenero = leituras.Count() > 0 ? leituras
                                                                .FirstOrDefault()
                                                                .AlunoLeitor
                                                                .LivroGenero.Nome : _alunoLeitorRepository
                                                                                        .GetGeneroByIpen(ipen);
                
                if (leitorGenero.IsNullOrEmpty())
                    throw new Exception("Gênero de leitura do leitor requerido.");

                //1º Filtro - LEITURAS - Excluo todos os livros já lidos pelo leitor
                if (leituras.Count() > 0)
                {
                    foreach (var leitura in leituras)
                    {
                        var idLivro = leitura.Livro.Id;
                        var tituloLivro = leitura.Livro.Titulo;

                        var findLivro = livros.Where(x => x.Id == idLivro || 
                                                     x.Titulo.StartsWith(tituloLivro) &&
                                                     x.Titulo.EndsWith(tituloLivro));

                        foreach (var item in findLivro.ToList())
                        {
                            livros.Remove(item);
                        }
                    }
                }

                //2º Filtro - LIVRO GÊNERO - Excluo todos os livros que não são do
                //gênero de leitura do leitor
                foreach (var item in livros.ToList())
                {
                    if (!item.LivroGenero.Nome.Equals(leitorGenero))
                        livros.Remove(item);
                }

                livrosMapped = _mapper.Map<IEnumerable<LivroViewModel>>(livros);
                return livrosMapped.OrderBy(x => x.Titulo);
            }
            catch { throw; }
        }
        public async Task<ValidationResult> AddAsync(LivroViewModel livroViewModel)
        {
            #region Required validations
            if (livroViewModel.Localizacao == null 
                    || livroViewModel.Localizacao == "")
            {
                _validationResult.AddErrorMessage("Localização requerida.");
                return _validationResult;
            }

            if (livroViewModel.LivroAutorNome == null 
                || livroViewModel.LivroAutorNome == "")
            {
                _validationResult.AddErrorMessage("Autor requerido.");
                return _validationResult;
            }

            if (livroViewModel.LivroGeneroNome == null 
                || livroViewModel.LivroGeneroNome == "")
            {
                _validationResult.AddErrorMessage("Gênero requerido.");
                return _validationResult;
            }
            #endregion
            
            #region Tenancy resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            #endregion

            #region Exists validations
            bool alreadyLocalizacaoAsync;
            try
            {
                alreadyLocalizacaoAsync = await AlreadyLocalizacaoAsync((Guid) tenantId, 
                                                                         Int64.Parse(livroViewModel.Localizacao), null);
            }
            catch{ throw; }
            if (alreadyLocalizacaoAsync)
            {
                _validationResult.AddErrorMessage("Localização informada já está em uso.");
                return _validationResult;
            }
            #endregion

            #region Mapper and get foreigns
            var livro = _mapper.Map<Livro>(livroViewModel);
            livro.TenantId = (Guid)tenantId;
            livro.LivroAutorId = _livroAutorRepository
                                    .GetIdFromPropertyAny("Nome", livroViewModel.LivroAutorNome);
            livro.LivroGeneroId = _livroGeneroRepository
                                    .GetIdFromPropertyAny("Nome", livroViewModel.LivroGeneroNome);
            #endregion

            #region Persistence
            try
            {
                _livroRepository.Add(livro);
            }
            catch { throw; }
            #endregion

            #region Commit
            try
            {
                _unitOfWork.Commit();
            }
            catch { throw; }
            #endregion

            return _validationResult;
        }
        public ValidationResult Remove(Guid id)
        {   
            try
            {
                _livroRepository.Remove(id);
                _unitOfWork.Commit();

                return _validationResult;
            }
            catch { throw; }
        }
        public async Task<ValidationResult> UpdateAsync(LivroViewModel livroViewModel)
        {
            try
            {
                #region Required validations
                if (livroViewModel.Localizacao == null 
                    || livroViewModel.Localizacao == "")
                {
                    _validationResult.AddErrorMessage("Localização requerida.");
                    return _validationResult;
                }

                if (livroViewModel.LivroAutorNome == null 
                    || livroViewModel.LivroAutorNome == "")
                {
                    _validationResult.AddErrorMessage("Autor requerido.");
                    return _validationResult;
                }

                if (livroViewModel.LivroGeneroNome == null 
                    || livroViewModel.LivroGeneroNome == "")
                {
                    _validationResult.AddErrorMessage("Gênero requerido.");
                    return _validationResult;
                }
                #endregion

                #region Tenancy resolve
                var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
                #endregion

                #region Already validations
                bool alreadyLocalizacaoAsync;
                try
                {
                    alreadyLocalizacaoAsync = await AlreadyLocalizacaoAsync((Guid) tenantId, Int64.Parse(livroViewModel.Localizacao),
                                                                            livroViewModel.Id);
                }
                catch { throw; }
                if (alreadyLocalizacaoAsync)
                {
                    _validationResult.AddErrorMessage("Localização informada já está em uso.");
                    return _validationResult;
                }
                #endregion

                var livro = _livroRepository
                                .GetAtivoInativoById((Guid) livroViewModel.Id);
                var livroMapped = _mapper
                                    .Map<LivroViewModel, Livro>(livroViewModel, livro);
            
                livro.TenantId = (Guid)tenantId;
                livro.LivroAutorId = _livroAutorRepository
                                        .GetIdFromPropertyAny("Nome", livroViewModel.LivroAutorNome);
                livro.LivroGeneroId = _livroGeneroRepository
                                        .GetIdFromPropertyAny("Nome", livroViewModel.LivroGeneroNome);

                _livroRepository.Update(livroMapped);
                
                _unitOfWork.Commit();    

                return _validationResult;
            }
            catch { throw; }            
        }
        public string GetNextLocalizacao()
        {
            var maxLocalizacao = _livroRepository.GetNextLocalizacao();         
                
            return maxLocalizacao.ToString();
        }
        public async Task<DataTableServerSideResult<LivroViewModel>> GetWithDataTableResultAsync(DataTableServerSideRequest request)
        {
            var livros = await _livroRepository
                                            .GetWithDataTableResultAsync(request);

            var livroMapped = new DataTableServerSideResult<LivroViewModel>();
            livroMapped.Data = new List<LivroViewModel>();

            foreach (var item in livros.Data.ToList())
            {
                var tmp = new LivroViewModel {
                    Id = item.Id,
                    Titulo = item.Titulo,
                    Localizacao = item.Localizacao.ToString(),
                    Propriedade = item.Propriedade,
                    LivroAutorNome = item.LivroAutor.Nome,
                    LivroGeneroNome = item.LivroGenero.Nome,
                    IsDeleted = item.IsDeleted,
                    IsDisponivel = item.IsDisponivel
                };

                livroMapped.Data.Add(tmp);
            }

            livroMapped.Draw = livros.Draw;
            livroMapped._iRecordsDisplay = livros._iRecordsDisplay;
            livroMapped._iRecordsTotal = livros._iRecordsTotal;

            return livroMapped;
        }
        public async Task<bool> AlreadyLocalizacaoAsync(Guid tenantId, Int64 localizacao, Guid? id)
        {
            bool already;
            try
            {
                already =await  _livroRepository
                                    .AlreadyLocalizacaoAsync(tenantId, localizacao, id);
            }
            catch { throw; }
            return already;
        }
        public Int64 GetTotalAtivos()
        {
            var ativos = _livroRepository.GetTotalAtivos();
            return ativos;
        }
        public Int64 GetTotalInativos()
        {
            var inativos = _livroRepository.GetTotalInativos();
            return inativos;
        }
        public Int64 GetTotalDisponiveis()
        {
            var disponiveis = _livroRepository.GetTotalDisponiveis();
            return disponiveis;
        }
        public Int64 GetTotalIndisponiveis()
        {
            var indisponiveis = _livroRepository.GetTotalIndisponiveis();
            return indisponiveis;
        }
        public async Task<ValidationResult> ColocarEstanteAsync(ColocarEstanteRequestViewModel 
                                                                colocarEstanteRequestViewModel)
        {
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            if (!String.IsNullOrEmpty(colocarEstanteRequestViewModel.Localizacao))
            {
                var livro = new Livro();
                try
                {
                    livro = await _livroRepository
                                            .GetByLocalizacaoAsync((Guid) tenantId, Int64.Parse(colocarEstanteRequestViewModel.Localizacao));
                }
                catch { throw; }
                
                if (livro != null)
                {
                    if (!livro.IsDisponivel)
                    {
                        livro.IsDisponivel = true;
                        _livroRepository.Update(livro);
                    }
                    else
                    {
                        _validationResult
                                    .AddErrorMessage("O livro que você está tentando colocar na estante já está disponível.");
                        return _validationResult;
                    }
                }
                else
                {
                    _validationResult
                                    .AddErrorMessage("Nenhum livro encontrado para disponibilizar com a localização informada.");
                        return _validationResult;
                }
            }
            else
            {
                IEnumerable<Livro> livros = new List<Livro>();
                if (colocarEstanteRequestViewModel.Todos)
                {
                    try
                    {
                        livros = await _livroRepository
                                            .GetAllAtivoInativoAsync((Guid) tenantId);
                    }
                    catch { throw; }
                    
                    if (livros.Count() > 0)
                    {
                        foreach (var livro in livros.ToList())
                        {
                            livro.IsDisponivel = true;
                            _livroRepository.Update(livro);
                        }
                    }
                }
            }

            _unitOfWork.Commit();
            return _validationResult;
            
        }
        public Int64 GetTotalWithIgnoreQueryFilter()
        {
            var total = _livroRepository.GetTotalWithIgnoreQueryFilter();
            return total;
        }
        public Int64 GetLocalizacao(Guid id)
        {
            var result = _livroRepository.GetLocalizacao(id);
            return result;
        }
        public ValidationResult GetAllDisponiveisNaoLidosByIpenAndGenero(LivrosParaEdicaoRequestViewModel
                                                                         livrosParaEdicaoRequestViewModel)
        {
            try
            {
                if (livrosParaEdicaoRequestViewModel == null)
                {
                    _validationResult.AddErrorMessage("Parâmetros requeridos.");
                    return _validationResult;
                }
                
                if (livrosParaEdicaoRequestViewModel.AlunoLeituraId.IsNullOrEmpty()
                    || livrosParaEdicaoRequestViewModel.Ipen.IsNullOrEmpty())
                {
                    _validationResult.AddErrorMessage("Id da leitura e Ipen requeridos.");
                    return _validationResult;
                }
                
                var idLeitura = Guid.Parse(livrosParaEdicaoRequestViewModel.AlunoLeituraId);
                var ipen = Convert.ToInt32(livrosParaEdicaoRequestViewModel.Ipen);

                var leitor = _alunoLeitorRepository
                                .GetByDetentoIpen(ipen);
                if (leitor == null)
                {
                    _validationResult.AddErrorMessage("Nenhum leitor encontrado com o IPEN informado.");
                    return _validationResult;
                }

                var livrosMapped = new List<LivroViewModel>();
                var livros = _livroRepository
                                .GetAllDisponiveis(leitor.LivroGenero.Nome)
                                .ToList();
                
                if (livros.Count() <= 0)
                {
                    _validationResult.AddObject(livrosMapped);
                    return _validationResult;
                }

                var leituras = _alRepository.GetAllByIpen(ipen);
                //1º Filtro - LEITURAS - Excluo todos os livros já lidos pelo leitor
                if (leituras.Count() > 0)
                {
                    foreach (var leitura in leituras)
                    {
                        var idLivro = leitura.Livro.Id;
                        var tituloLivro = leitura.Livro.Titulo;

                        var findLivro = livros.Where(x => x.Id == idLivro || 
                                                     x.Titulo.StartsWith(tituloLivro) &&
                                                     x.Titulo.EndsWith(tituloLivro));

                        foreach (var item in findLivro.ToList())
                        {
                            livros.Remove(item);
                        }
                    }
                }

                //2º Filtro - LIVRO GÊNERO - Excluo todos os livros que não são do
                //gênero de leitura do leitor
                foreach (var item in livros.ToList())
                {
                    if (!item.LivroGenero.Nome.Equals(leitor.LivroGenero.Nome))
                        livros.Remove(item);
                }

                var livroLeitura = _alRepository.GetLivroLeitura(idLeitura);
                if (livroLeitura == null)
                {
                    _validationResult.AddErrorMessage("Problemas ao obter o livro da leitura, para retornar uma lista de livros para edição. Tente novamente, caso o problema persista, informe a equipe técnica de suporte do sistema.");
                    return _validationResult;
                }

                var lvFind = livros.Any(x => x.Id == livroLeitura.Id);
                if (!lvFind)
                {
                    livros.Add(livroLeitura);
                }
                else
                {
                    var indiceItemLocalizado = livros.IndexOf(livroLeitura);
                    var copiaItemDaLista = livros[indiceItemLocalizado];

                    livros.RemoveAt(indiceItemLocalizado);
                    livros.Add(copiaItemDaLista);
                }

                livrosMapped = _mapper.Map<IEnumerable<LivroViewModel>>(livros).ToList();

                _validationResult.AddObject(livrosMapped);
                return _validationResult;              
            }
            catch { throw; }
        }
        public async Task<IEnumerable<LivroViewModel>> GetAllWithVRAsync()
        {
            IEnumerable<Livro> livros = new List<Livro>();
            
            #region Tenancy resolve
            var tenantId = StringHelpers.ExtractTenantId(await _tenantRepository.GetTenantIdAsync());
            #endregion

            #region Get livros
            try
            {
                livros = await _livroRepository.GetAllAsync((Guid) tenantId);
            }
            catch { throw; }
            #endregion
            
            IEnumerable<LivroViewModel> livrosMapped = new List<LivroViewModel>();
            #region Mapped
            livrosMapped = _mapper.Map<IEnumerable<LivroViewModel>>(livros);
            #endregion
            return livrosMapped;
        }

        public void Dispose()
        {
            _livroRepository.Dispose();
        }
    }
}