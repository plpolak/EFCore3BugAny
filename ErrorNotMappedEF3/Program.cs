using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ErrorNotMappedEF3
{
    class Program
    {
        const string ConnectionString = "";

        static async Task Main(string[] args)
        {
            using (var ctx = new TestDbContext(ConnectionString))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                ctx.Customers.Add(new Customer()
                {
                    TestDescription = "Test"
                });

                await ctx.SaveChangesAsync();

                var count = await ctx.Customers.CountAsync(f => f.TestDescription == "Test");
                Console.WriteLine($"Count: {count}");
            }
            Console.ReadKey();
        }
    }
}
