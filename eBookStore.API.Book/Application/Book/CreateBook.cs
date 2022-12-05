using AutoMapper;

using eBookStore.API.Book.Persistence;

using FluentValidation;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Book.Application.Book
{
    public class CreateBook : IRequest<int>
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateBookValidator : AbstractValidator<CreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.AuthorId).NotEmpty();
            RuleFor(c => c.Price).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }

    public class CreateBookHandler : IRequestHandler<CreateBook, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Book>(request);
            _context.Books.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
