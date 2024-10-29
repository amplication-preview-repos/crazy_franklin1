using Microsoft.EntityFrameworkCore;
using WhatsAppBotService.APIs;
using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.APIs.Errors;
using WhatsAppBotService.APIs.Extensions;
using WhatsAppBotService.Infrastructure;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs;

public abstract class WhatsAppBotsServiceBase : IWhatsAppBotsService
{
    protected readonly WhatsAppBotServiceDbContext _context;

    public WhatsAppBotsServiceBase(WhatsAppBotServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WhatsAppBot
    /// </summary>
    public async Task<WhatsAppBot> CreateWhatsAppBot(WhatsAppBotCreateInput createDto)
    {
        var whatsAppBot = new WhatsAppBotDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            whatsAppBot.Id = createDto.Id;
        }

        _context.WhatsAppBots.Add(whatsAppBot);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WhatsAppBotDbModel>(whatsAppBot.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WhatsAppBot
    /// </summary>
    public async Task DeleteWhatsAppBot(WhatsAppBotWhereUniqueInput uniqueId)
    {
        var whatsAppBot = await _context.WhatsAppBots.FindAsync(uniqueId.Id);
        if (whatsAppBot == null)
        {
            throw new NotFoundException();
        }

        _context.WhatsAppBots.Remove(whatsAppBot);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WhatsAppBots
    /// </summary>
    public async Task<List<WhatsAppBot>> WhatsAppBots(WhatsAppBotFindManyArgs findManyArgs)
    {
        var whatsAppBots = await _context
            .WhatsAppBots.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return whatsAppBots.ConvertAll(whatsAppBot => whatsAppBot.ToDto());
    }

    /// <summary>
    /// Meta data about WhatsAppBot records
    /// </summary>
    public async Task<MetadataDto> WhatsAppBotsMeta(WhatsAppBotFindManyArgs findManyArgs)
    {
        var count = await _context.WhatsAppBots.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WhatsAppBot
    /// </summary>
    public async Task<WhatsAppBot> WhatsAppBot(WhatsAppBotWhereUniqueInput uniqueId)
    {
        var whatsAppBots = await this.WhatsAppBots(
            new WhatsAppBotFindManyArgs { Where = new WhatsAppBotWhereInput { Id = uniqueId.Id } }
        );
        var whatsAppBot = whatsAppBots.FirstOrDefault();
        if (whatsAppBot == null)
        {
            throw new NotFoundException();
        }

        return whatsAppBot;
    }

    /// <summary>
    /// Update one WhatsAppBot
    /// </summary>
    public async Task UpdateWhatsAppBot(
        WhatsAppBotWhereUniqueInput uniqueId,
        WhatsAppBotUpdateInput updateDto
    )
    {
        var whatsAppBot = updateDto.ToModel(uniqueId);

        _context.Entry(whatsAppBot).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WhatsAppBots.Any(e => e.Id == whatsAppBot.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
