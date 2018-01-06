using Microsoft.AspNetCore.Mvc;
using RH.Models;
using RH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RH.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class TecnologiasController : Controller
    {
        private readonly ITecnologiaRepository service;

        public TecnologiasController(ITecnologiaRepository context)
        {
            service = context;
        }

        // GET: api/Tecnologias
        [HttpGet]
        public IEnumerable<Tecnologia> GetTecnologia()
        {
            return service.List();
        }

        // GET: api/Tecnologias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTecnologia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tecnologia = await service.GetById(id);

                if (tecnologia == null)
                    return NotFound();

                return Ok(tecnologia);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Tecnologias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnologia([FromRoute] int id, [FromBody] Tecnologia tecnologia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != tecnologia.Id)
                return BadRequest();

            try
            {
                await service.Update(tecnologia);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // POST: api/Tecnologias
        [HttpPost]
        public async Task<IActionResult> PostTecnologia([FromBody] Tecnologia tecnologia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Insert(tecnologia);

            return CreatedAtAction("GetTecnologia", new { id = tecnologia.Id }, tecnologia);
        }

        // DELETE: api/Tecnologias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnologia([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tecnologia tecnologia = await service.GetById(id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            await service.Delete(tecnologia);

            return Ok(tecnologia);
        }

    }
}