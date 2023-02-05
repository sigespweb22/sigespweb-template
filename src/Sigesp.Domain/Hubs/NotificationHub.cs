using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Sigesp.Domain.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessageAsync(string topico, object message)
        {
            await Clients.All.SendAsync(topico, message);
        }

        public async Task JoinGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(null, groupName);
        }

        public async Task LeaveGroup(string connectionId, string groupName)
        {
            await Groups.RemoveFromGroupAsync(connectionId, groupName);
        }
    }
}