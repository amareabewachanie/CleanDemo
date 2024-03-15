using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanDemo.Application.Features.Births.Queries.Get
{
    public  class GetBirthQuery:IRequest<BirthVm>
    {
        public int Id { get; set; }
    }
}
