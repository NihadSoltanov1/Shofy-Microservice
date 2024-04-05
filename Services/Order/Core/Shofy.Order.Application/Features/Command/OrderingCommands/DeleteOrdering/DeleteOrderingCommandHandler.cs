using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.OrderingCommands.DeleteOrdering
{
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommandRequest, DeleteOrderingCommandResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteOrderingCommandResponse> Handle(DeleteOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.OrderingId);
            await _repository.DeleteAsync(value);
            return new DeleteOrderingCommandResponse();
        }
    }

}
