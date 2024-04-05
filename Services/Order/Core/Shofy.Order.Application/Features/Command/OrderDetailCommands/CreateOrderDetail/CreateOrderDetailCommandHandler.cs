using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.OrderDetailCommands.CreateOrderDetail
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommandRequest, CreateOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderDetailCommandResponse> Handle(CreateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OrderDetail()
            {
                OrderingId = request.OrderingId,
                ProductAmount = request.ProductAmount,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                TotalPrice = request.TotalPrice
            });
            return new CreateOrderDetailCommandResponse();
        }
    }

}
