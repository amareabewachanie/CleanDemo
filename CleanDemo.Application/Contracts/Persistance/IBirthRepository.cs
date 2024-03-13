using CleanDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Application.Contracts.Persistance
{
    public interface IBirthRepository : IAsyncRepository<Birth>
    {
    }
}
