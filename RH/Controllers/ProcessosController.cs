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
    public class ProcessosController : Controller
    {
        private readonly IProcessoRepository service;

        public ProcessosController(IProcessoRepository context)
        {
            service = context;
        }

        // GET: api/Processos
        [HttpGet]
        public IEnumerable<Processo> GetProcesso()
        {
            return service.List();
        }

        // GET: api/Processos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcesso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var processo = await service.GetById(id);

                if (processo == null)
                    return NotFound();

                return Ok(processo);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: api/Processos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcesso([FromRoute] int id, [FromBody] Processo processo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != processo.Id)
                return BadRequest();

            try
            {
                await service.Update(processo);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        // POST: api/Processos
        [HttpPost]
        public async Task<IActionResult> PostProcesso([FromBody] Processo processo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Insert(processo);

            return CreatedAtAction("GetProcesso", new { id = processo.Id }, processo);
        }

        // DELETE: api/Processos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcesso([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Processo processo = await service.GetById(id);
            if (processo == null)
            {
                return NotFound();
            }

            await service.Delete(processo);

            return Ok(processo);
        }

    }
}