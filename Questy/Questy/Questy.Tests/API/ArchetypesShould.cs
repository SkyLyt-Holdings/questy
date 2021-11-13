using Newtonsoft.Json;
using Questy.API;
using Questy.Infrastructure.DTOs.Archetype;
using Questy.Infrastructure.DTOs.QuestTag;
using Questy.Infrastructure.DTOs.Tag;
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
    public class ArchetypesShould : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ArchetypesShould(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContentHelper.GetToken());
        }
        [Fact]
        public async Task GetArchetypeSuccessfully()
        {
            // Arrange
            string url = "/api/archetypes/2";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("description", content);
        }
        [Fact]
        public async Task AddArchetypeSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/archetypes",
                Body = new ArchetypeDTO
                {
                    Description = "Modern Archetype"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("Modern Archetype", content);
        }
        [Fact]
        public async Task UpdateArchetypeSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/archetypes/update",
                Body = new ArchetypeDTO
                {
                    ID = 2,
                    Description = "TEST Archetype"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task GetAllArchetypesSuccessfully()
        {
            // Arrange
            string url = "/api/archetypes/list";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [Fact]
        public async Task DeleteArchetypeSuccessfully()
        {
            // Arrange
            string url = "/api/archetypes/2";

            // Act
            var response = await Client.DeleteAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
