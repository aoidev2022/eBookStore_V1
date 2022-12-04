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
    public class GetAuthors : IRequest<IEnumerable<AuthorDto>>
    {
        
    }

    public class GetAuthorsHandler : IRequestHandler<GetAuthors, IEnumerable<AuthorDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AuthorDto>> Handle(GetAuthors request, CancellationToken cancellationToken)
        {
            var entities = await _context.Authors.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<Model.Author>, IEnumerable<AuthorDto>>(entities);
        }
    }
}
