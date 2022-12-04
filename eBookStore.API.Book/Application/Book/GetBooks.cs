using AutoMapper;

using eBookStore.API.Book.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Book.Application.Book
{
    public class GetBooks : IRequest<IEnumerable<BookDto>>
    {
        public int Id { get; set; }
    }

    class GetBooksHandler : IRequestHandler<GetBooks, IEnumerable<BookDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetBooks request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<BookDto>>(entity);
        }
    }
}
