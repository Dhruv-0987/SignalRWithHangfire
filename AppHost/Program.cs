using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var blazorApp = builder.AddProject<SignalRWithHangfire_Client>("blazor-app-1");

builder.AddProject<SignalRWithHangfire_Api>("signalr-with-hangfire")
    .WithReference(blazorApp);
    
builder.Build().Run();