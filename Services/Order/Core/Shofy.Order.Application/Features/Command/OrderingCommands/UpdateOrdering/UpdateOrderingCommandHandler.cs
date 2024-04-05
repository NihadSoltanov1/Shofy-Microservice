using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.OrderingCommands.UpdateOrdering
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingCommandResponse>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderingCommandResponse> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.OrderingId);
            value.OrderDate = request.OrderDate;
            value.TotalPrice = request.TotalPrice;
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
            return new UpdateOrderingCommandResponse();
        }
    }
}
