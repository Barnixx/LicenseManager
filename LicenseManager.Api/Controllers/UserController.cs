using System.Threading.Tasks;
using LicenseManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
{
    [Route("/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Json(users);
        }
    }
}