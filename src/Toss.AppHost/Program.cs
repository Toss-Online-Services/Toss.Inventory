using Toss.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddForwardedHeaders();

var redis = builder.AddRedis("redis");
var rabbitMq = builder.AddRabbitMQ("eventbus")
    .WithLifetime(ContainerLifetime.Persistent);
var postgres = builder.AddPostgres("postgres")
    .WithImage("ankane/pgvector")
    .WithImageTag("latest")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin();

var tossDb = postgres.AddDatabase("tossdb");

builder.AddProject<Projects.Toss_Api>("toss-api")
     .WithReference(rabbitMq).WaitFor(rabbitMq)
    .WithReference(tossDb).WaitFor(tossDb)
    .WithHttpHealthCheck("/health");

builder.Build().Run();
