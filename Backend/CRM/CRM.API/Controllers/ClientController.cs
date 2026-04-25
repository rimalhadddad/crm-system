using CRM.API.DTOs;
using CRM.API.Interfaces;
using CRM.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetMyClients()
        {
            var result = _service.GetMyClients();
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(ClientCreateDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.Create(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ClientCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.Update(id,dto);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result= _service.Delete(id);
            return Ok(result);
        }

        [HttpPost("assign-property")]
        public IActionResult AssignProperty(AssignPropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result=  _service.AssignProperty(dto);
            return Ok(result);
        }
    }
}