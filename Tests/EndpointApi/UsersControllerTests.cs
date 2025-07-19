
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application;
using Domain;
using EndpointApi;
using EndpointApi.Controllers;
using FluentAssertions;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NSubstitute;
using Tests.Utilities;
using Xunit;

namespace Tests.EndpointApi
{
    public class UsersControllerTests
    {
        // ✅ 1. Unit Test with Mock
        [Fact]
        public void Add_Should_Call_Service()
        {
            var mockService = Substitute.For<IUserService>();
            var controller = new UsersController(mockService);
            var dto = new AddUserDto { Name = "Ali", Email = "ali@example.com" };

            var result = controller.Add(dto);

            result.Should().BeOfType<OkResult>();
            mockService.Received().AddUser(dto);
        }

        // ✅ 2. Integration Test (In-Memory)
        [Fact]
        public async Task Add_Should_Return_Ok_In_Integration()
        {
            await using var factory = new CustomWebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var dto = new AddUserDto { Name = "Vahid", Email = "vahid@example.com" };
            var response = await client.PostAsJsonAsync("/api/users", dto);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        // ✅ 3. Real HTTP Test with WebApplicationFactory
        [Fact]
        public async Task Edit_Should_Return_BadRequest_When_IdMismatch()
        {
            await using var factory = new CustomWebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var dto = new EditUserDto
            {
                Id = Guid.NewGuid(),
                Name = "Updated",
                Email = "updated@example.com"
            };

            var response = await client.PutAsJsonAsync($"/api/users/{Guid.NewGuid()}", dto);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
