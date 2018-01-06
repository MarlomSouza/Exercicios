using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly Context _dbContext;

        public ProcessoRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Processo> GetById(int id)
        {
            return _dbContext.Processos.Include(c => c.Tecnologias).ThenInclude(t => t.Tecnologia).FirstAsync(c => c.Id.Equals(id));
        }

        public IEnumerable<Processo> List()
        {
            return _dbContext.Processos.Include(c => c.Tecnologias).ThenInclude(t => t.Tecnologia).AsEnumerable();
        }

        public Task Insert(Processo processo)
        {
            _dbContext.Processos.AddAsync(processo);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update(Processo processo)
        {
            _dbContext.Entry(processo).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Processo processo)
        {
            _dbContext.Processos.Remove(processo);
            return _dbContext.SaveChangesAsync();

        }
    }
}
