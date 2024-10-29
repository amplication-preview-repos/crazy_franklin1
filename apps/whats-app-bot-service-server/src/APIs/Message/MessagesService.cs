using WhatsAppBotService.Infrastructure;

namespace WhatsAppBotService.APIs;

public class MessagesService : MessagesServiceBase
{
    public MessagesService(WhatsAppBotServiceDbContext context)
        : base(context) { }
}
