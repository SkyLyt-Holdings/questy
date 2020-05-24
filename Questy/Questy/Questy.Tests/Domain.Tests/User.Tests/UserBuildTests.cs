using Microsoft.EntityFrameworkCore;
using Questy.Data;
using Questy.Domain.Entities;
using Xunit;

namespace Questy.Tests.Domain.Tests.User
{
    public class UserBuildTests
    {
        [Fact]
        public void CanCalculateLevel()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<QuestyContext>();
            builder.UseInMemoryDatabase("CanInsertUserType");

            //Act
            using (var context = new QuestyContext(builder.Options))
            {
                var userBuild = new UserBuild
                {
                    UserID = 1,
                    ArchetypeID = 1,
                    WeightPercentage = 100,
                    Experience = 150
                };

                context.UserBuilds.Add(userBuild);
            
                //Assert
                Assert.Equal(3, userBuild.CalculateLevel());
            }
        }
    }
}
