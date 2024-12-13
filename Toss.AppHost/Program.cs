var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Investory_API>("investory-api");

builder.Build().Run();
