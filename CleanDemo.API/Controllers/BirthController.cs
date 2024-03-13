using CleanDemo.Application.Features.Births.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanDemo.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class BirthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BirthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet("all",Name ="GetAllBirths")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<List< GetAllBirths()
        //{

        //}
        [HttpPost(Name ="AddBirth")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<CreateBirthCommandResponse>> Create([FromBody] CreateBirthCommand createBirthCommand)
        {
            var response = await _mediator.Send(createBirthCommand);
            return Ok(response);
        }
    }
}
