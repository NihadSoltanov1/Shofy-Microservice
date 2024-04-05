using MediatR;

namespace Shofy.Order.Application.Features.Query.OrderDetailQueries.GetAllOrderDetail
{
    public class GetAllOrderDetailQueryRequest : IRequest<List<GetAllOrderDetailQueryResponse>>
    {
    }
}
