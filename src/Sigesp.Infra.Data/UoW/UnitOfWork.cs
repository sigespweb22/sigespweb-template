using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Sigesp.Domain.Interfaces;
using Sigesp.Infra.Data.Context;

namespace Sigesp.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SigespDbContext _context;

        public UnitOfWork(SigespDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public int CommitWithoutSoftDeletion()
        {
            return _context.SaveChangesWhitoutSD(true);
        }


        public ValidationResult CommitVR()
        {
            var commit = _context.SaveChanges();

            if (commit == 1) {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error commit.");
            }
        }

        public async Task<ValidationResult> CommitAsyncVR()
        {
            int commitAsync;

            try
            {
                commitAsync = await _context.SaveChangesAsync();     
            }
            catch (System.Exception ex)
            {
                
                return new ValidationResult(ex.ToString());
            }
            
            if (commitAsync == 1)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Error commitAsync.");
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
