using eBookStore.API.Book.Application.Book;

using MediatR;

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
        public async Task<ActionResult> Post(CreateBook request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteBook request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
