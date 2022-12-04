using eBookStore.API.Book.Application.Book;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace eBookStore.API.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] GetBook request)
        {
            var dto = await _mediator.Send(request);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromRoute] GetBooks request)
        {
            var dto = await _mediator.Send(request);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateBook request)
        {
            return await _mediator.Send(request);
        }
    }
}
