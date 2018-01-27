using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class TriagemRepository : ITriagemRepository
    {
        public readonly Context _dbContext;

        public TriagemRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Delete(Triagem entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Triagem> GetById(int id)
        {
            return _dbContext.Triagens.Include(t => t.Candidatos).ThenInclude(c => c.Candidato).Include(t => t.Processo).FirstAsync(c => c.Id.Equals(id));
        }

        public Task Insert(Triagem entity)
        {
            _dbContext.Triagens.AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Triagem> List()
        {
            return _dbContext.Triagens.Include(t => t.Candidatos).ThenInclude(c => c.Candidato).Include(t => t.Processo).AsEnumerable();
        }

        public Task Update(Triagem entity)
        {
            _dbContext.Triagens.Update(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update(Triagem triagem, int candidatoId)
        {
            var candidato = triagem.Candidatos.FirstOrDefault(d => d.CandidatoId.Equals(candidatoId));

            if (candidato == null)
                throw new Exception("Candidato não encontrado");

            triagem.Candidatos.Remove(candidato);
            _dbContext.Triagens.Update(triagem);
            return _dbContext.SaveChangesAsync();
        }
    }
}
