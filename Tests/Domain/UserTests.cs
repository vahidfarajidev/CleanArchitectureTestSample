using System;
using Domain;
using FluentAssertions;
using Xunit;

namespace Tests.Domain
{
    // Unit tests for the Domain layer
    public class UserTests
    {
        [Fact]
        public void Create_Should_SetNameAndEmail_When_ValidInputs()
        {
            // Act
            var user = User.Create("Ali", "ali@example.com");

            // Assert
            user.Name.Should().Be("Ali");
            user.Email.Should().Be("ali@example.com");
            user.Id.Should().NotBe(Guid.Empty);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Create_Should_ThrowException_When_NameIsInvalid(string invalidName)
        {
            // Act
            Action act = () => User.Create(invalidName, "ali@example.com");

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Name is required");
        }

        [Fact]
        public void ChangeName_Should_UpdateName_When_Valid()
        {
            var user = User.Create("Ali", "ali@example.com");

            // Act
            user.ChangeName("Vahid");

            // Assert
            user.Name.Should().Be("Vahid");
        }

        [Fact]
        public void ChangeEmail_Should_ThrowException_When_EmailIsEmpty()
        {
            var user = User.Create("Ali", "ali@example.com");

            // Act
            Action act = () => user.ChangeEmail("");

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Email cannot be empty");
        }
    }
}
