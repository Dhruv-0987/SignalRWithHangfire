using Hangfire;

namespace SignalRWithHangfire;

public static class HangFireExtensions
{
    public static WebApplicationBuilder ConfigureHangfire(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(options =>
        {
            options.UseInMemoryStorage();
        });
        
        builder.Services.AddHangfireServer();

        // This line is to force an instance of IGlobalConfiguration to be created
        // without this the hangfire config is not setup and no services are available
        builder.Services.BuildServiceProvider().GetRequiredService<IGlobalConfiguration>();
        
        return builder;
    }
}