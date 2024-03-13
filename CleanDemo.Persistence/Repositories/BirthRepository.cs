using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Persistence.Repositories
{
    public class BirthRepository : BaseRepository<Birth>,IBirthRepository
    {
        public BirthRepository(OcraDbContext context):base(context) 
        {
            
        }
    }
}
