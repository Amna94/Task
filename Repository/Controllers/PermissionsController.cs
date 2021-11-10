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
    [Route("api/permission")]
    [ApiController]
    public class PermissionsController : Controller
    {
        private readonly IRepositoryPermission _repositoryPermission;
        public PermissionsController(IRepositoryPermission repositoryPermission)
        {
            _repositoryPermission = repositoryPermission;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Permission permission)
        {
            _repositoryPermission.Add(permission);
            return Ok(permission);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permission = _repositoryPermission.GetAll();
            return Ok(permission);
        }

        [HttpGet("{permissions_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string PermissionsId)
        {
            var permission = _repositoryPermission.GetById(PermissionsId);
            return Ok(permission);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryPermission.Update(permission);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _repositoryPermission.Delete(id);
            return Ok();
        }
    }
}
