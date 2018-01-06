using System.Collections.Generic;
using System.Threading.Tasks;
using RH_API.Models;

namespace RH.Service
{
    public interface ICandidatoService
    {
        
        void Delete(Candidato entity);
        IEnumerable<Candidato> GetAll();
        Task<Candidato> GetById(int id);
        Task<Candidato> AddAsync(Candidato entity);
        Task<Candidato> Update(Candidato entity);
    }
}