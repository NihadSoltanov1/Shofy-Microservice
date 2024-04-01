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
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var value = await _addressRepository.GetByIdAsyns(removeAddressCommand.AddressId);
            await _addressRepository.DeleteAsync(value);
        }

    }
}
