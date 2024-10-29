using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;

namespace WhatsAppBotService.APIs;

public interface IAiResponsesService
{
    /// <summary>
    /// Create one AIResponse
    /// </summary>
    public Task<AiResponse> CreateAiResponse(AiResponseCreateInput airesponse);

    /// <summary>
    /// Delete one AIResponse
    /// </summary>
    public Task DeleteAiResponse(AiResponseWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AIResponses
    /// </summary>
    public Task<List<AiResponse>> AiResponses(AiResponseFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about AIResponse records
    /// </summary>
    public Task<MetadataDto> AiResponsesMeta(AiResponseFindManyArgs findManyArgs);

    /// <summary>
    /// Get one AIResponse
    /// </summary>
    public Task<AiResponse> AiResponse(AiResponseWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one AIResponse
    /// </summary>
    public Task UpdateAiResponse(
        AiResponseWhereUniqueInput uniqueId,
        AiResponseUpdateInput updateDto
    );
}
