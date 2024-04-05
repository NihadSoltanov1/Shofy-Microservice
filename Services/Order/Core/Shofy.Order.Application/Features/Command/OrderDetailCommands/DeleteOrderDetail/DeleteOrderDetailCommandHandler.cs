using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.OrderDetailCommands.DeleteOrderDetail
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommandRequest, DeleteOrderDetailCommandResponse>
    {
        private readonly IRepository<OrderDetail> _repository;

        public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteOrderDetailCommandResponse> Handle(DeleteOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsyns(request.OrderDetailId);
            await _repository.DeleteAsync(value);
            return new DeleteOrderDetailCommandResponse();
        }
    }
}
