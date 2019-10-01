using ErrorAnyEF3.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ErrorAnyEF3
{
    class Program
    {
        public const string ConnectionString = "Server=localhost\\sqlexpress;Database=EFTest;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            using (var ctx = new TestDbContext(ConnectionString))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                TestData.InsertTestData(ctx);

                var masterCirId = 1;
                var query = from e in ctx.Entities
                            select e;
                query = query.Where(Filter.GetViewModeFilterCIRMaintenance(masterCirId, ctx.Entities)).OrderBy(e => e.Code).Skip(0).Take(10);

                 var list = query.ToList();
                Console.WriteLine($"Read {list.Count} records");
            }
            Console.ReadKey();
        }

    }
}
