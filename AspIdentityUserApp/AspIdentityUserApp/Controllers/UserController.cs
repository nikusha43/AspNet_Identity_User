using AspIdentityUserApp.Dtos;
using AspIdentityUserApp.Models;
using AspIdentityUserApp.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspIdentityUserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("/Register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Gender = userDto.Gender,
                UserName = userDto.UserName,
                Email = userDto.Email,
            };
            var result = await _userRepo.RegisterUserAsync(user, userDto.Password);
            return Ok(new { Status = result });
        }

       
        [HttpPost]
        [Route("/Sign In")]
        public async Task<IActionResult> Signin(SignInDTO signInDto)
        {
            var result = _userRepo.LoginUserAsync(signInDto.Email,signInDto.Password,signInDto.RemmemberMe);
            return Ok(new { Status = result }); 
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = _userRepo.DeleteUserAsync(Id);
            return Ok(new { Status = result });
        }

        [HttpGet]
        [Route("/Get All")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();
            return Ok(users);
        }

    }
}
