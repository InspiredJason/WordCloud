using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace WordCloud.Persistence
{
    public class Seed
    {
        /// <summary>
        /// Seed some user data
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public static async Task SeedData(DataContext context, UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    Id = "a3dceb41-4d3d-44aa-b197-390d70c1afe1",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                await userManager.CreateAsync(user, "_P@ssw0rd");
            }
        }
    }
}
