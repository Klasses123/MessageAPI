using MessageAPI.Interfaces;
using MessageAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageAPI.SignalR
{
    /// <summary>
    /// Classs for notify users about messages events
    /// </summary>
    public class MessageNotifier : IMessageNotifier
    {
        private readonly IRealtimeHubProvider _hubProvider;
        private readonly IMessageService _messageService;
        public MessageNotifier(IRealtimeHubProvider hubProvider,
            IMessageService messageService)
        {
            _hubProvider = hubProvider;
            _messageService = messageService;
        }

        public async Task MessageSent(Message message)
        {
            var createdMessage = await _messageService.CreateMessage(message);
            await _hubProvider.SendMessageAsync(
                RealtimeEventType.MessageEvent,
                new RealtimeMessageViewModel(createdMessage));
        }
    }
}
