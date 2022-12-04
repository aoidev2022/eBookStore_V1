using eBookStore.API.Basket.Persistence;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Application.Item
{
    public class CreateItem : IRequest<int>
    {
        public int BasketId { get; set; }
        public int BookId { get; set; }
    }

    public class CreateItemHandler : IRequestHandler<CreateItem, int>
    {
        private readonly AppDbContext _context;

        public CreateItemHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var entity = new Model.Item
            {
                BasketId = request.BasketId,
                CreatedOn = DateTimeOffset.UtcNow,
                BookId = request.BookId
            };

            _context.Items.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
