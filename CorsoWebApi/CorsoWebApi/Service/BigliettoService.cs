using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;

namespace CorsoWebApi.Service
{
    public class BigliettoService: IBigliettoService
    {
        private List<Biglietto> biglietti;

        public BigliettoService()
        {
            biglietti = new List<Biglietto>
            {
                new Biglietto
                {
                    Id = 1,
                    Cognome = "Venditti",
                    Nome = "Antonio",
                    Costo = 10,
                    DataEvento = new DateTime(2021, 6, 14),
                    NumeroSedia = "M4",
                    Posizione = Posizioni.Galleria
                },
                new Biglietto
                {
                    Id = 2,
                    Cognome = "Venditti",
                    Nome = "Antonio",
                    Costo = 10,
                    DataEvento = new DateTime(2021, 6, 14),
                    NumeroSedia = "M5",
                    Posizione = Posizioni.Galleria
                }
            };
        }

        public Biglietto Get(int id)
        {
            return biglietti.FirstOrDefault(o => o.Id == id);
        }

        public Biglietto[] Get() => biglietti.ToArray();

        public Biglietto Add(Biglietto biglietto)
        {
            var oldId = biglietti.Select(o => o.Id).Max();
            biglietto.Id = oldId + 1;

            biglietti.Add(biglietto);
            return biglietto;
        }

        public Biglietto Update(Biglietto biglietto, int id)
        {
            var oldBiglietto = biglietti.FirstOrDefault(o => o.Id == id);
            if (oldBiglietto is null)
                throw new ArgumentException(nameof(id), "biglietto non trovato");

            biglietti.Remove(oldBiglietto);
            biglietti.Add(biglietto);

            return biglietto;
        }

        public void Delete(int id)
        {
            var oldBiglietto = biglietti.FirstOrDefault(o => o.Id == id);
            if (oldBiglietto is null)
                throw new ArgumentException(nameof(id), "biglietto non trovato");

            biglietti.Remove(oldBiglietto);
        }
    }
}
