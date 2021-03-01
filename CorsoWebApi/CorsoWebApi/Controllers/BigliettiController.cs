using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;
using CorsoWebApi.Service;

namespace CorsoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettiController : ControllerBase
    {
        private readonly BigliettoService service;

        public BigliettiController(BigliettoService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Produces(typeof(Biglietto[]))]
        public IActionResult Get()
        {
            var biglietti = service.Get();
            if (biglietti is null || biglietti.Length == 0)
                return NotFound();
            
            return Ok(biglietti.ToArray());
        }

        [HttpGet("{id}")]
        [Produces(typeof(Biglietto))]
        public IActionResult Get(int id)
        {
            var biglietto = service.Get(id);
            if (biglietto is null)
                return NotFound();

            return Ok(biglietto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Biglietto biglietto)
        {
            var result = service.Add(biglietto);

            return Created("Get", result);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] Biglietto biglietto)
        {
            try
            {
                service.Update(biglietto, id);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                service.Delete(id);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
        
        [HttpPatch("{id}")]
        public IActionResult ModificaNome([FromRoute] int id, [FromBody] ModificaBigliettoCognomeNome patch )
        {
            var oldBiglietto = service.Get(id);
            if (oldBiglietto is null)
                return BadRequest("Biglietto non trovato");
            oldBiglietto.Cognome = patch.Cognome;
            oldBiglietto.Nome = patch.Nome;
            service.Update(oldBiglietto,id);
            
            return Ok();
        }
    }
}
