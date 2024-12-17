var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Investory_API>("investory-api");

builder.AddProject<Projects.Buying_Domain>("buying-domain");

builder.Build().Run();
