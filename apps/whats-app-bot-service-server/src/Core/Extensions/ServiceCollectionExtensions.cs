using WhatsAppBotService.APIs;

namespace WhatsAppBotService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAiResponsesService, AiResponsesService>();
        services.AddScoped<IMessagesService, MessagesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IWhatsAppBotsService, WhatsAppBotsService>();
    }
}
