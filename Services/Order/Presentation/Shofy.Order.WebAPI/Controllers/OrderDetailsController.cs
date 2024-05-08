using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Order.Application.Features.Command.OrderDetailCommands.CreateOrderDetail;
using Shofy.Order.Application.Features.Command.OrderDetailCommands.UpdateOrderDetail;
using Shofy.Order.Application.Features.Command.OrderDetailCommands.DeleteOrderDetail;
using Shofy.Order.Application.Features.Query.OrderDetailQueries.GetAllOrderDetail;
using Shofy.Order.Application.Features.Query.OrderDetailQueries.GetByIdOrderDetail;
using Microsoft.AspNetCore.Authorization;

namespace Shofy.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetail()
        {
            var values = await _mediator.Send(new GetAllOrderDetailQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int id)
        {
            var value = await _mediator.Send(new GetByIdOrderDetailQueryRequest(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(CreateOrderDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("OrderDetail added successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _mediator.Send(new DeleteOrderDetailCommandRequest(id));
            return Ok("OrderDetail removed successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("OrderDetail updated successfuly");
        }
    }
}
