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
    public class GetAllOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public GetAllOrderDetailQueryHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _orderDetailRepository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult()
            {
               ProductAmount =  x.ProductAmount,
               OrderingId    =  x.OrderingId,   
               ProductId     =  x.ProductId,   
               ProductName   =  x.ProductName,  
               ProductPrice  =  x.ProductPrice, 
               TotalPrice    =  x.TotalPrice,
               OrderDetailId = x.OrderDetailId
            }).ToList();
        }
    }
}
