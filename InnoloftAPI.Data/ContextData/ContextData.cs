using InnoloftAPI.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace InnoloftAPI.Data.ContextData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<EventParticipant> EventParticipants { get; set; }

    }
}
