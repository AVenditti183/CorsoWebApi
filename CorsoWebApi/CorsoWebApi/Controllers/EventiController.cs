using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;
using CorsoWebApi.Service;
using CorsoWebApi.DTO;
using AutoMapper;

namespace CorsoWebApi.Controllers
{
    [Route("api/eventi")]
    [ApiController]
    public class EventiController : CRUDBaseController<Evento,EventoDto>
    {
        public EventiController(IEFService<Evento> service, IMapper mapper):base(service,mapper)
        { }

        [HttpGet]
        [Produces(typeof(EventoDto[]))]
        public override IActionResult Get() => base.Get();

        [HttpGet("{id}")]
        [Produces(typeof(EventoDto))]
        public override IActionResult Get(int id) => base.Get(id);

        [HttpPost]
        public override IActionResult Post([FromBody] EventoDto evento) => base.Post(evento);

        [HttpPut("{id}")]
        public override IActionResult Put([FromRoute] int id, [FromBody] EventoDto evento) => base.Put(id, evento);

        [HttpDelete("{id}")]
        public override IActionResult Delete([FromRoute] int id) => base.Delete(id);
    }
}
