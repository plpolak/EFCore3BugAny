using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ErrorAnyEF3.DbModel
{
    public class TestDbContext : DbContext
    {
        public ILoggerFactory loggerFactory;
        private readonly string connectionString;

        public virtual DbSet<DbCIR> CIRs { get; set; }
        public virtual DbSet<DbEntity> Entities { get; set; }
        public virtual DbSet<DbEntityType> EntityTypes { get; set; }
        public virtual DbSet<DbUserLogin> UserLogins { get; set; }

        public TestDbContext(string connectionString): base()
        {
            loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
