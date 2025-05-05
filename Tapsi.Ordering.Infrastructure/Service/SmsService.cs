using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain;
using Tapsi.Ordering.Infrastructure.ServiceImpls.SmsImpl;
using Tapsi.Ordering.Infrastructure.ServiceImpls.SMSImpl.FarazSMS;

namespace Tapsi.Ordering.Infrastructure.Service;

public class SmsService : ISmsService
{
    private ISmsImpl _provider;

    public SmsService(Configs configs)
    {
        _provider = new FarazSmsService(configs);
    }
    public async Task Send(string dest, string text)
    {
        await _provider.Send(new List<string> { dest }, text);
    }

    public async Task SendCode(string dest, string code)
    {
        await _provider.SendCode(dest, code);
    }
}