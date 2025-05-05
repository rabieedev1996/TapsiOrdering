using AutoMapper;
using MediatR;
using Tapsi.Ordering.Application.Contract.SQLDB;

namespace Tapsi.Ordering.Application.Features.Ordering.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, GetOrdersVM>
{
    IOrderRepository _orderRepository;
    IMapper _mapper;

    public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<GetOrdersVM> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.Filter(request.FromDate, request.ToDate
        ,request.From,request.Count);
        var resultData = _mapper.Map<List<GetOrdersVM_Item>>(orders);
        return new GetOrdersVM()
        {
            Items = resultData
        };
    }
}