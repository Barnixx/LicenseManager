using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LicenseManager.Core.Domain;
using LicenseManager.Infrastructure.Commands;
using LicenseManager.Infrastructure.Commands.Users;
using LicenseManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace LicenseManager.Api.Controllers
{
    [Route("/user")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, ICommandDispatcher commandDispatcher): base(commandDispatcher)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]Guid userId)
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound();
            }

            return Json(users);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            return Json(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await DispatchAsync(command);
            return Created($"users/{command.Email}", null);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateUser command)
        {
            await DispatchAsync(command);
            return Ok();
        }
    }
}