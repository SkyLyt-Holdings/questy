using Newtonsoft.Json;
using Questy.API;
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
    public class TagsShould : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public TagsShould(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContentHelper.GetToken());
        }
        [Fact]
        public async Task GetTagSuccessfully()
        {
            // Arrange
            string url = "/api/tags/1";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("description", content);
        }
        [Fact]
        public async Task AddTagSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/tags",
                Body = new TagDTO
                {
                    Description = "Tag Description Modern"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("Modern", content);
        }
        [Fact]
        public async Task UpdateTagSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/tags/UpdateTag",
                Body = new TagDTO
                {
                    ID = 1,
                    Description = "Tag 1"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task GetAllTagsSuccessfully()
        {
            // Arrange
            string url = "/api/tags/GetAllTags";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [Fact]
        public async Task DeleteTagSuccessfully()
        {
            // TODO: Implement the logic that record existed in [Tags] table before delete

            // Arrange
            string url = "/api/tags/2";

            // Act
            var response = await Client.DeleteAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
        [Fact]
        public async Task AddQuestTagSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/tags/AddQuestTag",
                Body = new QuestTagDTO
                {
                    QuestID = 9,
                    TagID = 1
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("tagID", content);
        }
        [Fact]
        public async Task DeleteQuestTagSuccessfully()
        {
            // TODO: Implement the logic that record existed in [QuestTag] table before delete

            // Arrange
            string url = "/api/tags/DeleteQuestTag/3";
             
            // Act
            var response = await Client.DeleteAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
