using Shofy.Order.Application.Features.CQRS.Queries.AddressQueries;
using Shofy.Order.Application.Features.CQRS.Results.AddressResults;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetByIdAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetByIdAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<GetByIdAddressQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
        {
            var values = await _addressRepository.GetByIdAsyns(getAddressByIdQuery.Id);
            return new GetByIdAddressQueryResult()
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}
