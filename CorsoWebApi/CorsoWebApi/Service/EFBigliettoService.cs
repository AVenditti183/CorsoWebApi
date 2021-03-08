using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Data;
using CorsoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsoWebApi.Service
{
    public class EFBigliettoService : IBigliettoService
    {
        private MyDB context;

        public EFBigliettoService(MyDB context)
        {
            this.context = context;
        }

        public Biglietto Get(int id)
        {
            return context.Biglietti.Find(id);
        }

        public Biglietto[] Get() => context.Biglietti.ToArray();
        
        public Biglietto Add(Biglietto biglietto)
        {
            var oldId = context.Biglietti.Select(o => o.Id).Max();
            biglietto.Id = oldId + 1;

            context.Biglietti.Add(biglietto);

            context.SaveChanges();
            return biglietto;
        }

        public Biglietto Update(Biglietto biglietto,int id)
        {
            var bigliettoCorrente = context.Biglietti.AsNoTracking().FirstOrDefault(o => o.Id == id);
            if (bigliettoCorrente is null)
                throw new ArgumentException(nameof(id));
            
            context.Entry<Biglietto>(biglietto).State = EntityState.Modified;
            context.SaveChanges();
            
            return biglietto;
        }

        public void Delete(int id)
        {
            var oldBiglietto = context.Biglietti.FirstOrDefault(o => o.Id == id);
            if (oldBiglietto is null)
                throw new ArgumentException(nameof(id), "biglietto non trovato");

            context.Biglietti.Remove(oldBiglietto);
            context.SaveChanges();
        }
    }
}
