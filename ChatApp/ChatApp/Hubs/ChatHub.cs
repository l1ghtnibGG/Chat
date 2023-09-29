using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("Notify", $"has joined the group {roomName}");
        }

        public async Task LeaveRoom(string roomName) 
        {
            await Clients.Group(roomName).SendAsync("Notify", $"has left the group {roomName}");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task Send(string user, string message, string roomName)
        {  
            await Clients.Group(roomName).SendAsync("broadcastMessage", user, message);
        }
    }
}
