using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ErrorNotMappedEF3
{
    public class TestDbContext : DbContext
    {
        public ILoggerFactory loggerFactory;
        private readonly string connectionString;

        public virtual DbSet<Customer> Customers { get; set; }

        public TestDbContext(string connectionString) : base()
        {
            loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

    }
}
