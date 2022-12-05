using AutoMapper;

using eBookStore.API.Author.Persistence;

using FluentValidation;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace eBookStore.API.Author.Application.Author
{
    public class CreateAuthor : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }

    public class CreateAuthorValidator : AbstractValidator<CreateAuthor>
    {
        public CreateAuthorValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.DateOfBirth).NotEmpty();
        }
    }

    public class CreateAuthorHandler : IRequestHandler<CreateAuthor, int>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorHandler(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> Handle(CreateAuthor request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Author>(request);
            _context.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
