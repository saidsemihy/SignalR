using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Business;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs;

public class MyHub :Hub<IMessageClient>
{ 
    readonly MyBusiness _myBusiness;
    public MyHub(MyBusiness myBusiness)
    {
        _myBusiness = myBusiness;
    }

    
    static List<string> clients = new List<string>();
    
    public async Task SendMessageAsync(string message)
    {
        _myBusiness.SendMessageAsync( message);// Client'lerde ReceiveMessage için kullanılır. ismi bu olanları temsil eder konuşmaları okur.
    }
    
    
    public override async Task OnConnectedAsync()
    {
        clients.Add(Context.ConnectionId);
        // await Clients.All.SendAsync("clients", clients);   
        // await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        //await Clients.All.Clients(clients); 
        
        // interface adını yanlış yazmaktan kurtarıyor kalıtımla almak
        await Clients.All.Clients(clients);
        await Clients.All.UserJoined(Context.ConnectionId);
    }
    
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        clients.Remove(Context.ConnectionId);
        // await Clients.All.SendAsync("clients", clients);
        // await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        await Clients.All.Clients(clients);
        await Clients.All.UserLeaved(Context.ConnectionId);
    }
    
}