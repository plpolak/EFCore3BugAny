using ErrorAnyEF3.DbModel;
using System;
using System.Linq;

namespace ErrorAnyEF3
{
    public static class TestData
    {
        public static void InsertTestData(TestDbContext ctx)
        {
            if (ctx.UserLogins.FirstOrDefault(u => u.Id == 1) != null)
                return;

            var userLogin = new DbUserLogin()
            {
                Initials = "TE",
                UserPrincipalName = "testuser@test.com",
                DisplayName = "Test user"
            };
            ctx.UserLogins.Add(userLogin);

            var entityType = new DbEntityType()
            {
                Description = "Test",
                TableName = "TEST",
                CreatedAt = DateTime.Now,
                CreatedByUserLogin = userLogin,
                ModifiedAt = DateTime.Now,
                ModifiedByUserLogin = userLogin
            };
            ctx.EntityTypes.Add(entityType);
                
            var cir = new DbCIR()
            {
                Code = "C1",
                Description = "D1",
                
                CreatedAt = DateTime.Now,
                CreatedByUserLogin = userLogin,
                ModifiedAt = DateTime.Now,
                ModifiedByUserLogin = userLogin
            };
            ctx.CIRs.Add(cir);

            for (int i = 0; i < 10; i++)
            {
                ctx.Entities.Add(new DbEntity()
                {
                    Code = $"C{i}",
                    Description = $"D{i}",
                    EntityKey = 123,
                    EntityType = entityType,
                    IsActive = true,
                    CreatorCIR = cir,
                    MasterCIR = cir,
                    CreatedAt = DateTime.Now,
                    CreatedByUserLogin = userLogin,
                    ModifiedAt = DateTime.Now,
                    ModifiedByUserLogin = userLogin
                });
            }

            ctx.SaveChanges();
        }
    }
}
