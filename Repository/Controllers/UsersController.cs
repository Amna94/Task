using Amna.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amna.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IRepositoryUsers _repositoryUsers;
        public UsersController(IRepositoryUsers repositoryUsers)
        {
            _repositoryUsers = repositoryUsers;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Users users)
        {
            _repositoryUsers.Add(users);
            return Ok(users);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var users = _repositoryUsers.GetAll();
            return Ok(users);
        }

        [HttpGet("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int UserId)
        {
            var users = _repositoryUsers.GetById(UserId);
            return Ok(users);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryUsers.Update(users);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _repositoryUsers.Delete(id);
            return Ok();
        }

    }
}
