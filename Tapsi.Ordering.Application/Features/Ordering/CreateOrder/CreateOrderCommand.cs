using MediatR;

namespace Tapsi.Ordering.Application.Features.Sample.CreateOrder;

public class CreateOrderCommand:IRequest<CreateOrderVM>
{
    public string CustomerName{set; get;}
    public decimal TotalPrice{set; get;}
}