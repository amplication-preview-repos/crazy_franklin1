using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;

namespace WhatsAppBotService.APIs;

public interface IWhatsAppBotsService
{
    /// <summary>
    /// Create one WhatsAppBot
    /// </summary>
    public Task<WhatsAppBot> CreateWhatsAppBot(WhatsAppBotCreateInput whatsappbot);

    /// <summary>
    /// Delete one WhatsAppBot
    /// </summary>
    public Task DeleteWhatsAppBot(WhatsAppBotWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WhatsAppBots
    /// </summary>
    public Task<List<WhatsAppBot>> WhatsAppBots(WhatsAppBotFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about WhatsAppBot records
    /// </summary>
    public Task<MetadataDto> WhatsAppBotsMeta(WhatsAppBotFindManyArgs findManyArgs);

    /// <summary>
    /// Get one WhatsAppBot
    /// </summary>
    public Task<WhatsAppBot> WhatsAppBot(WhatsAppBotWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one WhatsAppBot
    /// </summary>
    public Task UpdateWhatsAppBot(
        WhatsAppBotWhereUniqueInput uniqueId,
        WhatsAppBotUpdateInput updateDto
    );
}
