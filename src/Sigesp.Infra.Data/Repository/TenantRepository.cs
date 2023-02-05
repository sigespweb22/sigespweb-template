using System;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sigesp.Domain.Interfaces;
using Sigesp.Domain.Models;
using Sigesp.Infra.Data.Context;
using Sigesp.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Sigesp.Infra.Data.Repository
{
    public class TenantRepository : Repository<Tenant>, ITenantRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private readonly IConfiguration _configuration;

        public TenantRepository(SigespDbContext context,
                                IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor)
        : base(context)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task <string> GetTenantIdAsync(Guid apiKey) 
        {
            try 
            {
                var tenantId = await DbSet
                                    .AsNoTracking()
                                    .Where(x => x.ApiKey == apiKey)
                                    .FirstOrDefaultAsync();
                return tenantId.ToString();
            } 
            catch { throw; }
        }
        public async Task <string> GetTenantIdAsync() 
        {
            return await Task.FromResult(_session.GetString("TenantId"));
        }
        public string GetTenantId(Guid apiKey)
        {
            try 
            {
                var tenantId = DbSet
                                .AsNoTracking()
                                .Where(x => x.ApiKey == apiKey)
                                .FirstOrDefault();
                return tenantId.ToString();
            } 
            catch { throw; }
        }
        public string GetTenantId()
        {
            return _session.GetString("TenantId");
        }
        public async Task<string> GetNomeAsync(Guid tenantId)
        {
            var result = await  DbSet
                                    .FirstOrDefaultAsync(x => x.Id == tenantId);
            return result.Nome;
        }

        public async Task<Tenant> GetForOficioLeituraAsync(Guid tenantId)
        {
            var result = await  DbSet
                                    .Select(x => new Tenant 
                                    {
                                        Id = x.Id,
                                        NomeExibicao = x.NomeExibicao,
                                        OficioLeituraAssinaturaNome = x.OficioLeituraAssinaturaNome,
                                        OficioLeituraAssinaturaCargo = x.OficioLeituraAssinaturaCargo,
                                        OficioLeituraAssinaturaMatricula = x.OficioLeituraAssinaturaMatricula,
                                        OficioLeituraVocativo1 = x.OficioLeituraVocativo1,
                                        OficioLeituraVocativo2 = x.OficioLeituraVocativo2,
                                        OficioLeituraVocativo3 = x.OficioLeituraVocativo3,
                                        EnderecoLogradouro = x.EnderecoLogradouro,
                                        EnderecoLogradouroNumero = x.EnderecoLogradouroNumero,
                                        EnderecoCEP = x.EnderecoCEP,
                                        EnderecoBairro = x.EnderecoBairro,
                                        EnderecoCidade = x.EnderecoCidade,
                                        EnderecoEstado = x.EnderecoEstado,
                                        TelefoneDDD = x.TelefoneDDD,
                                        TelefoneNumero = x.TelefoneNumero,
                                        EmailPrincipal = x.EmailPrincipal
                                    })
                                    .FirstOrDefaultAsync(x => x.Id == tenantId);
            return result;
        }
    }    
}
