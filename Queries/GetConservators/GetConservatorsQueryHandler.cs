using AutoMapper;
using DormAPI.Data;
using DormAPI.Models.Dto;
using DormAPI.Services.Problems;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Queries.GetConservators
{
    public class GetConservatorsQueryHandler
        : IRequestHandler<GetConservatorsQuery, IEnumerable<DtoNameId>>
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetConservatorsQueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DtoNameId>> Handle(GetConservatorsQuery request, CancellationToken cancellationToken)
        {
            var conservators = await _db.Conservators
                .ToListAsync();

            return _mapper.Map<DtoNameId[]>(conservators);
        }
    }
}
