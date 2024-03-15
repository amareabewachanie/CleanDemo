using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanDemo.Application.Features.Births.Commands.Delete
{
    public class DeleteBirthCommand:IRequest
    {
        public int Id { get; set; }
    }
}
