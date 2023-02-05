using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sigesp.Application.Interfaces;
using Sigesp.Application.ViewModels;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;

namespace Sigesp.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly SigespDbContext _sigespDbContext;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaAppService(IEmpresaRepository empresaRepository, 
                                IUnitOfWork unitOfWork, IMapper mapper,
                                SigespDbContext sigespDbContext)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sigespDbContext = sigespDbContext;
        }

        public async Task<EmpresaViewModel> GetById(int id)
        {
            var detento = _mapper.Map<EmpresaViewModel>(await _empresaRepository.GetByIdAsync(id));

            return detento;
        }
        public void Add(EmpresaViewModel empresaViewModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaViewModel);
            
            _empresaRepository.Add(empresa);
            _unitOfWork.Commit();
        }
        public void Update(EmpresaViewModel empresaViewModel)
        {
            // var strSQL = "SELECT * FROM public.\"Empresas\"" +
            //             " WHERE \"Id\"=" + "\'" + empresaViewModel.Id + "\'" + ";";

            // using var tx = _sigespDbContext.Database.BeginTransactionAsync();
            // var ct = CancellationToken.None;

            // var empresa = _sigespDbContext.QueryFirst<Empresa>(ct, strSQL);
            // tx.Result.Commit();
            //var empresa = _sigespDbContext.Empresas.FirstAsync(x => x.Id == empresaViewModel.Id);

            var empresaMapper = _mapper.Map<EmpresaViewModel, Empresa>(empresaViewModel, _empresaRepository.GetById((Guid) empresaViewModel.Id));
            
            _empresaRepository.Update(empresaMapper);
            _unitOfWork.Commit();
        }
        public IEnumerable<EmpresaViewModel> GetAll()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaViewModel>>(
                                    _empresaRepository
                                        .AsNoTrackingOnlyIsNotDeleted());
            return empresas;
        }
        public IEnumerable<EmpresaViewModel> GetAllSoftDeleted()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaViewModel>>(
                                    _empresaRepository
                                        .GetAllSoftDeleted());
            return empresas;
        }
        public async Task<IEnumerable<EmpresaViewModel>> GetAllAsync()
        {
            var empresas = _mapper.Map<IEnumerable<EmpresaViewModel>>(
                                    await _empresaRepository
                                    .GetAllAsync());
            return empresas;
        }
        public async Task<IEnumerable<EmpresaViewModel>> GetAllAsyncDapper()
        {
            // return await _context.QueryAsync<ProductModel>(ct, @"
            //         SELECT p.ExternalId as Id, p.Code, p.Name, lph.Price, lph.CreatedOn as PriceChangedOn
            //         FROM (
            //             SELECT Id, ExternalId, Code, Name, RowId
            //             FROM Product
            //             ORDER BY Code DESC
            //             LIMIT @Take OFFSET @Skip
            //         ) p
            //         INNER JOIN (
            //             SELECT ph.ProductId, ph.Price, ph.CreatedOn
            //             FROM PriceHistory ph
            //             INNER JOIN (
            //                 SELECT MAX(RowId) RowId
            //                 FROM PriceHistory
            //                 GROUP BY ProductId
            //             ) phLatest ON ph.RowId = phLatest.RowId
            //         ) lph ON p.Id = lph.ProductId", new
            //                 {
            //                     Skip = skip ?? 0,
            //                     Take = take ?? 20
            //                 });
            //             };

            var strSQL = "SELECT * FROM public.\"Empresas\";";

            await using var tx = await _sigespDbContext.Database.BeginTransactionAsync();
            
            var empresas = _mapper.Map<IEnumerable<EmpresaViewModel>>
                                    (await _sigespDbContext.QueryAsync<Empresa>(CancellationToken.None, strSQL));

            return empresas;
        }
        public Guid GetIdByRazaoSocial(string property, string value)
        {
            var getId = _empresaRepository
                                        .GetIdFromPropertyAny(property, value);

            return getId;
        }
        public void Remove(Guid id)
        {
            _empresaRepository.Remove(id);
             _unitOfWork.Commit();
        }
        
        public void Dispose()
        {
            _empresaRepository.Dispose();
        }
    }
}