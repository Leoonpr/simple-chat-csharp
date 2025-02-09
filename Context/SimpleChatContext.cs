using Microsoft.EntityFrameworkCore;

namespace simple_chat_csharp;

public class SimpleChatContext : DbContext
{
  public SimpleChatContext(DbContextOptions<SimpleChatContext> options)
        : base(options)
    {
    }

    public DbSet<Message> Messages { get; set; }

}
