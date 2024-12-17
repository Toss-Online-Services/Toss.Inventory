var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Toss_Api>("toss-api");

builder.Build().Run();
