using Questy.Data;
using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Questy.Tests.Domain.User
{   
    public class UserTypeTests
    {
        private static QuestyContext context = new QuestyContext();

        [Fact]
        public void CanAddUserType()
        {
            // Arrange
            var userType = new UserType { Description = "Test" };

            // Act
            context.UserTypes.Add(userType);
            
            // Assert
            Assert.True(context.SaveChanges() > 0);
        }

        [Fact]
        public void CanDeleteUserTypeByDescription()
        {
            // Arrange
            var result = true;
            var userType = context.UserTypes
                .Where(ut => ut.Description == "Test").FirstOrDefault();

            // Act            
            if(userType != null)
            {
                context.UserTypes.Remove(userType);
                result = context.SaveChanges() > 0;
            }            
            
            // Assert
            Assert.True(result);
        }
    }
}
