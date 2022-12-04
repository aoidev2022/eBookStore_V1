using eBookStore.API.Basket.Model;
using eBookStore.API.Basket.Persistence;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Application.Basket
{
    public class CreateBasket : IRequest<int>
    {
        public string Username { get; set; }
    }

    public class CreateBasketHandler : IRequestHandler<CreateBasket, int>
    {
        private readonly AppDbContext _context;

        public CreateBasketHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBasket request, CancellationToken cancellationToken)
        {
            var entity = new Model.Basket
            {
                Username = request.Username,
                CreatedOn = DateTimeOffset.UtcNow,
                Status = BasketStatusEnum.Open
            };

            _context.Baskets.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
