using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;

namespace CorsoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettiController : ControllerBase
    {
        private static List<Biglietto> biglietti;

        public BigliettiController()
        {
            if (biglietti is null)
            {
                biglietti = new List<Biglietto>
                {
                    new Biglietto
                    {
                        Id = 1,
                        Cognome = "Venditti",
                        Nome = "Antonio",
                        Costo = 10,
                        DataEvento = new DateTime(2021, 6, 14),
                        NumeroSedia = "M4",
                        Posizione = Posizioni.Galleria
                    },
                    new Biglietto
                    {
                        Id = 2,
                        Cognome = "Venditti",
                        Nome = "Antonio",
                        Costo = 10,
                        DataEvento = new DateTime(2021, 6, 14),
                        NumeroSedia = "M5",
                        Posizione = Posizioni.Galleria
                    }
                };
            }
        }

        [HttpGet]
        [Produces(typeof(Biglietto[]))]
        public IActionResult Get()
        {
            if (biglietti is null || biglietti.Count == 0)
                return NotFound();
            
            return Ok(biglietti.ToArray());
        }

        [HttpGet("{id}")]
        [Produces(typeof(Biglietto))]
        public IActionResult Get(int id)
        {
            var biglietto = biglietti.FirstOrDefault(o => o.Id == id);
            if (biglietto is null)
                return NotFound();

            return Ok(biglietto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Biglietto biglietto)
        {
            var oldId = biglietti.Select(o => o.Id).Max();
            biglietto.Id = oldId + 1;
            
            biglietti.Add(biglietto);

            return Created("Get", biglietto);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] Biglietto biglietto)
        {
            var oldBiglietto = biglietti.FirstOrDefault(o => o.Id == id);
            if (oldBiglietto is null)
                return BadRequest("Biglietto non trovato");

            biglietti.Remove(oldBiglietto);
            biglietti.Add(biglietto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var oldBiglietto = biglietti.FirstOrDefault(o => o.Id == id);
            if (oldBiglietto is null)
                return BadRequest("Biglietto non trovato");

            biglietti.Remove(oldBiglietto);

            return Ok();
        }
    }
}
