using FluentValidation;
using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain.Enums;

namespace Tapsi.Ordering.Application.Features.Sample.CreateOrder;

public class CreateOrderValidator: AbstractValidator<CreateOrderCommand>
{
    IMessageService _messageService;

    public CreateOrderValidator(IMessageService messageService)
    {
        _messageService = messageService;
        RuleFor(p => p.CustomerName)
        .NotEmpty().WithMessage(_messageService.GetMessage(MessageCodes.STATUS_VALIDATION_ERROR, Langs.FA));
    }
}
