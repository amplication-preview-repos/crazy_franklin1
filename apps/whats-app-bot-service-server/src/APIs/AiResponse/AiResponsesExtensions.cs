using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs.Extensions;

public static class AiResponsesExtensions
{
    public static AiResponse ToDto(this AiResponseDbModel model)
    {
        return new AiResponse
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AiResponseDbModel ToModel(
        this AiResponseUpdateInput updateDto,
        AiResponseWhereUniqueInput uniqueId
    )
    {
        var aiResponse = new AiResponseDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            aiResponse.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            aiResponse.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return aiResponse;
    }
}
