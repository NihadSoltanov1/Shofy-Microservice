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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _orderDetailRepository.CreateAsync(new OrderDetail
            {
               ProductAmount  = createOrderDetailCommand.ProductAmount,
               OrderingId     = createOrderDetailCommand.OrderingId,
               ProductId      =createOrderDetailCommand.ProductId,
               ProductName    =createOrderDetailCommand.ProductName,
               ProductPrice   =createOrderDetailCommand.ProductPrice,
               TotalPrice     =createOrderDetailCommand.TotalPrice
            });
        }
    }
}
