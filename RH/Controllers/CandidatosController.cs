using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RH.Service;
using RH_API.Models;

namespace RH_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class CandidatosController : Controller
    {
        private readonly ICandidatoService service;

        public CandidatosController(ICandidatoService context)
        {
            service = context;
        }

        // GET: api/Candidatos
        [HttpGet]
        public IEnumerable<Candidato> GetCandidato()
        {
            return service.GetAll();
        }

        // GET: api/Candidatos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidato([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidato = await service.GetById(id);

            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        // PUT: api/Candidatos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato([FromRoute] int id, [FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.Id)
            {
                return BadRequest();
            }

            service.Entry(candidato).State = EntityState.Modified;

            try
            {
                await service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Candidatos
        [HttpPost]
        public async Task<IActionResult> PostCandidato([FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.AddAsync(candidato);

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

            service.Delete(candidato);
            //service.Candidatos.Remove(candidato);
            //await service.SaveChangesAsync();

            return Ok(candidato);
        }

    }
}