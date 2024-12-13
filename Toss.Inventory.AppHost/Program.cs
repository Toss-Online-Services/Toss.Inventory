var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Toss_Api>("toss-api");

builder.AddProject<Projects.WebApp_Server>("webapp-server");

builder.Build().Run();
