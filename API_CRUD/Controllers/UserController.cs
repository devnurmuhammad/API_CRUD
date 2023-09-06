using API_CRUD.DTO;
using API_CRUD.Entities;
using API_CRUD.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromForm] UserDTO userDTO)
        {
            await userRepository.CreateUserAsync(userDTO);
            return Ok("Created");
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] UserDTO userDTO, int age)
        {
            await userRepository.UpdateUserAsync(userDTO, age);
            return Ok("Updated");
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        { 
            var result = await userRepository.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            await userRepository.DeleteUserAsync(Id);
            return Ok("Deleted");
        }


    }
}
