using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDemo.Application.Features.Births.Commands.Create;
using CleanDemo.Application.Responses;

namespace CleanDemo.Application.Features.Births.Commands.Update
{
    public class UpdateBirthCommandResponse : BaseResponse
    {
        public UpdateBirthCommandResponse():base()
        {
            
        }
        public UpdateBirthDto Birth { get; set; } = default;
    }
}
