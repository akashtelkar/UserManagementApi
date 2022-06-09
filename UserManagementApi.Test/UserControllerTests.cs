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
        public async Task GetAllUsers_ShouldReturn200Status()
        {
            /// Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserDetail()).ReturnsAsync(MockUserData.UserData());
            var sut = new UserController(userService.Object);

            /// Act
            var result = await sut.GetAllUsers();
            List<UserDetails> value = result as List<UserDetails>;

            // /// Assert
            Assert.Equal(1, value.Count);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserDetail()).ReturnsAsync(MockUserData.GetEmptyUserData());
            var sut = new UserController(userService.Object);

            /// Act
            //var result = (NoContentResult)await sut.GetAllUsers();


            /// Assert
            //result.StatusCode.Should().Be(204);
            //userService.Verify(_ => _.GetUserDetail(), Times.Exactly(1));
        }

        [Fact]
        public async Task GetUserDetailById_ShouldReturn200Status()
        {
            /// Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserDetailById(1)).ReturnsAsync(MockUserData.UserDataById(1));
            var sut = new UserController(userService.Object);

            /// Act
            var result = await sut.GetUserById(1);
            var value = result.Value;

            // /// Assert
            Assert.IsType<UserDetails>(value);
            Assert.Equal(1, value.Id);
        }
        [Fact]
        public void Get_by_id_returns_NotFound_for_invalid_Id()
        {
            /// Arrange
            var userService = new Mock<IUserService>();
            userService.Setup(_ => _.GetUserDetailById(1)).ReturnsAsync(MockUserData.UserDataById(1));
            var sut = new UserController(userService.Object);

            //act
            var result = sut.GetUserById(4).Result.Result;
            
            //assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task CreateUser_ShouldReturn200Status()
        {
            /// Arrange
            var userService = new Mock<IUserService>();
            var newUser = MockUserData.NewUserData();
            var sut = new UserController(userService.Object);

            /// Act
            var result = await sut.CreateUser(newUser);

            /// Assert
            userService.Verify(_ => _.CreateUser(newUser), Times.Exactly(1));
        }

        [Fact]
        public void UpdateUser()
        {
            //arrange
            var userService = new Mock<IUserService>();
            var newUser = MockUserData.NewUserData();
            UserDetails user = new UserDetails();
            var sut = new UserController(userService.Object);
            int id = 3;

            //act
            var result = sut.UpdateUser(user, id);
            //result.sa
            //UserDetails updatedItem = MockUserData.UserData.Find(id);

            //assert
            //Assert.Equal(tobeUpdated, updatedItem);

        }
    }
}
