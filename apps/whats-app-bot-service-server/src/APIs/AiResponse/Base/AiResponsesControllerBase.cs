using Microsoft.AspNetCore.Mvc;
using WhatsAppBotService.APIs;
using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.APIs.Errors;

namespace WhatsAppBotService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AiResponsesControllerBase : ControllerBase
{
    protected readonly IAiResponsesService _service;

    public AiResponsesControllerBase(IAiResponsesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one AIResponse
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AiResponse>> CreateAiResponse(AiResponseCreateInput input)
    {
        var aiResponse = await _service.CreateAiResponse(input);

        return CreatedAtAction(nameof(AiResponse), new { id = aiResponse.Id }, aiResponse);
    }

    /// <summary>
    /// Delete one AIResponse
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAiResponse(
        [FromRoute()] AiResponseWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAiResponse(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AIResponses
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AiResponse>>> AiResponses(
        [FromQuery()] AiResponseFindManyArgs filter
    )
    {
        return Ok(await _service.AiResponses(filter));
    }

    /// <summary>
    /// Meta data about AIResponse records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AiResponsesMeta(
        [FromQuery()] AiResponseFindManyArgs filter
    )
    {
        return Ok(await _service.AiResponsesMeta(filter));
    }

    /// <summary>
    /// Get one AIResponse
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AiResponse>> AiResponse(
        [FromRoute()] AiResponseWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AiResponse(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one AIResponse
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAiResponse(
        [FromRoute()] AiResponseWhereUniqueInput uniqueId,
        [FromQuery()] AiResponseUpdateInput aiResponseUpdateDto
    )
    {
        try
        {
            await _service.UpdateAiResponse(uniqueId, aiResponseUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
