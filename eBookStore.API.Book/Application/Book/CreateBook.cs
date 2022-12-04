using AutoMapper;

using eBookStore.API.Book.Persistence;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Book.Application.Book
{
    public class CreateBook : IRequest
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }

    public class CreateBookHandler : IRequestHandler<CreateBook>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            _context.Books.Add(new Model.Book { AuthorId = request.AuthorId, Name = request.Name });

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
