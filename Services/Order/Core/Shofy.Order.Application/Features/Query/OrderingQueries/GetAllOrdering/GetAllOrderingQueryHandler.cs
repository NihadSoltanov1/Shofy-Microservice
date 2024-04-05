using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.Query.OrderingQueries.GetAllOrdering
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<GetAllOrderingQueryResponse>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetAllOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrderingQueryResponse>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAllOrderingQueryResponse()
            {
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice
            }).ToList();
        }
    }
}
