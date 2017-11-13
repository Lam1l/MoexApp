using System.Linq;
using MoexAppStore.Models;

namespace MoexAppStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MoexAppDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Profiles.Any())
                return;

            var profile = new Profile {
                Username = "Lamil",
                Login = "atheistik@gmail.com",
                Password = "B03A04r0",
                ProfileId = 0
            };

            context.Profiles.Add(profile);
            context.SaveChanges();
        }
    }
}