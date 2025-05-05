﻿using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Domain.Enums;
using Tapsi.Ordering.Infrastructure.ServiceImpls.MessagingImpl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tapsi.Ordering.Infrastructure.Service
{
    public class MessageService : IMessageService
    {
        private IServiceProvider _serviceProvider;
        private IMessagesImpl _messageImpl;


        public MessageService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public string GetMessage(MessageCodes code,Langs lang)
        {
           

            switch (lang)
            {
                case Langs.FA:
                    _messageImpl = _serviceProvider.GetRequiredService<Fa_MessagesImpl>();
                    break;
                case Langs.EN:
                    _messageImpl = _serviceProvider.GetRequiredService<En_MessagesImpl>();
                    break;
            }
            return _messageImpl.GetMessage(code);
        }
    }
}
