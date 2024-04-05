using MediatR;

namespace Shofy.Order.Application.Features.Command.AddressCommands.UpdateAddress
{
    public class UpdateAddressCommandRequest: IRequest<UpdateAddressCommandResponse>
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}

