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
    [Route("api/roles")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly IRepositoryRole _repositoryRole;
        public RolesController(IRepositoryRole repositoryRole)
        {
            _repositoryRole = repositoryRole;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Role roles)
        {
            _repositoryRole.Add(roles);
            return Ok(roles);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = _repositoryRole.GetAll();
            return Ok(roles);
        }

        [HttpGet("{RolesId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string RolesId)
        {
            var roles = _repositoryRole.GetById(RolesId);
            return Ok(roles);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Role roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryRole.Update(roles);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _repositoryRole.Delete(id);
            return Ok();
        }
    }
}
