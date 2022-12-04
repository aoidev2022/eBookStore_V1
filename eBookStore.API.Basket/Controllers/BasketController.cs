using eBookStore.API.Basket.Application.Basket;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Get([FromRoute] GetBasket request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketDto>>> Get([FromQuery] GetBaskets request)
        {
            var dtos = await _mediator.Send(request);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateBasket request)
        {
            return await _mediator.Send(request);
        }
    }
}
