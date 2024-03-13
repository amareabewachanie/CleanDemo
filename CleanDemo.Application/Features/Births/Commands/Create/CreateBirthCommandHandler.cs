using AutoMapper;
using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Domain.Entities;
using MediatR;

namespace CleanDemo.Application.Features.Births.Commands.Create
{
    public class CreateBirthCommandHandler 
        : IRequestHandler<CreateBirthCommand, CreateBirthCommandResponse>
    {
        private readonly IBirthRepository _repository;
        private readonly IMapper _mapper;

        public CreateBirthCommandHandler(IBirthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateBirthCommandResponse>
            Handle(CreateBirthCommand request, CancellationToken cancellationToken)
        {
            var createBirthCommandResponse = new CreateBirthCommandResponse();
            var validator = new CreateBirthValidator();
            var validationResult =await validator.ValidateAsync(request);
            if (validationResult.Errors.Count>0)
            {
                createBirthCommandResponse.Success = false;
                createBirthCommandResponse.ValidationErrors =
                    validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            if (createBirthCommandResponse.Success)
            {
                var birthDto = _mapper.Map<Birth>(request);
                var birth = await _repository.CreateAsync(birthDto);
                createBirthCommandResponse.Birth = _mapper.Map<CreateBirthDto>(birth);
            }
            return createBirthCommandResponse;
        }
    }
}
