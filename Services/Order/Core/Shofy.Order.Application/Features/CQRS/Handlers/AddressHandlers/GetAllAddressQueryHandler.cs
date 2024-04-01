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
    public class GetAllAddressQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAllAddressQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _addressRepository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult()
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }
    }
}
