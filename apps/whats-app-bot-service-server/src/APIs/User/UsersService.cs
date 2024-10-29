using WhatsAppBotService.Infrastructure;

namespace WhatsAppBotService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(WhatsAppBotServiceDbContext context)
        : base(context) { }
}
