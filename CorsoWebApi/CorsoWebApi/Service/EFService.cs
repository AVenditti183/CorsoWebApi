using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Data;
using CorsoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsoWebApi.Service
{
    public class EFService<TEntity> :IEFService<TEntity>
        where TEntity:EntityBase
    {
        private readonly MyDB context;

        public EFService(MyDB context)
        {
            this.context = context;
        }

        public TEntity[] Get()
        {
            return context.Set<TEntity>().ToArray();
        }
        
        public TEntity Get(int id)
        {
            return context.Find<TEntity>(id);
        }
        
        public TEntity Add(TEntity entity)
        {
            var oldId = context.Set<TEntity>().Select(o => o.Id).Max();
            entity.Id = oldId + 1;

            context.Set<TEntity>().Add(entity);

            context.SaveChanges();
            return entity;
        }
        public TEntity Update(TEntity entity, int id)
        {
            var entityCorrente = context.Set<TEntity>().AsNoTracking().FirstOrDefault(o => o.Id == id);
            if (entityCorrente is null)
                throw new ArgumentException(nameof(id));

            context.Entry<TEntity>(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var oldEntity= context.Set<TEntity>().FirstOrDefault(o => o.Id == id);
            if (oldEntity is null)
                throw new ArgumentException(nameof(id), "biglietto non trovato");

            context.Entry<TEntity>(oldEntity).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
