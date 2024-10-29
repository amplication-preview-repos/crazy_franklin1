using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs.Extensions;

public static class MessagesExtensions
{
    public static Message ToDto(this MessageDbModel model)
    {
        return new Message
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MessageDbModel ToModel(
        this MessageUpdateInput updateDto,
        MessageWhereUniqueInput uniqueId
    )
    {
        var message = new MessageDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            message.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            message.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return message;
    }
}
