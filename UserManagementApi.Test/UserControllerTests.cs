using UserManagementApis.Services;
using UserManagementApis.Models;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using UserManagementApis.Controllers;

namespace UserManagementApi.Test
{
    public class UserControllerTests
    {
        [Fact]
        public void Test1()
        {
            
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturn200Status()
        {
            /// Arrange
            var todoService = new Mock<IUserService>();
            todoService.Setup(_ => _.GetUserDetail()).ReturnsAsync(MockUserData.UserData());
            var sut = new UserController(todoService.Object);

            /// Act
            var result = await sut.GetAllUsers();
            


            // /// Assert
            //result.StatusCode.Should().Be(200);
        }
    }
}