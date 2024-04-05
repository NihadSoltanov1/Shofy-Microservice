using MediatR;

namespace Shofy.Order.Application.Features.Query.OrderDetailQueries.GetByIdOrderDetail
{
    public class GetByIdOrderDetailQueryRequest : IRequest<GetByIdOrderDetailQueryResponse>
    {
        public int Id { get; set; }

        public GetByIdOrderDetailQueryRequest(int id)
        {
            Id = id;
        }
    }
}
