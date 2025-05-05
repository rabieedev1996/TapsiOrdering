using AutoMapper;
using MediatR;
using Tapsi.Ordering.Application.Contract.SQLDB;

namespace Tapsi.Ordering.Application.Features.Sample.GetOrderById;

public class GetOrderByIdQueryHandler:IRequestHandler<GetOrderByIdQuery,GetOrderByIdVM>
{
    IOrderRepository  _orderRepository;
    IMapper _mapper;
    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderByIdVM> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order= _orderRepository.GetById(request.OrderId);
        var result = _mapper.Map<GetOrderByIdVM>(order);
        return result;
    }
}