namespace Tapsi.Ordering.Infrastructure.ServiceImpls.SmsImpl;

public interface ISmsImpl
{
     Task Send(List<string> dest, string message);
     Task SendCode(string dest, string code);
}