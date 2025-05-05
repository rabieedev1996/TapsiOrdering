using MediatR;

namespace Tapsi.Ordering.Application.Features.Sample.GetOrderById;

public class GetOrderByIdQuery:IRequest<GetOrderByIdVM>
{
    public Guid OrderId { get; set; }
}