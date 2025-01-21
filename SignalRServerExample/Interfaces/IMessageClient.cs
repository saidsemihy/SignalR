using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Interfaces;

public interface IMessageClient
{
    Task Clients(List<string> clients);
    Task UserJoined(string connectionId);
    Task UserLeaved(string connectionId);
   // Task SendAsync(string message);
   
    
}