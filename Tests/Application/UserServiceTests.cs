using Application;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using NSubstitute;

namespace Tests.Application
{
    // Unit tests for the Application layer's UserService,
    // using mocks for IUserRepository and IUnitOfWork to isolate dependencies.
    public class UserServiceTests
    {
        [Fact]
        public void AddUser_Should_AddUser_And_Commit()
        {
            var repo = Substitute.For<IUserRepository>();
            var uow = Substitute.For<IUnitOfWork>();
            var service = new UserService(repo, uow);

            var dto = new AddUserDto { Name = "Ali", Email = "ali@example.com" };
            service.AddUser(dto);

            repo.Received().Add(Arg.Is<User>(u => u.Name == "Ali" && u.Email == "ali@example.com"));
            uow.Received().Commit();
        }

        [Fact]
        public void EditUser_Should_UpdateFields_And_Commit()
        {
            var user = User.Create("Ali", "ali@example.com");
            var repo = Substitute.For<IUserRepository>();
            repo.GetById(user.Id).Returns(user);
            var uow = Substitute.For<IUnitOfWork>();
            var service = new UserService(repo, uow);

            var dto = new EditUserDto { Id = user.Id, Name = "Vahid", Email = "vahid@example.com" };
            service.EditUser(dto);

            user.Name.Should().Be("Vahid");
            user.Email.Should().Be("vahid@example.com");
            repo.Received().Update(user);
            uow.Received().Commit();
        }
    }
}

