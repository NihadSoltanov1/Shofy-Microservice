using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Query.OrderDetailQueries.GetByIdOrderDetail
{
    public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQueryRequest, GetByIdOrderDetailQueryResponse>
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetByIdOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdOrderDetailQueryResponse> Handle(GetByIdOrderDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.Id);
            return new GetByIdOrderDetailQueryResponse()
            {
                OrderDetailId = value.OrderDetailId,
                OrderingId = value.OrderingId,
                ProductAmount = value.ProductAmount,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                TotalPrice = value.TotalPrice
            };
        }
    }
}
