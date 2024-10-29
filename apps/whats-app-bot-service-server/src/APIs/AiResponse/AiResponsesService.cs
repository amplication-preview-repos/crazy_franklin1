using WhatsAppBotService.Infrastructure;

namespace WhatsAppBotService.APIs;

public class AiResponsesService : AiResponsesServiceBase
{
    public AiResponsesService(WhatsAppBotServiceDbContext context)
        : base(context) { }
}
