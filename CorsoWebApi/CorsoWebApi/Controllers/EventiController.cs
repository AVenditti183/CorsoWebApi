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
    [Route("api/eventi")]
    [ApiController]
    public class EventiController : CRUDBaseController<Evento>
    {
        public EventiController(IEFService<Evento> service):base(service)
        { }

        [HttpGet]
        [Produces(typeof(Evento[]))]
        public override IActionResult Get() => base.Get();

        [HttpGet("{id}")]
        [Produces(typeof(Evento))]
        public override IActionResult Get(int id) => base.Get(id);

        [HttpPost]
        public override IActionResult Post([FromBody]
            Evento evento) => base.Post(evento);

        [HttpPut("{id}")]
        public override IActionResult Put([FromRoute]
            int id, [FromBody]
            Evento evento)
            => base.Put(id, evento);

        [HttpDelete("{id}")]
        public override IActionResult Delete([FromRoute]
            int id) => base.Delete(id);
    }
}
