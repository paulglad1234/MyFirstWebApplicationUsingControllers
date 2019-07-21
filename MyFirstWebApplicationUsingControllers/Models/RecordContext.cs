using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApplicationUsingControllers.Models
{
    public sealed class RecordContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public RecordContext(DbContextOptions<RecordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
