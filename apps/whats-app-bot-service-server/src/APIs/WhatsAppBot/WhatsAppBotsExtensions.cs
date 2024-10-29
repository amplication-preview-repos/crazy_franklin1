using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs.Extensions;

public static class WhatsAppBotsExtensions
{
    public static WhatsAppBot ToDto(this WhatsAppBotDbModel model)
    {
        return new WhatsAppBot
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static WhatsAppBotDbModel ToModel(
        this WhatsAppBotUpdateInput updateDto,
        WhatsAppBotWhereUniqueInput uniqueId
    )
    {
        var whatsAppBot = new WhatsAppBotDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            whatsAppBot.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            whatsAppBot.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return whatsAppBot;
    }
}
