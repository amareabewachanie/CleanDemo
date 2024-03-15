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

namespace CleanDemo.Application.Features.Births.Commands.Delete
{
    public class DeleteBirthCommandHandler: IRequestHandler<DeleteBirthCommand>
    {
        private readonly IAsyncRepository<Birth> _repository;
        private readonly IMapper _mapper;

        public DeleteBirthCommandHandler(IAsyncRepository<Birth> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteBirthCommand request, CancellationToken cancellationToken)
        {
            var birthToDelete = await _repository.GetAsync(request.Id);
            if (birthToDelete == null) throw new NotFoundException($"{typeof(Birth)}", request.Id);
            await _repository.DeleteAsync(birthToDelete);
        }
    }
}
