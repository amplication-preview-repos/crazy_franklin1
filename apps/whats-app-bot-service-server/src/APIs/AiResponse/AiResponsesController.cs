using Microsoft.AspNetCore.Mvc;

namespace WhatsAppBotService.APIs;

[ApiController()]
public class AiResponsesController : AiResponsesControllerBase
{
    public AiResponsesController(IAiResponsesService service)
        : base(service) { }
}
