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
    [Route("api/cities")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly IRepositoryCity _repositoryCity;
        public CityController(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;
        }
        [HttpPost]
        public IActionResult Add([FromBody] City cities)
        {
            _repositoryCity.Add(cities);
            return Ok(cities);
        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var cities = _repositoryCity.GetAll();
            return Ok(cities);
        }

        [HttpGet("{CityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int CityId)
        {
            var cities = _repositoryCity.GetById(CityId);
            return Ok(cities);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] City cities)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryCity.Update(cities);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _repositoryCity.Delete(id);
            return Ok();
        }
             
    }
}
