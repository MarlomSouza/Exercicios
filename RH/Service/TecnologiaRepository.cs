using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RH.Service
{
    public class TecnologiaRepository : ITecnologiaRepository
    {
        private readonly Context _dbContext;

        public TecnologiaRepository(Context context)
        {
            _dbContext = context;
        }

        public Task Delete(Tecnologia tecnologia)
        {
            _dbContext.Tecnologias.Remove(tecnologia);
            return _dbContext.SaveChangesAsync();
        }

        public Task<Tecnologia> GetById(int id)
        {
            return _dbContext.Tecnologias.Include(t => t.Candidatos).ThenInclude(c => c.Candidato).Include(t => t.Processos).ThenInclude(p => p.Processo).FirstAsync(c => c.Id.Equals(id));
        }

        public Task Insert(Tecnologia tecnologia)
        {
            _dbContext.Tecnologias.AddAsync(tecnologia);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Tecnologia> List()
        {
            return _dbContext.Tecnologias.Include(t => t.Candidatos).ThenInclude(c => c.Candidato).Include(t => t.Processos).ThenInclude(p => p.Processo).AsEnumerable();
        }

        public Task Update(Tecnologia tecnologia)
        {
            _dbContext.Entry(tecnologia).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
