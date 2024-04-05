using MediatR;
using Shofy.Order.Application.Interfaces;
using Shofy.Order.Domain.Entities;

namespace Shofy.Order.Application.Features.Command.OrderingCommands.CreateOrdering
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest, CreateOrderingCommandResponse>
    {
        private IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderingCommandResponse> Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new Ordering()
            {
                TotalPrice = request.TotalPrice,
                OrderDate = request.OrderDate,
                UserId = request.UserId
            });
            return new CreateOrderingCommandResponse();
           
        }
    }


}
