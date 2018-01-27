using RH.Models;
using System.Threading.Tasks;

namespace RH.Service.Interface
{
    public interface ITriagemRepository : IRepository<Triagem>
    {
        Task Update(Triagem triagem, int candidatoId);
    }
}
