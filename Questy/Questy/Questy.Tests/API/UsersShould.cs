using Questy.API;
using Questy.Infrastructure.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Questy.Tests.API
{
    public class UsersShould : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public UsersShould(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContentHelper.GetToken());
        }

        [Fact]
        public async Task LogInSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/users/login",
                Body = new UserRequestDTO
                {
                    Username = "Slimelord",
                    Password = "Revan456lord!"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("token", content);
        }
        [Fact]
        public async Task CreateUserSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/users",
                Body = new AddNewUserRequestDTO
                {
                    Username = "Slimelord111",
                    Password = "Revan456lord111",
                    Email = "tatteddev@gmail.com",
                    IsAdmin = false
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("Slimelord111", content);
        }

        [Fact]
        public async Task GetUserInfoSuccessfully()
        {
            // Arrange
            string url = "/api/users/1";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("username", content);
        }
        [Fact]
        public async Task GetUsersSuccessfully()
        {
            // Arrange
            string url = "/api/users";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [Fact]
        public async Task ChangeUserStatusSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/users/ChangeUserStatus",
                Body = new UserStatusDTO
                {
                     UserID = 1,
                     IsActive = false
                }
            };
            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
