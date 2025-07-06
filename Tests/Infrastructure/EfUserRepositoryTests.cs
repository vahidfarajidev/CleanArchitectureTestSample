using Xunit;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using FluentAssertions;

namespace Tests.Infrastructure
{
    // Integration tests for Infrastructure layer
    public class EfUserRepositoryTests
    {
        [Fact]
        public void Add_Should_Persist_User_In_Database()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // isolated DB
                .Options;

            using var context = new AppDbContext(options);
            var repo = new EfUserRepository(context);

            var user = User.Create("Ali", "ali@example.com");
            repo.Add(user);
            context.SaveChanges();

            var savedUser = context.Users.Find(user.Id);

            savedUser.Should().NotBeNull();
            savedUser.Name.Should().Be("Ali");
            savedUser.Email.Should().Be("ali@example.com");
        }
    }
}
