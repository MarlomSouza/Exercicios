using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service.Interface;
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

    }
}
