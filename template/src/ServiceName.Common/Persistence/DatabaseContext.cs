using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceName.Common.Persistence
{
    public class DatabaseContext : DbContext
    {
        public static string SchemaName { get; } = "swisschain-service-name";
        public static string MigrationHistoryTable { get; } = HistoryRepository.DefaultTableName;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaName);

            base.OnModelCreating(modelBuilder);
        }
    }
}
