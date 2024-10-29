using WhatsAppBotService.Infrastructure;

namespace WhatsAppBotService.APIs;

public class WhatsAppBotsService : WhatsAppBotsServiceBase
{
    public WhatsAppBotsService(WhatsAppBotServiceDbContext context)
        : base(context) { }
}
