using AspIdentityUserApp.Dtos;
using AspIdentityUserApp.Models;
using AspIdentityUserApp.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspIdentityUserApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo = default;
        public UserController(IUserRepository userRepo)
        {            
            _userRepo = userRepo;
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDto userDto)
        {
            var user = new User()
            {
                Name =userDto.Name,
                Surname= userDto.Surname,
                Gender=userDto.Gender,
                UserName = userDto.UserName,
                Email = userDto.Email,
            };
            var result = await _userRepo.RegisterUserAsync(user,userDto.Password);
            return Ok(new {Status=result});
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
