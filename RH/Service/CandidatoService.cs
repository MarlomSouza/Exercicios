using Microsoft.EntityFrameworkCore;
using RH_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly Context _dbContext;

        public CandidatoService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Candidato> AddAsync(Candidato entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Delete(Candidato entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Candidato> GetAll()
        {
            return _dbContext.Candidatos;
        }

        public async Task<Candidato> GetById(int id)
        {
            return await _dbContext.Candidatos.FirstAsync(c => c.Id.Equals(id));
        }

        public async Task<Candidato> Update(Candidato entity)
        {
            //service.Entry(candidato).State = EntityState.Modified;

            //try
            //{
            //    await service.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CandidatoExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Candidatos.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

       
    }
}
