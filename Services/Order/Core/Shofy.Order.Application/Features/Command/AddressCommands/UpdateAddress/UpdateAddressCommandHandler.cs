using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.AddressCommands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.AddressId);
            value.District = request.District;
            value.City = request.City;
            value.Detail = request.Detail;
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
            return new UpdateAddressCommandResponse();
        }
    }
}

