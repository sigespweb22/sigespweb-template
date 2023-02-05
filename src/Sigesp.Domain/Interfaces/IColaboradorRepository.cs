using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sigesp.Domain.Models;

namespace Sigesp.Domain.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<Colaborador> GetAsync(int ipen);
        new Colaborador GetById(Guid id);
        Guid GetIdByDetentoId(Guid detentoId);
        Guid GetIdByDetentoNome(string detentoNome);
        Colaborador GetByDetentoNome(string detentoNome);
        Colaborador GetByIdWithInclude(Guid id);
        Task<IEnumerable<Colaborador>> GetAllOnlyIsDeletedTrue();
        Task<IEnumerable<Colaborador>> GetAllColaboradorPorConvenioSituacaoAdmitido();
        Task<IEnumerable<Colaborador>> GetAllWithIncludeAsync();
        IEnumerable<Colaborador> GetAllWithInclude();
        new IEnumerable<Colaborador> GetAllSoftDeleted();
        Colaborador GetByDetentoIpenOrDetentoNome(string property, string arg);
        IEnumerable<Colaborador> GetAllDeletedTrueAndFalseWithInclude();
        bool AlreadyColaborador (Guid detentoId);
        IEnumerable<Colaborador> GetAllByDetentoNome(string detentoNome);
        IEnumerable<Colaborador> AsNoTrackingWithInclude();
        Colaborador GetByDetentoIpenAndEmpresaConvenioId(int ipen, Guid ecId);
        new IEnumerable<Colaborador> GetAll();
    }
}