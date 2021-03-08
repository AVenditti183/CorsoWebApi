using AutoMapper;
using AutoMapper.QueryableExtensions;
using CorsoWebApi.DTO;
using CorsoWebApi.Models;
using CorsoWebApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorsoWebApi.Controllers
{
    public abstract class CRUDBaseController<TEntity, TMap> : ControllerBase
    where TEntity : EntityBase
    where TMap : DtoEntity
    {
        private readonly IEFService<TEntity> service;
        private readonly IMapper mapper;

        public CRUDBaseController(IEFService<TEntity> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public virtual IActionResult Get()
        {
            var entity = service.Get()
                .ProjectTo<TMap>(mapper.ConfigurationProvider)
                .ToList();
            if (entity is null || entity.Count() == 0)
                return NotFound();

            return Ok(entity.ToArray());
        }

        protected virtual IActionResult Get(Expression<Func<TEntity, bool>> filter)
        {
            var entity = service.Get().Where(filter).ToList();
            if (entity is null || entity.Count() == 0)
                return NotFound();

            return Ok(entity.Select(o => mapper.Map<TMap>(o)).ToArray());
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

            return Created("Get", mapper.Map<TMap>(result));
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