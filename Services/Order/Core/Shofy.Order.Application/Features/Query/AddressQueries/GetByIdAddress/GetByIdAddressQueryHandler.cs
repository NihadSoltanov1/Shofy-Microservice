using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Query.AddressQueries.GetByIdAddress
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryResquest, GetByIdAddressQueryResponse>
    {
        private readonly IRepository<Address> _repository;

        public GetByIdAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdAddressQueryResponse> Handle(GetByIdAddressQueryResquest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.Id);
            return new GetByIdAddressQueryResponse()
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                UserId = value.UserId
            };
        }
    }
}
