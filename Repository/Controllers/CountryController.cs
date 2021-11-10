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
    [Route("api/countries")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IRepositoryCountry _repositoryCountry;
        public CountryController(IRepositoryCountry repositoryCountry)
        {
            _repositoryCountry = repositoryCountry;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Country countries)
        {
            _repositoryCountry.Add(countries);
            return Ok(countries);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = _repositoryCountry.GetAll();
            return Ok(countries);
        }

        [HttpGet("{CountryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int CountryId)
        {
            var countries = _repositoryCountry.GetById(CountryId);
            return Ok(countries);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromBody] Country countries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _repositoryCountry.Update(countries);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            _repositoryCountry.Delete(id);
            return Ok();
        }
    }
}
