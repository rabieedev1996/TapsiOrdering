using Tapsi.Ordering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapsi.Ordering.Infrastructure.ServiceImpls.MessagingImpl
{
    public interface IMessagesImpl
    {
        string GetMessage(MessageCodes code);
       
    }
}
