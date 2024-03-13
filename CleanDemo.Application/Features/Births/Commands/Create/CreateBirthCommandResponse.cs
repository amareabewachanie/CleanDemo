using CleanDemo.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Application.Features.Births.Commands.Create
{
    public class CreateBirthCommandResponse : BaseResponse
    {
        public CreateBirthCommandResponse():base()
        {
            
        }
        public CreateBirthDto Birth { get; set; } = default;
    }
}
