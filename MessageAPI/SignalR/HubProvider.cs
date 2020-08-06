using MessageAPI.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageAPI.SignalR
{
    public class HubProvider : IRealtimeHubProvider
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private static readonly List<string> UserConnections = new List<string>();

        public HubProvider(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(RealtimeEventType eventType, IRealTimeMessage message)
        {
            await _hubContext.Clients.Clients(UserConnections)
                .SendCoreAsync(eventType.ToString(), new object[] { message });
        }

        public Task OnConnected(string connectionId)
        {
            UserConnections.Add(connectionId);
            return Task.CompletedTask;
        }

        public Task OnDisconnected(string connectionId)
        {
            UserConnections.Remove(connectionId);
            return Task.CompletedTask;
        }
    }
}
