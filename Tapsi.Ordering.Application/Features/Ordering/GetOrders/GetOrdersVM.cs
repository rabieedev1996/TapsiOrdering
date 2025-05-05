using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Application.Features.Ordering.GetOrders;

public class GetOrdersVM
{
    public List<GetOrdersVM_Item> Items{ get; set; }
}

public class GetOrdersVM_Item
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public OrderStatusTypes OrderStatus { get; set; }
    public decimal TotalPrice { set; get; }
    public string CreatedDate { set; get; }
}