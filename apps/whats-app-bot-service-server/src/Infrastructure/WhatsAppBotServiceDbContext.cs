using Microsoft.EntityFrameworkCore;
using WhatsAppBotService.Infrastructure.Models;

namespace WhatsAppBotService.Infrastructure;

public class WhatsAppBotServiceDbContext : DbContext
{
    public WhatsAppBotServiceDbContext(DbContextOptions<WhatsAppBotServiceDbContext> options)
        : base(options) { }

    public DbSet<MessageDbModel> Messages { get; set; }

    public DbSet<WhatsAppBotDbModel> WhatsAppBots { get; set; }

    public DbSet<AiResponseDbModel> AiResponses { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
