using JobListing.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListing
{
    public class DBInitializer
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new App_Context(serviceProvider.GetRequiredService<DbContextOptions<App_Context>>());
            context.Database.EnsureCreated();
            if (await context.USER_TYPE.AnyAsync())
            {
                return;   // DB has been seeded
            }
            var userTypes = new User_Type[]
           {
                    new User_Type{Id=1, Active = true, Name = "Company User"},
                    new User_Type{Id=2, Active = true, Name = "Applicant"}
           };
            foreach (User_Type userType in userTypes)
            {

                context.Add(userType);
            }
            context.Database.OpenConnection();
            context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT dbo.USER_TYPE ON;");
            await context.SaveChangesAsync();
            context.Database.ExecuteSqlRaw(@"SET IDENTITY_INSERT dbo.USER_TYPE OFF;");
            context.Database.CloseConnection();
           

        }
    }
}
