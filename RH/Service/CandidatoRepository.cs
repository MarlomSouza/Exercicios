using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly Context _dbContext;

        public CandidatoRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Candidato> GetById(int id)
        {
            return _dbContext.Candidatos.Include(c => c.Tecnologias).ThenInclude(t => t.Tecnologia).FirstAsync(c => c.Id.Equals(id));
        }

        public IEnumerable<Candidato> List()
        {
            return _dbContext.Candidatos.Include(c => c.Tecnologias).ThenInclude(t => t.Tecnologia).AsEnumerable();
        }

        public Task Insert(Candidato candidato)
        {
            _dbContext.Candidatos.AddAsync(candidato);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update(Candidato candidato)
        {
            _dbContext.Entry(candidato).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Candidato candidato)
        {
            _dbContext.Candidatos.Remove(candidato);
            return _dbContext.SaveChangesAsync();

        }
    }
}
