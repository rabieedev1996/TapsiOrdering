using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Application.Features.Sample.GetOrderById;

public class GetOrderByIdVM
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public OrderStatusTypes OrderStatus { get; set; }
    public decimal TotalPrice { set; get; }
    public string CreatedDate { set; get; }
}