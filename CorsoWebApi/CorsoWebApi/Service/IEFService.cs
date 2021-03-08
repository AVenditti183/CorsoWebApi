using CorsoWebApi.Models;
using System.Linq;

namespace CorsoWebApi.Service
{
    public interface IEFService<TEntity> where TEntity : EntityBase
    {
        TEntity Get(int id);
        IQueryable<TEntity> Get();
        TEntity Add(TEntity biglietto);
        TEntity Update(TEntity biglietto, int id);
        void Delete(int id);
    }
}