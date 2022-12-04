using eBookStore.API.Author.Application.Author;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookStore.API.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator imediator)
        {
            _mediator = imediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get([FromRoute] GetAuthors request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get([FromRoute] GetAuthor request)
        {
            var dto = await _mediator.Send(request);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateAuthor request)
        {
            var id = await _mediator.Send(request);
            return id;
        }
    }
}
