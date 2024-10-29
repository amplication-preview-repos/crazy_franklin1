using Microsoft.EntityFrameworkCore;
using WhatsAppBotService.APIs;
using WhatsAppBotService.APIs.Common;
using WhatsAppBotService.APIs.Dtos;
using WhatsAppBotService.APIs.Errors;
using WhatsAppBotService.APIs.Extensions;
using WhatsAppBotService.Infrastructure;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.APIs;

public abstract class AiResponsesServiceBase : IAiResponsesService
{
    protected readonly WhatsAppBotServiceDbContext _context;

    public AiResponsesServiceBase(WhatsAppBotServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one AIResponse
    /// </summary>
    public async Task<AiResponse> CreateAiResponse(AiResponseCreateInput createDto)
    {
        var aiResponse = new AiResponseDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            aiResponse.Id = createDto.Id;
        }

        _context.AiResponses.Add(aiResponse);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AiResponseDbModel>(aiResponse.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one AIResponse
    /// </summary>
    public async Task DeleteAiResponse(AiResponseWhereUniqueInput uniqueId)
    {
        var aiResponse = await _context.AiResponses.FindAsync(uniqueId.Id);
        if (aiResponse == null)
        {
            throw new NotFoundException();
        }

        _context.AiResponses.Remove(aiResponse);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AIResponses
    /// </summary>
    public async Task<List<AiResponse>> AiResponses(AiResponseFindManyArgs findManyArgs)
    {
        var aiResponses = await _context
            .AiResponses.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return aiResponses.ConvertAll(aiResponse => aiResponse.ToDto());
    }

    /// <summary>
    /// Meta data about AIResponse records
    /// </summary>
    public async Task<MetadataDto> AiResponsesMeta(AiResponseFindManyArgs findManyArgs)
    {
        var count = await _context.AiResponses.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one AIResponse
    /// </summary>
    public async Task<AiResponse> AiResponse(AiResponseWhereUniqueInput uniqueId)
    {
        var aiResponses = await this.AiResponses(
            new AiResponseFindManyArgs { Where = new AiResponseWhereInput { Id = uniqueId.Id } }
        );
        var aiResponse = aiResponses.FirstOrDefault();
        if (aiResponse == null)
        {
            throw new NotFoundException();
        }

        return aiResponse;
    }

    /// <summary>
    /// Update one AIResponse
    /// </summary>
    public async Task UpdateAiResponse(
        AiResponseWhereUniqueInput uniqueId,
        AiResponseUpdateInput updateDto
    )
    {
        var aiResponse = updateDto.ToModel(uniqueId);

        _context.Entry(aiResponse).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AiResponses.Any(e => e.Id == aiResponse.Id))
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
