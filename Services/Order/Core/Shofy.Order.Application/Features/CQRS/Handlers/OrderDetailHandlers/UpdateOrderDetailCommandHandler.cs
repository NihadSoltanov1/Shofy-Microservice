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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _OrderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var value = await _OrderDetailRepository.GetByIdAsyns(updateOrderDetailCommand.OrderDetailId);

            value.ProductAmount = updateOrderDetailCommand.ProductAmount;
            value.OrderingId = updateOrderDetailCommand.OrderingId;
            value.ProductId = updateOrderDetailCommand.ProductId;
            value.ProductName = updateOrderDetailCommand.ProductName;
            value.ProductPrice = updateOrderDetailCommand.ProductPrice;
            value.TotalPrice = updateOrderDetailCommand.TotalPrice;   
            
            await _OrderDetailRepository.UpdateAsync(value);
        }
    }
}
