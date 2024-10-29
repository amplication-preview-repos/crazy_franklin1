using Microsoft.AspNetCore.Mvc;

namespace WhatsAppBotService.APIs;

[ApiController()]
public class MessagesController : MessagesControllerBase
{
    public MessagesController(IMessagesService service)
        : base(service) { }
}
