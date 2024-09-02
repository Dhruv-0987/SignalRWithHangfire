using Hangfire;
using Microsoft.AspNetCore.SignalR;

namespace SignalRWithHangfire;

public class NotificationService: BackgroundService
{
    private readonly IHubContext<NotificationHub, INotificationsHub> _hubContext;
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly Logger<NotificationService> _logger;

    public NotificationService(
        IHubContext<NotificationHub, INotificationsHub> hubContext,
        IRecurringJobManager recurringJobManager,
        Logger<NotificationService> logger)
    {
        _hubContext = hubContext;
        _recurringJobManager = recurringJobManager;
        _logger = logger;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"executing {nameof(NotificationService)} service");
        
        _recurringJobManager.AddOrUpdate(
            "SendNotification",
            () => _hubContext.Clients.All.SendNotification("Hello from Hangfire"),
            Cron.Minutely);
        
        return Task.CompletedTask;
    }
}