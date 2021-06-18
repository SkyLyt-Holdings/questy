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
    }
}
