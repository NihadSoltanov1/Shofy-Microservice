
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Order.Application.Features.Command.OrderingCommands.CreateOrdering;
using Shofy.Order.Application.Features.Command.OrderingCommands.UpdateOrdering;
using Shofy.Order.Application.Features.Command.OrderingCommands.DeleteOrdering;
using Shofy.Order.Application.Features.Query.OrderingQueries.GetAllOrdering;
using Shofy.Order.Application.Features.Query.OrderingQueries.GetByIdOrdering;
using Microsoft.AspNetCore.Authorization;

namespace Shofy.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdering()
        {
            var values = await _mediator.Send(new GetAllOrderingQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrdering(int id)
        {
            var value = await _mediator.Send(new GetByIdOrderingQueryRequest(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrdering(CreateOrderingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Ordering added successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new DeleteOrderingCommandRequest(id));
            return Ok("Ordering removed successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Ordering updated successfuly");
        }
    }
}
