using ExpiryLogger.DataAccessLayer;
using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;
using ExpiryLogger.NotifierService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostBuilderContext, services) =>
    {
        services
            .AddEntityFrameworkMySql()
            .AddDbContext<ExpirationLoggerContext>()
            .AddScoped<IRepository<Category>, MariaDbRepository<Category>>()
            .AddScoped<IRepository<Location>, MariaDbRepository<Location>>()
            .AddScoped<IRepository<Product>, MariaDbRepository<Product>>()
            .AddScoped<IRepository<ProductDetail>, ProductDetailsRepository>()
            .AddScoped<IRepository<User>, MariaDbRepository<User>>()
            .AddScoped<IEmailBodyBuilder, EmailBodyBuilder>()
            .AddScoped<IEmailBuilder, EmailBuilder>()
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IExpirationNotifier, ExpirationNotifier>()
            .AddScoped<IItemsRetriever, ItemsRetriever>()
            .AddScoped<ITimeframeRetriever, TimeframeRetriever>()
            ;
    })
    .Build();

InvokeWorkflow(host.Services);

await host.RunAsync();

static void InvokeWorkflow(IServiceProvider services)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;

    var expirationNotifier = provider.GetRequiredService<IExpirationNotifier>();
    ArgumentNullException.ThrowIfNull(expirationNotifier);

    expirationNotifier.NotifyRecipients();
}
