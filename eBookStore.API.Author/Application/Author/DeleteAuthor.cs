using eBookStore.API.Author.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Author.Application.Author
{
    public class DeleteAuthor : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteAuthorHanler : IRequestHandler<DeleteAuthor>
    {
        private readonly AppDbContext _context;

        public DeleteAuthorHanler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAuthor request, CancellationToken cancellationToken)
        {
            var obj = await _context.Authors.SingleOrDefaultAsync(q => q.Id == request.Id, cancellationToken: cancellationToken);

            if (obj == null)
            {
                return Unit.Value;
            }

            _context.Authors.Remove(obj);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
