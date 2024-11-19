var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Toss_WebApp>("toss-webapp");

builder.Build().Run();
