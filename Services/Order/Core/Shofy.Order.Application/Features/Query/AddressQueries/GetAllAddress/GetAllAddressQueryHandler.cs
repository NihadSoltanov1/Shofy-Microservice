using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Query.AddressQueries.GetAllAddress
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, List<GetAllAddressQueryResponse>>
    {
        private readonly IRepository<Address> _respository;

        public GetAllAddressQueryHandler(IRepository<Address> respository)
        {
            _respository = respository;
        }

        public async Task<List<GetAllAddressQueryResponse>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _respository.GetAllAsync();
            return values.Select(x => new GetAllAddressQueryResponse()
            {
             AddressId = x.AddressId,
             City = x.City,
             Detail=x.Detail,
             District=x.District,
             UserId = x.UserId
            }).ToList();
        }
    }
}
