using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanDemo.Application.Contracts.Persistance;
using MediatR;

namespace CleanDemo.Application.Features.Births.Queries.Get
{
    public class GetBirthQueryHandler:IRequestHandler<GetBirthQuery, BirthVm>
    {
        private readonly IBirthRepository _repository;
        private readonly IMapper _mapper;

        public GetBirthQueryHandler(IBirthRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BirthVm> Handle(GetBirthQuery request, CancellationToken cancellationToken)
        {
            var birth = await _repository.GetAsync(request.Id);
           return _mapper.Map<BirthVm>(birth);
        }
    }
}
