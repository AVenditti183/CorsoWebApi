using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.DTO;
using CorsoWebApi.Models;
using CorsoWebApi.Service;
using AutoMapper;

namespace CorsoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BigliettiController : ControllerBase
    {
        private readonly IBigliettoService service;
        private readonly IMapper mapper;
        public BigliettiController(IBigliettoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(BigliettoDto[]))]
        public IActionResult Get()
        {
            var biglietti = service.Get();
            if (biglietti is null || biglietti.Length == 0)
                return NotFound();

            var results = biglietti.ToList().Select(o => mapper.Map<BigliettoDto>(o));

            return Ok(results.ToArray());
        }

        [HttpGet("{id}")]
        [Produces(typeof(BigliettoDto))]
        public IActionResult Get(int id)
        {
            var biglietto = service.Get(id);
            if (biglietto is null)
                return NotFound();
            var result = mapper.Map<BigliettoDto>(biglietto);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BigliettoDto biglietto)
        {
            var item =  mapper.Map<Biglietto>(biglietto);

            var result = service.Add(item);

            return Created("Get", result);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] BigliettoDto biglietto)
        {
            try
            {
                var item = mapper.Map<Biglietto>(biglietto);

                service.Update(item, id);
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
