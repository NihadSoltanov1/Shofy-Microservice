using MediatR;

namespace Shofy.Order.Application.Features.Command.AddressCommands.DeleteAddress
{
    public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
    {
        public int AddressId { get; set; }

        public DeleteAddressCommandRequest(int addressId)
        {
            AddressId = addressId;
        }
    }
}
