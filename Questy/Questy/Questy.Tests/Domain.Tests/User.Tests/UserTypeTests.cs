using Microsoft.EntityFrameworkCore;
using Questy.Data;
using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace Questy.Tests.Domain.User
{   
    public class UserTypeTests
    {
        [Fact]
        public void CanInsertUserType()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertUserType");

            //Act
            //using (var context = new QuestyContext<DbContextOptionsBuilder>(builder.Options))
            //{
            //    var userType = new UserType();
            //    context.UserTypes.Add(userType);

            //    //Assert
            //    Assert.Equal(EntityState.Added, context.Entry(userType).State);
            //}
        }
    }
}
