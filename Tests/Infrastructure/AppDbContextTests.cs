using Xunit;
using Infrastructure;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Tests.Infrastructure
{
    // Integration test for AppDbContext
    public class AppDbContextTests
    {
        [Fact]
        public async Task Should_Add_And_Retrieve_User_From_Db()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("AppDbContextTest")
                .Options;

            await using (var context = new AppDbContext(options))
            {
                context.Users.Add(User.Create("Reza", "reza@example.com"));
                await context.SaveChangesAsync();
            }

            await using (var context = new AppDbContext(options))
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == "reza@example.com");
                Assert.NotNull(user);
                Assert.Equal("Reza", user.Name);
            }
        }
    }
}