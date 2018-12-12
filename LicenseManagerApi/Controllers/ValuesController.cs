using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManagerCore.Domain;
using LicenseManagerInfrastructure.EF;
using LicenseManagerInfrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Sqlite.Internal;

namespace LicenseManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly IUserService _userService;
        private readonly SqlServerSettings _settings;

        public ValuesController(IUserService userService, SqlServerSettings settings)
        {
            _userService = userService;
            _settings = settings;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            Console.WriteLine(_settings.ToString());
            return Json(users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}