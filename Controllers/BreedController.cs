using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BreedApi.Models;
using BreedApi.Services;

namespace BreedApi.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class BreedController : ControllerBase
    {
       

        private readonly ILogger<BreedController> _logger;
        private IBreedService _service;

        public BreedController(ILogger<BreedController> logger, IBreedService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetBreeds()
        {
            IEnumerable<Breed> list = _service.GetBreeds();
            if (list != null)
                return Ok(list);
            else
                return BadRequest();
        }

        
        
        [HttpGet("{name}", Name="GetBreeds")]
        public IActionResult GetBreedbyName(string name)
        {
            Breed obj = _service.GetBreedbyName(name);
            if (obj!=null)
                return Ok(obj);
            return BadRequest();
        }


        [HttpPost]
        public IActionResult CreateBreed(Breed b) {
            _service.CreateBreed(b);
            return CreatedAtRoute("GetBreed", new{name=b.Name}, b);
        }

        [HttpPut("{name}")]
        public IActionResult UpdateBreed(string name, Breed breedIn) {
            
            _service.UpdateBreed(name, breedIn);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteBreed(string name) {
            _service.DeleteBreed(name);
            return NoContent();
        }
    }
}