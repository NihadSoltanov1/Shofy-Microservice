using Shofy.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> OrderDetailRepository)
        {
            _orderDetailRepository = OrderDetailRepository;
        }

        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value = await _orderDetailRepository.GetByIdAsyns(removeOrderDetailCommand.Id);
            await _orderDetailRepository.DeleteAsync(value);
        }
    }
}
