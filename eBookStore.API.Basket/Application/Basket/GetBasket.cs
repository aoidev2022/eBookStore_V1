using AutoMapper;

using eBookStore.API.Basket.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Application.Basket
{
    public class GetBasket : IRequest<BasketDto>
    {
        public int Id { get; set; }
    }

    public class GetBasketHandler : IRequestHandler<GetBasket, BasketDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBasketHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BasketDto> Handle(GetBasket request, CancellationToken cancellationToken)
        {
            var entity = await _context.Baskets.SingleOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

            return _mapper.Map<BasketDto>(entity);
        }
    }
}
