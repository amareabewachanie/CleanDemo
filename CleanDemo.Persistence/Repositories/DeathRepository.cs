using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Persistence.Repositories
{
    public class DeathRepository:BaseRepository<Death>, IDeathRepository
    {
        public DeathRepository(OcraDbContext context):base(context)
        {
            
        }
    }
}
