using Tapsi.Ordering.Application.Common;
using Tapsi.Ordering.Application.Models;
using Tapsi.Ordering.Domain;
using Tapsi.Ordering.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tapsi.Ordering.Application.Features.Ordering.GetOrders;
using Tapsi.Ordering.Application.Features.Sample.CreateOrder;
using Tapsi.Ordering.Application.Features.Sample.GetOrderById;
using YasgapNew.Api.Filters;

namespace Tapsi.Ordering.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        IMediator _mediator;
        ResponseGenerator _rsponseGenerator;
        public OrderingController(IMediator mediator, ResponseGenerator rsponseGenerator)
        {
            _mediator = mediator;
            _rsponseGenerator = rsponseGenerator;
        }
        [HttpPost("/CreateOrder")]
        [ProducesResponseType(typeof(ApiResponseModel<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand input)
        {
            var resultData = await _mediator.Send(input);
            var resultObj = _rsponseGenerator.GetResponseModel(ResponseCodes.SUCCESS, resultData);
            return resultObj;
        }
        [HttpGet("/GetOrderById")]
        [ProducesResponseType(typeof(ApiResponseModel<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var resultData = await _mediator.Send(new GetOrderByIdQuery()
            {
                OrderId = orderId
            });
            var resultObj = _rsponseGenerator.GetResponseModel(ResponseCodes.SUCCESS, resultData);
            return resultObj;
        }
        [HttpPost("/Orders")]
        [ProducesResponseType(typeof(ApiResponseModel<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Orders(GetOrdersQuery query)
        {
            var resultData = await _mediator.Send(query);
            var resultObj = _rsponseGenerator.GetResponseModel(ResponseCodes.SUCCESS, resultData);
            return resultObj;
        }
    }
}
