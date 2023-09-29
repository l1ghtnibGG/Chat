using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace ChatApp.Models.Data
{
    public class SeedData
    {
        public static void EnsureData(IApplicationBuilder app)
        {
            ChatDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ChatDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Vlad"
                    },
                    new User
                    {
                        Name = "Vika"

                    },
                   new User
                   {
                       Name = "Petya"
                   },
                   new User
                   {
                       Name = "Vova"
                   },
                   new User
                   {
                       Name = "Masha"
                   },
                   new User
                   {
                       Name = "Nika"
                   },
                   new User
                   {
                       Name = "Shura"
                   });

                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Tag
                    {
                        Name = "Programmer"
                    },
                    new Tag
                    {
                        Name = "Upper"
                    },
                    new Tag
                    {
                        Name = "Lowest"
                    },
                    new Tag
                    {
                        Name = "All"
                    },
                    new Tag
                    {
                        Name = "HR"
                    });

                context.SaveChanges();
            }
        }
    }
}
