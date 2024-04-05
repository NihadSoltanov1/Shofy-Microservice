using MediatR;

namespace Shofy.Order.Application.Features.Command.OrderDetailCommands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandRequest : IRequest<DeleteOrderDetailCommandResponse>
    {
        public int OrderDetailId { get; set; }

        public DeleteOrderDetailCommandRequest(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
