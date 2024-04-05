using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shofy.Order.Application.Features.Query.OrderingQueries.GetAllOrdering
{
    public class GetAllOrderingQueryRequest : IRequest<List<GetAllOrderingQueryResponse>>
    {
    }
}
