using Microsoft.EntityFrameworkCore;
using Questy.Data;
using Questy.Domain.Entities;
using Xunit;

namespace Questy.Tests.Domain.User
{   
    public class UserTypeTests
    {
        [Fact]
        public void CanInsertUserType()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<QuestyContext>();
            builder.UseInMemoryDatabase("CanInsertUserType");

            //Act
            using (var context = new QuestyContext(builder.Options))
            {
                var userType = new UserType();
                context.UserTypes.Add(userType);

                //Assert
                Assert.Equal(EntityState.Added, context.Entry(userType).State);
            }
        }
    }
}
