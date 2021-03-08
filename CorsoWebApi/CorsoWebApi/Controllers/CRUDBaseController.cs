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
    public abstract class CRUDBaseController<TEntity,TMap> : ControllerBase
    where TEntity:EntityBase
    where TMap : DtoEntity
    {
        private readonly IEFService<TEntity> service;
        private readonly IMapper mapper;
        public CRUDBaseController(IEFService<TEntity> service,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public virtual IActionResult Get()
        {
            var entity = service.Get();
            if (entity is null || entity.Length == 0)
                return NotFound();

            return Ok(entity.Select( o=> mapper.Map<TMap>(o)).ToArray());
        }

        public virtual IActionResult Get(int id)
        {
            var entity = service.Get(id);
            if (entity is null)
                return NotFound();

            return Ok(mapper.Map<TMap>(entity));
        }

        public virtual IActionResult Post([FromBody] TMap entity)
        {
            var item = mapper.Map<TEntity>(entity);
            var result = service.Add(item);

            return Created("Get", result);
        }

        public virtual IActionResult Put([FromRoute] int id, [FromBody] TMap entity)
        {
            try
            {
                var item = mapper.Map<TEntity>(entity);
                service.Update(item, id);
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
