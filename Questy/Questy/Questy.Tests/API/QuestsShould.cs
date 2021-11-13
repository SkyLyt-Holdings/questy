using Questy.API;
using Questy.Infrastructure.DTOs.Quest;
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
    public class QuestsShould : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public QuestsShould(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ContentHelper.GetToken());
        }
        [Fact]
        public async Task GetQuestSuccessfully()
        {
            // Arrange
            string url = "/api/quests/9";

            // Act
            var response = await Client.GetAsync(url);
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("title", content);
        }
        [Fact]
        public async Task AddQuestSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/quests",
                Body = new QuestDTO
                {
                    Title = "Quest1",
                    Description = "Quest Description",
                    StartDate = "10/10/2021",
                    EndDate = "11/11/2021"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Contains("Quest1", content);
        }
        [Fact]
        public async Task UpdateQuestSuccessfully()
        {
            // Arrange
            var request = new
            {
                Url = "/api/quests/UpdateQuest",
                Body = new QuestDTO
                {
                    ID = 11,
                    Title = "Quest2",
                    Description = "New Quest Description",
                    StartDate = "10/10/2022",
                    EndDate = "11/11/2022"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var content = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
