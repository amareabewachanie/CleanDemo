using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Persistence.Repositories
{
    public class MarriageRepository : BaseRepository<Marriage>, IMarriageRepository
    {
        public MarriageRepository(OcraDbContext context) : base(context) 
        {
            
        }
    }
}
