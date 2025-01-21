using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs;

public class MessageHub:Hub
{
    public async Task SendMessageAsync(string message)
    {
        #region Caller

        //Sadece server'a bildirim gönderen client'la iletişim kurar
        //await Clients.Caller.SendAsync("ReceiveMessage", message);

        #endregion

        #region All

        //Server'a bağlı olan tüm client'lara bildirim gönderir
        //await Clients.All.SendAsync("ReceiveMessage", message);

        #endregion

        #region Other

        //Server'a bağlı olan tüm client'lara bildirim gönderir fakat gönderen client'a bildirim göndermez
        await Clients.Others.SendAsync("ReceiveMessage", message);
        #endregion
    }
}