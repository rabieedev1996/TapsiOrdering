using FluentValidation;
using Tapsi.Ordering.Application.Contract.Services;

namespace Tapsi.Ordering.Application.Features.Ordering.GetOrders;

public class GetOrdersValidator :AbstractValidator<GetOrdersVM>
{
    IMessageService _messageService;

    public GetOrdersValidator(IMessageService messageService)
    {
        _messageService = messageService;
        // RuleFor(p => p.RequiredParam)
        // .NotNull().WithMessage(_messageService.GetMessage(MessageCodes.MESSAGE_REQUIRED_PARAM, Langs.FA));
    }
}