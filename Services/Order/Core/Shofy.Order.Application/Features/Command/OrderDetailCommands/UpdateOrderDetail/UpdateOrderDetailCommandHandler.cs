using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.Command.OrderDetailCommands.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.OrderDetailId);
            value.OrderingId = request.OrderingId;
            value.ProductPrice = request.ProductPrice;
            value.ProductName = request.ProductName;
            value.ProductId = request.ProductId;
            value.ProductAmount = request.ProductAmount;
            value.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(value);
            return new UpdateOrderDetailCommandResponse();
        }
    }
}
