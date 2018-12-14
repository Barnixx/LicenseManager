﻿using System;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Infrastructure.EF;
using LicenseManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LicenseManager.Api.Controllers
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