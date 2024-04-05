using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shofy.Order.Application.Features.Command.AddressCommands.CreateAddress;
using Shofy.Order.Application.Features.Command.AddressCommands.UpdateAddress;
using Shofy.Order.Application.Features.Command.AddressCommands.DeleteAddress;
using Shofy.Order.Application.Features.Query.AddressQueries.GetAllAddress;
using Shofy.Order.Application.Features.Query.AddressQueries.GetByIdAddress;

namespace Shofy.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var values = await _mediator.Send(new GetAllAddressQueryRequest());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAddress(int id)
        {
            var value = await _mediator.Send(new GetByIdAddressQueryResquest(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(CreateAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Address added successfuly");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _mediator.Send(new DeleteAddressCommandRequest(id));
            return Ok("Address removed successfuly");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok("Address updated successfuly");
        }
    }
}
