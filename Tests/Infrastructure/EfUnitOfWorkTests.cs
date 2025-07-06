using Xunit;
using Infrastructure;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Tests.Infrastructure
{
    // Integration test for EfUnitOfWork
    public class EfUnitOfWorkTests
    {
        [Fact]
        public async Task Commit_Should_SaveChanges_To_Database()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("EfUnitOfWorkTest")
                .Options;

            await using var context = new AppDbContext(options);
            var repo = new EfUserRepository(context);
            var uow = new EfUnitOfWork(context);

            var user = User.Create("Sara", "sara@example.com");
            repo.Add(user);

            // Act
            uow.Commit();

            // Assert
            var savedUser = context.Users.FirstOrDefault(u => u.Email == "sara@example.com");
            Assert.NotNull(savedUser);
        }
    }
}