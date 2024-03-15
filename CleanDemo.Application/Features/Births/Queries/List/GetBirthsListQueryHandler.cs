using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanDemo.Application.Contracts.Persistance;
using CleanDemo.Domain.Entities;
using MediatR;

namespace CleanDemo.Application.Features.Births.Queries.List
{
    public class GetBirthsListQueryHandler : IRequestHandler<GetBirthListQuery, IReadOnlyList<BirthsVm>>
    {
        private readonly IBirthRepository _repository;
        private readonly IMapper _mapper;

        public GetBirthsListQueryHandler(IBirthRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BirthsVm>> Handle(GetBirthListQuery request, CancellationToken cancellationToken)
        {
            var births = await _repository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<BirthsVm>>(births);
        }
    }
}
