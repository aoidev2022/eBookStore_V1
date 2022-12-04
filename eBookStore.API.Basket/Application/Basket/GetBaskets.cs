using AutoMapper;

using eBookStore.API.Basket.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Application.Basket
{
    public class GetBaskets : IRequest<IEnumerable<BasketDto>>
    {
        public string Username { get; set; }
    }

    public class GetBasketsHandler : IRequestHandler<GetBaskets, IEnumerable<BasketDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBasketsHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BasketDto>> Handle(GetBaskets request, CancellationToken cancellationToken)
        {
            var query = _context.Baskets.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Username))
                query = query.Where(q => q.Username == request.Username);

            var entities = await query.ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<BasketDto>>(entities);
        }
    }
}
