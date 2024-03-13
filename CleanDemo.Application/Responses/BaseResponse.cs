using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message, bool success)
        {
            Success = success;
            message = message;
        }
        public bool Success { get; set; }
        public string message { get; set; }
        public List<string> ValidationErrors { get; set; }
        
    }
}
