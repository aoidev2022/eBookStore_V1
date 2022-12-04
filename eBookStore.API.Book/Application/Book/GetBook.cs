using AutoMapper;

using eBookStore.API.Book.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Book.Application.Book
{
    public class GetBook : IRequest<BookDto>
    {
        public int Id { get; set; }
    }

    class GetBookHandler : IRequestHandler<GetBook, BookDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBookHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBook request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return _mapper.Map<BookDto>(entity);
        }
    }
}
