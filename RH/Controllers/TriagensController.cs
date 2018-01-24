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
    public class TriagensController : Controller
    {
        private readonly IRepository<Triagem> service;

        public TriagensController(ITriagemRepository context)
        {
            service = context;
        }




        // GET: api/Triagems
        [HttpGet]
        public IEnumerable<Triagem> GetTriagens()
        {
            return service.List();
        }

        // GET: api/Triagems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTriagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var triagem = await service.GetById(id);

                if (triagem == null)
                    return NotFound();

                return Ok(triagem);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Triagems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTriagem([FromRoute] int id, [FromBody] Triagem triagem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != triagem.Id)
                return BadRequest();

            try
            {
                await service.Update(triagem);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // POST: api/Triagems
        [HttpPost]
        public async Task<IActionResult> PostTriagem([FromBody] Triagem triagem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Insert(triagem);

            return CreatedAtAction("GetTriagem", new { id = triagem.Id }, triagem);
        }

        // DELETE: api/Triagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTriagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Triagem triagem = await service.GetById(id);
            if (triagem == null)
            {
                return NotFound();
            }

            await service.Delete(triagem);

            return Ok(triagem);
        }

        [HttpDelete("candidatos/{candidatoId}", Name = "DeleteCandidato")]
        public async Task<IActionResult> DeleteCandidato([FromRoute] int id, [FromRoute] int candidatoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Triagem triagem = await service.GetById(id);
            if (triagem == null)
            {
                return NotFound();
            }

            await service.Delete(triagem);

            return Ok(triagem);
        }

    }
}