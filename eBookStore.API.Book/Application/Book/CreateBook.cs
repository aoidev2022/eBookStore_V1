using AutoMapper;

using eBookStore.API.Book.Persistence;
using eBookStore.RabbitMQ.Bus;
using eBookStore.RabbitMQ.Events.Queue;

using FluentValidation;

using MediatR;

using System.Text.Json;
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
        readonly AppDbContext _context;
        readonly IMapper _mapper;
        readonly IRabbitEventBus _rabbitEventBus;

        public CreateBookHandler(AppDbContext context, IMapper mapper, IRabbitEventBus rabbitEventBus)
        {
            _context = context;
            _mapper = mapper;
            _rabbitEventBus = rabbitEventBus;
        }

        public async Task<int> Handle(CreateBook request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Model.Book>(request);
            _context.Books.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var email = new EmailEvent { Body = JsonSerializer.Serialize(request), Receiper = "aoi.182@live.com", Title = $"New book created: {request.Name}" };
            _rabbitEventBus.PublishEvent(email);

            return entity.Id;
        }
    }
}
