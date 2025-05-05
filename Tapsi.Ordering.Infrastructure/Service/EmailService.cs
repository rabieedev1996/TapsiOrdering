using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain;
using Tapsi.Ordering.Infrastructure.ServiceImpls.SmsImpl.Mailzila;
using Tapsi.Ordering.Infrastructure.ServiceImpls.SmsImpl.SMTP;

namespace Tapsi.Ordering.Infrastructure.Service;

public class EmailService : IEmailService
{
    private ISMTPService _smtpService;
    private IMailzilaService _mailzilaService;

    public EmailService(Configs config)
    {
        _smtpService = new SMTPService(config);
        _mailzilaService = new MailzilaService(config);
    }

    public async Task SendCode(string destination, string code)
    {
        string templateId = "1178086";
        _mailzilaService.MailZilaSendMail(destination, new List<string>() { destination }, templateId, "RegisterCode",
            new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("code", code)
            });
    }

    public async Task Send(string destination, string html, string subject)
    {
        await _smtpService.Send(destination, html, subject);
    }
}