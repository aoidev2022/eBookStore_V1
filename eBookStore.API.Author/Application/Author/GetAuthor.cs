using AutoMapper;

using eBookStore.API.Author.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Author.Application.Author
{
    public class GetAuthor : IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }

    public class ListAuthorHandler : IRequestHandler<GetAuthor, AuthorDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ListAuthorHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthor request, CancellationToken cancellationToken)
        {
            var entity = await _context.Authors.SingleOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
            return _mapper.Map<Model.Author, AuthorDto>(entity);
        }
    }
}
