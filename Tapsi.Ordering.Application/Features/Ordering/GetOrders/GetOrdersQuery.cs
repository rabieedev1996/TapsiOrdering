using MediatR;

namespace Tapsi.Ordering.Application.Features.Ordering.GetOrders;

public class GetOrdersQuery:IRequest<GetOrdersVM>
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int? From { get; set; }
    public int? Count { get; set; }
}