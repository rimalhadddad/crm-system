using CRM.API.DTOs;
using CRM.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertyController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet("my")]
        public IActionResult GetMy()
        {
            var result = _service.GetMyProperties();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(PropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.Update(id, dto);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
