using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ErrorAnyEF3.DbModel
{
    public class TestDbContext : DbContext
    {
        public const string ConnectionString = "...";

        public ILoggerFactory _loggerFactory;

        public virtual DbSet<DbCIR> CIRs { get; set; }
        public virtual DbSet<DbEntity> Entities { get; set; }
        public virtual DbSet<DbEntityType> EntityTypes { get; set; }
        public virtual DbSet<DbUserLogin> UserLogins { get; set; }

        public TestDbContext(): base()
        {
            //_loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
