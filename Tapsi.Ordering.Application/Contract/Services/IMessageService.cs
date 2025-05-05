using Tapsi.Ordering.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapsi.Ordering.Application.Contract.Services
{
    public interface IMessageService
    {
        string GetMessage(MessageCodes code, Langs lang);
    }
}
