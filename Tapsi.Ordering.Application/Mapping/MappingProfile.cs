using AutoMapper;
using Tapsi.Ordering.Application.Features.Ordering.GetOrders;
using Tapsi.Ordering.Application.Features.Sample.CreateOrder;
using Tapsi.Ordering.Application.Features.Sample.GetOrderById;
using Tapsi.Ordering.Domain.Entities.SQL;

namespace Tapsi.Ordering.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap< Order,GetOrderByIdVM>()
            .ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(src=>src.JalaliCreatedAt))
            .ReverseMap();
        CreateMap< Order,GetOrdersVM_Item>()
            .ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(src=>src.JalaliCreatedAt))
            .ReverseMap();
    }
}