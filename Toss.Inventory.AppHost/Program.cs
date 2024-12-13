var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Toss_WebApp>("toss-webapp");

builder.AddProject<Projects.Toss_Api>("toss-api");

builder.AddProject<Projects.Toss_WebApi>("toss-webapi");

builder.Build().Run();
