using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Models;
using RH.Service;

namespace RH.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class CandidatosController : Controller
    {
        private readonly ICandidatoRepository service;

        public CandidatosController(ICandidatoRepository context)
        {
            service = context;
        }

        // GET: api/Candidatos
        [HttpGet]
        public IEnumerable<Candidato> GetCandidato()
        {
            return service.List();
        }

        // GET: api/Candidatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidato([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var candidato = await service.GetById(id);

                if (candidato == null)
                    return NotFound();

                return Ok(candidato);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Candidatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato([FromRoute] int id, [FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != candidato.Id)
                return BadRequest();

            try
            {
                await service.Update(candidato);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // POST: api/Candidatos
        [HttpPost]
        public async Task<IActionResult> PostCandidato([FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Insert(candidato);

            return CreatedAtAction("GetCandidato", new { id = candidato.Id }, candidato);
        }

        // DELETE: api/Candidatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Candidato candidato = await service.GetById(id);
            if (candidato == null)
            {
                return NotFound();
            }

            await service.Delete(candidato);

            return Ok(candidato);
        }

    }
}