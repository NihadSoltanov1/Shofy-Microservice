using MediatR;
using Shofy.Order.Application.Features.Query.OrderingQueries.GetAllOrdering;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Query.OrderingQueries.GetByIdOrdering
{
    public class GetByIdOrderingQueryHandler : IRequestHandler<GetByIdOrderingQueryRequest, GetByIdOrderingQueryResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public GetByIdOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdOrderingQueryResponse> Handle(GetByIdOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.Id);
            return new GetByIdOrderingQueryResponse()
            {
                UserId = value.UserId,
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice
            };
        }
    }


}
