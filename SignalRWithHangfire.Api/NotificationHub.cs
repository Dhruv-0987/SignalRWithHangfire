using Microsoft.AspNetCore.SignalR;

namespace SignalRWithHangfire;

public interface INotificationsHub
{
    Task SendNotification(string content);
}

public class NotificationHub: Hub<INotificationsHub>
{
    public async Task SendNotification(string content)
    {
        await Clients.All.SendNotification(content);
    }
}