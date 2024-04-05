using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.AddressCommands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.AddressId);
            await _repository.DeleteAsync(value);
            return new DeleteAddressCommandResponse();
        }
    }
}
