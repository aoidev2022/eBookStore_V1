using eBookStore.API.Book.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Book.Application.Book
{
    public class DeleteBook : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteBookHandler : IRequestHandler<DeleteBook>
    {
        private readonly AppDbContext _context;

        public DeleteBookHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var obj = await _context.Books.SingleOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
            
            if(obj == null)
            {
                return Unit.Value;
            }

            _context.Books.Remove(obj);
            
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
