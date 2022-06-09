using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApis.Models;
using UserManagementApis.Services;

namespace UserManagementApis.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// This endpoint refers to fetch all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAllUsers")]
        public async Task<List<UserDetails>> GetAllUsers() =>
            await _userService.GetUserDetail();

        /// <summary>
        /// This endpoint refers to fetch a user as per the user id.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetUserById/{userid}")]
        public async Task<ActionResult<UserDetails>> GetUserById(int userid)
        {
            var user = await _userService.GetUserDetailById(userid);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        /// <summary>
        /// This endpoint refers to create a new user entry.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<IActionResult> CreateUser(UserDetails userDetails)
        {
            await _userService.CreateUser(userDetails);
            return CreatedAtAction(nameof(GetAllUsers), new { id = userDetails.UId }, userDetails);
        }

        /// <summary>
        /// This endpoint refers to update a user as per the user id.
        /// </summary>
        /// <param name="userDetails"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/UpdateUser/{userid}")]
        public async Task<IActionResult> UpdateUser(UserDetails userDetails, int userid)
        {
            var userDetail = await _userService.GetUserDetailById(userid);
            if (userDetail is null)
            {
                return NotFound();
            }
            userDetails.UId = userDetail.UId;
            await _userService.UpdateUser(userDetails, userid);
            return Ok();
        }

        /// <summary>
        /// This endpoint refers to remove a user as per the user id.
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/DeleteUser/{userid}")]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            var userDetail = await _userService.GetUserDetailById(userid);
            if (userDetail is null)
            {
                return NotFound();
            }
            await _userService.DeleteUser(userid);
            return Ok();
        }
    }
}
