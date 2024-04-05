using MediatR;

namespace Shofy.Order.Application.Features.Query.AddressQueries.GetAllAddress
{
    public class GetAllAddressQueryRequest : IRequest<List<GetAllAddressQueryResponse>>
    {

    }
}
