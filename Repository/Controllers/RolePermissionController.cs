using Amna.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amna.Controllers
{
    [Route("api/RolePermission")]
    [ApiController]
    public class RolePermissionController : Controller
    {
        private readonly IRepositoryRolePermission _repositoryRolePermission;
        public RolePermissionController(IRepositoryRolePermission repositoryRolePermission)
        {
            _repositoryRolePermission = repositoryRolePermission;
        }

        [HttpPost]
        public IActionResult Add([FromBody] RolePermission rolePermission)
        {

            _repositoryRolePermission.Add(rolePermission );
            return Ok(rolePermission);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolePermission = _repositoryRolePermission.GetAll();
            return Ok(rolePermission);
        }

        [HttpGet("{RolesId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string RoleId, string PermissionId)
        {
            var rolePermission = _repositoryRolePermission.GetById(RoleId, PermissionId);
            return Ok(rolePermission);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] RolePermission rolePermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryRolePermission.Update(rolePermission);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string role_id, string permission_id)
        {
            _repositoryRolePermission.Delete(role_id, permission_id);
            return Ok();
        }
    }
}
