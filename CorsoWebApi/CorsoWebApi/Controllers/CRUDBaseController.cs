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
    public abstract class CRUDBaseController<TEntity> : ControllerBase
    where TEntity:EntityBase
    {
        private readonly IEFService<TEntity> service;

        public CRUDBaseController(IEFService<TEntity> service)
        {
            this.service = service;
        }

        public virtual IActionResult Get()
        {
            var entity = service.Get();
            if (entity is null || entity.Length == 0)
                return NotFound();

            return Ok(entity.ToArray());
        }

        public virtual IActionResult Get(int id)
        {
            var entity = service.Get(id);
            if (entity is null)
                return NotFound();

            return Ok(entity);
        }

        public virtual IActionResult Post([FromBody] TEntity entity)
        {
            var result = service.Add(entity);

            return Created("Get", result);
        }

        public virtual IActionResult Put([FromRoute] int id, [FromBody] TEntity entity)
        {
            try
            {
                service.Update(entity, id);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        public virtual IActionResult Delete([FromRoute] int id)
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
    }
}
