using Shofy.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Shofy.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetByIdOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetByIdOrderDetailQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<GetByIdOrderDetailQueryResult> Handle(GetByIdOrderDetailQuery getOrderDetailByIdQuery)
        {
            var values = await _orderDetailRepository.GetByIdAsyns(getOrderDetailByIdQuery.Id);
            return new GetByIdOrderDetailQueryResult()
            {
                ProductAmount = values.ProductAmount,
                OrderingId = values.OrderingId,
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                TotalPrice = values.TotalPrice,
                OrderDetailId = values.OrderDetailId
            };
        }
    }
}
