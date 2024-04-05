using MediatR;

namespace Shofy.Order.Application.Features.Query.OrderingQueries.GetByIdOrdering
{
    public class GetByIdOrderingQueryRequest : IRequest<GetByIdOrderingQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdOrderingQueryRequest(int id)
        {
            Id = id;
        }
    }

}
