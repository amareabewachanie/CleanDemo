using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Application.Exceptions;
using CleanDemo.Domain.Entities;
using MediatR;

namespace CleanDemo.Application.Features.Births.Commands.Update
{
    public class UpdateBirthCommandHandler : IRequestHandler<UpdateBirthCommand, UpdateBirthCommandResponse>
    {
        private readonly IBirthRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBirthCommandHandler(IBirthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateBirthCommandResponse> Handle(UpdateBirthCommand request,
            CancellationToken cancellationToken)
        {
            var birthTobeUpdate = await _repository.GetAsync(request.Id);
            if (birthTobeUpdate != null)
            {
                var updateBirthResponse = new UpdateBirthCommandResponse();
                _mapper.Map(request, birthTobeUpdate, typeof
                    (UpdateBirthCommand), typeof(Birth));
                await _repository.UpdateAsync(birthTobeUpdate);
                updateBirthResponse.Success = true;
                updateBirthResponse.Birth = _mapper.Map<UpdateBirthDto>(birthTobeUpdate);
                return updateBirthResponse;
            }

            throw new NotFoundException($"{typeof(Birth)}", request.Id);
        }
    }
}
