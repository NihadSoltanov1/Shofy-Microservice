using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.Command.OrderingCommands.DeleteOrdering
{
    public class DeleteOrderingCommandRequest : IRequest<DeleteOrderingCommandResponse>
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }

}
