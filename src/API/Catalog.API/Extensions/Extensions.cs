using Microsoft.SemanticKernel;
using Infrastructure.EventBusRabbitMQ;
using Infrastructure.EventBus.Extensions;
using Infrastructure.Data;
using Catalog.API.IntegrationEvents.EventHandling;
using Catalog.API.IntegrationEvents;
using Catalog.API.Services;
using Catalog.API.IntegrationEvents.Events;
using Catalog.API;
using Service.ServiceDefaults;
using Application.Infrastructure.Services;
using Application.Infrastructure.Behaviours;
using FluentValidation;
using Infrastructure.Repositories;
using Domain.Repositories;
using Infrastructure.Data.Idempotency;
using Microsoft.AspNetCore.Mvc;
using NSwag.Generation.Processors.Security;
using NSwag;
using Application.Features.Products.Commands.CreateProduct;
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
        //builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();

        // Add the integration services that consume the DbContext
        builder.Services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<CatalogContext>>();

        builder.Services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();

        builder.AddRabbitMqEventBus("eventbus")
            .AddEventBusSubscriptions();

        builder.Services.AddOptions<CatalogOptions>()
            .BindConfiguration(nameof(CatalogOptions));
        services.AddHttpContextAccessor();
        services.AddTransient<IIdentityService, IdentityService>();

        // Configure mediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
            cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
        });

        services.AddAutoMapper(typeof(Program));

        // Register the command validators for the validator behavior (validators based on FluentValidation library)
        services.AddSingleton<IValidator<CreateProductRequest>, CreateProductCommandValidator>();
       
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRequestManager, RequestManager>();

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

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "Template API";

            // Add JWT
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
              
    }

    
    private static void AddEventBusSubscriptions(this IEventBusBuilder eventBus)
    {
        eventBus.AddSubscription<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
        eventBus.AddSubscription<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();
    }
}
