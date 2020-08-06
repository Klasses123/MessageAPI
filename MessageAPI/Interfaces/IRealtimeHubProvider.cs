using MessageAPI.SignalR;
using System.Threading.Tasks;

namespace MessageAPI.Interfaces
{
    public interface IRealtimeHubProvider
    {
        Task SendMessageAsync(RealtimeEventType eventType, IRealTimeMessage message);
        Task OnConnected(string connectionId);
        Task OnDisconnected(string connectionId);
    }
}
