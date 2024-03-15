using CleanDemo.API.Filters;
using CleanDemo.Application.Features.Births.Commands.Create;
using CleanDemo.Application.Features.Births.Commands.Delete;
using CleanDemo.Application.Features.Births.Commands.Update;
using CleanDemo.Application.Features.Births.Queries.Get;
using CleanDemo.Application.Features.Births.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("all", Name = "GetAllBirths")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<List<BirthsVm>>> GetAllBirths()
        {
            
            return Ok(await _mediator.Send(new GetBirthListQuery()));
        }
        [HttpGet("{id}", Name = "GetBirth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BirthVm>> GetBirth(int id)
        {
            var request = new GetBirthQuery { Id = id };
            return Ok(await _mediator.Send(request));
        }
        [HttpPost(Name ="AddBirth")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        public async Task<ActionResult<CreateBirthCommandResponse>> AddBirth([FromBody] CreateBirthCommand createBirthCommand)
        {
            var response = await _mediator.Send(createBirthCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateBirth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateBirthCommandResponse>> UpdateBirth([FromBody] UpdateBirthCommand updateBirthCommand)
        {
            var response = await _mediator.Send(updateBirthCommand);
            return Ok(response);
        }
        [HttpDelete( "{id}",Name = "DeleteBirth")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBirth(int id)
        {
             await _mediator.Send(new DeleteBirthCommand { Id = id });
            return NoContent();
        }

    }
}
