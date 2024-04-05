using MediatR;

namespace Shofy.Order.Application.Features.Command.OrderingCommands.UpdateOrdering
{
    public class UpdateOrderingCommandRequest : IRequest<UpdateOrderingCommandResponse>
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
