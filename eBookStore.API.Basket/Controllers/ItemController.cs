using eBookStore.API.Basket.Application.Item;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace eBookStore.API.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("basket/{basketId}")]
        public async Task<ActionResult> Post([FromRoute] GetItems request)
        {
            var dto = await _mediator.Send(request);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateItem request)
        {
            var id = await _mediator.Send(request);
            return id;
        }
    }
}
