using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs;

public class MessageHub:Hub
{
    // public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
    //
    // {
    //     #region Caller
    //
    //     //Sadece server'a bildirim gönderen client'la iletişim kurar
    //     //await Clients.Caller.SendAsync("ReceiveMessage", message);
    //
    //     #endregion
    //
    //     #region All
    //
    //     //Server'a bağlı olan tüm client'lara bildirim gönderir
    //     //await Clients.All.SendAsync("ReceiveMessage", message);
    //
    //     #endregion
    //
    //     #region Other
    //
    //     //Server'a bağlı olan tüm client'lara bildirim gönderir fakat gönderen client'a bildirim göndermez
    //     // await Clients.Others.SendAsync("ReceiveMessage", message);
    //     #endregion
    //
    //     #region Hub Clients Metotları
    //
    //     #region AllExcept
    //
    //     //Belirtilen client'lar hariç tüm client'lara bildirim gönderir
    //     
    //
    //     #endregion
    //
    //     #region Client
    //     // Servera bağlı olan belirtilen client'a bildirim gönderir(Belirli kişiye özelden mesaj)
    //     Clients.Clients(connectionIds.First()).SendAsync("ReceiveMessage", message);
    //     
    //
    //     #endregion
    //
    //     #region Clients
    //
    //     Clients.Clients(connectionIds).SendAsync("ReceiveMessage", message);
    //
    //     #endregion
    //
    //     #region Group
    //
    //     //Belirtilen gruptaki client'lara bildirim gönderir
    //     //Önce grup oluşturulmalı ve ardından clientler sbuc. olmalı
    //
    //     #endregion
    //
    //     
    //
    //     #endregion
    //     
    // }
    
    public async Task SendMessageAsync(string message, string groupName)
    {
        await Clients.Group(groupName).SendAsync("ReceiveMessage", message);

    }
    
    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
    }
    
    public async  Task addGroup(string connectionId,string groupName)
    {
        await Groups.AddToGroupAsync(connectionId, groupName); // böyle grup varsa o gruba client ekle yoksa oluştur ekle
    }
}