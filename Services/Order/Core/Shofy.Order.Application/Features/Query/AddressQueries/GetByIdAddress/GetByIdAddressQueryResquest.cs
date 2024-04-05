using MediatR;

namespace Shofy.Order.Application.Features.Query.AddressQueries.GetByIdAddress
{
    public class GetByIdAddressQueryResquest : IRequest<GetByIdAddressQueryResponse>
    {
        public int Id { get; set; }
    }
}
