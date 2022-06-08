using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApis.Models;
using UserManagementApis.Services;

namespace UserManagementApis.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // This endpoint refers to fetch all user details.
        [HttpGet]
        [Route("api/GetAllUsers")]
        public async Task<List<UserDetails>> GetUserDetails() =>
            await _userService.GetUserDetails();

        // This endpoint refers to fetch user details as per the Id.
        [HttpGet]
        [Route("api/GetUserById/{UserId}")]
        public async Task<ActionResult<UserDetails>> GetUserDetailsById(int UserId)
        {
            var user = await _userService.GetUserDetailsById(UserId);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        // This endpoint refers to create new user entry.
        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<IActionResult> CreateUser(UserDetails userDetails)
        {
            await _userService.CreateUser(userDetails);
            return CreatedAtAction(nameof(GetUserDetails), new { id = userDetails.UId }, userDetails);
        }

        // This endpoint refers to update user details as per the Id.
        [HttpPut]
        [Route("api/UpdateUser/{UserId}")]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails, int UserId)
        {
            var userDetail = await _userService.GetUserDetailsById(UserId);
            if (userDetail is null)
            {
                return NotFound();
            }
            userDetails.UId = userDetail.UId;
            await _userService.UpdateUser(userDetails, UserId);
            return NoContent();
        }

        // This endpoint refers to remove user details as per the Id.
        [HttpDelete]
        [Route("api/DeleteUser/{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            var userDetail = await _userService.GetUserDetailsById(UserId);
            if (userDetail is null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(UserId);
            return NoContent();
        }
    }
}
