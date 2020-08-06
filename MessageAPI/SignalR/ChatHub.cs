using AutoMapper;
using MessageAPI.Interfaces;
using MessageAPI.Models;
using MessageAPI.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace MessageAPI.SignalR
{
    /// <summary>
    /// Selfcreated hub for SignalR connection/events
    /// </summary>
    public class ChatHub : Hub
    {
        private IMessageService MessageService { get; }
        private IMessageNotifier MessageNotifier { get; }
        private IMapper Mapper { get; }
        private IRealtimeHubProvider HubProvider { get; }
        public ChatHub(IMessageService messageService,
            IMessageNotifier messageNotifier,
            IMapper mapper,
            IRealtimeHubProvider hubProvider)
        {
            MessageService = messageService;
            MessageNotifier = messageNotifier;
            Mapper = mapper;
            HubProvider = hubProvider;
        }

        [HubMethodName("new-message")]
        public async Task NewMessage(MessageViewModel request)
        {
            await MessageNotifier.MessageSent(Mapper.Map<Message>(request));
        }


        public override async Task OnConnectedAsync()
        {
            await HubProvider.OnConnected(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await HubProvider.OnDisconnected(Context.ConnectionId);
        }
    }
}
