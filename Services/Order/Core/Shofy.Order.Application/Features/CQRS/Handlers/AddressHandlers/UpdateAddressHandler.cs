using Shofy.Order.Application.Features.CQRS.Commands.AddressCommands;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public UpdateAddressHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var value = await _addressRepository.GetByIdAsyns(updateAddressCommand.AddressId);
            value.Detail=updateAddressCommand.Detail;
            value.District = updateAddressCommand.District;
            value.City = updateAddressCommand.City;
            value.UserId = updateAddressCommand.UserId;
            await _addressRepository.UpdateAsync(value);
        }

    }
}
