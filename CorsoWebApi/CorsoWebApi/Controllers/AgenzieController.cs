using AutoMapper;
using CorsoWebApi.DTO;
using CorsoWebApi.Models;
using CorsoWebApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace CorsoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenzieController : CRUDBaseController<Agenzia, AgenziaDto>
    {
        public AgenzieController(IEFService<Agenzia> service, IMapper mapper) : base(service, mapper)
        { }

        [HttpGet]
        [Produces(typeof(AgenziaDto[]))]
        public override IActionResult Get()
        {
            return   base.Get(o => o.Id % 2 == 0);
        }

        [HttpGet("{id}")]
        [Produces(typeof(AgenziaDto))]
        public override IActionResult Get(int id) => base.Get(id);

        [HttpPost]
        public override IActionResult Post([FromBody] AgenziaDto evento) => base.Post(evento);

        [HttpPut("{id}")]
        public override IActionResult Put([FromRoute] int id, [FromBody] AgenziaDto evento) => base.Put(id, evento);

        [HttpDelete("{id}")]
        public override IActionResult Delete([FromRoute] int id) => base.Delete(id);
    }
}