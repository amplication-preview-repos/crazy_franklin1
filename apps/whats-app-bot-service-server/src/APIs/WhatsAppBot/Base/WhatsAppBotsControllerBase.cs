using Microsoft.AspNetCore.Mvc;
using WhatsAppBotService.APIs;
using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.APIs.Errors;

namespace WhatsAppBotService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WhatsAppBotsControllerBase : ControllerBase
{
    protected readonly IWhatsAppBotsService _service;

    public WhatsAppBotsControllerBase(IWhatsAppBotsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WhatsAppBot
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WhatsAppBot>> CreateWhatsAppBot(WhatsAppBotCreateInput input)
    {
        var whatsAppBot = await _service.CreateWhatsAppBot(input);

        return CreatedAtAction(nameof(WhatsAppBot), new { id = whatsAppBot.Id }, whatsAppBot);
    }

    /// <summary>
    /// Delete one WhatsAppBot
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWhatsAppBot(
        [FromRoute()] WhatsAppBotWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWhatsAppBot(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WhatsAppBots
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WhatsAppBot>>> WhatsAppBots(
        [FromQuery()] WhatsAppBotFindManyArgs filter
    )
    {
        return Ok(await _service.WhatsAppBots(filter));
    }

    /// <summary>
    /// Meta data about WhatsAppBot records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WhatsAppBotsMeta(
        [FromQuery()] WhatsAppBotFindManyArgs filter
    )
    {
        return Ok(await _service.WhatsAppBotsMeta(filter));
    }

    /// <summary>
    /// Get one WhatsAppBot
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WhatsAppBot>> WhatsAppBot(
        [FromRoute()] WhatsAppBotWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WhatsAppBot(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one WhatsAppBot
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWhatsAppBot(
        [FromRoute()] WhatsAppBotWhereUniqueInput uniqueId,
        [FromQuery()] WhatsAppBotUpdateInput whatsAppBotUpdateDto
    )
    {
        try
        {
            await _service.UpdateWhatsAppBot(uniqueId, whatsAppBotUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
