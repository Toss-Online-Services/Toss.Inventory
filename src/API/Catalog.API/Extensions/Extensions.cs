using Application.Infrastructure.IntegrationEvents;
using Application.Infrastructure.Behaviours;
using Application.Infrastructure.IntegrationEvents.EventHandling;
using Catalog.API;
using Catalog.API.Infrastructure;
using Catalog.API.Services;
using Infrastructure.EventBus.Extensions;
using Infrastructure.EventBusRabbitMQ;
using Microsoft.SemanticKernel;
using Service.ServiceDefaults;
public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {

        var services = builder.Services;

        // Add the authentication services to DI
        builder.AddDefaultAuthentication();

        builder.AddNpgsqlDbContext<CatalogContext>("catalogdb", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql(builder =>
            {
                builder.UseVector();
            });
        });

        // REVIEW: This is done for development ease but shouldn't be here in production
        builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();

        // Add the integration services that consume the DbContext
        builder.Services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<CatalogContext>>();

        builder.Services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();

        builder.AddRabbitMqEventBus("eventbus")
               .AddSubscription<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>()
               .AddSubscription<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();

        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        builder.Services.AddOptions<CatalogOptions>()
            .BindConfiguration(nameof(CatalogOptions));

        if (builder.Configuration["AI:Onnx:EmbeddingModelPath"] is string modelPath &&
            builder.Configuration["AI:Onnx:EmbeddingVocabPath"] is string vocabPath)
        {
            builder.Services.AddBertOnnxTextEmbeddingGeneration(modelPath, vocabPath);
        }
        else if (!string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("openai")))
        {
            builder.AddAzureOpenAIClient("openai");
            builder.Services.AddOpenAITextEmbeddingGeneration(builder.Configuration["AIOptions:OpenAI:EmbeddingName"] ?? "text-embedding-3-small");
        }

        builder.Services.AddSingleton<ICatalogAI, CatalogAI>();
    }
}
