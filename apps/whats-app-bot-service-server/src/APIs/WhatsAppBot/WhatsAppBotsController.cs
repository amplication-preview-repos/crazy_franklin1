using Microsoft.AspNetCore.Mvc;

namespace WhatsAppBotService.APIs;

[ApiController()]
public class WhatsAppBotsController : WhatsAppBotsControllerBase
{
    public WhatsAppBotsController(IWhatsAppBotsService service)
        : base(service) { }
}
