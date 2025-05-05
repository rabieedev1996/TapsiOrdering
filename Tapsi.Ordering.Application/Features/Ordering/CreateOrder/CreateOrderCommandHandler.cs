using MediatR;
using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Application.Contract.SQLDB;
using Tapsi.Ordering.Domain.Entities.SQL;
using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Application.Features.Sample.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVM>
{
    IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<CreateOrderVM> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order()
        {
            OrderStatus = OrderStatusTypes.PENDING,
            CustomerName = request.CustomerName,
            TotalPrice = request.TotalPrice,    
        };
        await _orderRepository.AddAsync(order);
        return new CreateOrderVM()
        {
            OrderId = order.Id,
        };
    }
}