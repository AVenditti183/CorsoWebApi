using CorsoWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;

namespace CorsoWebApi.Service
{
    public class DataSeed
    {
        private readonly MyDB context;

        public DataSeed(MyDB context)
        {
            this.context = context;
        }
        
        public void Fill()
        {
            var biglietto1 = new Biglietto
            {
                Id = 1,
                Cognome = "Venditti",
                Nome = "Antonio",
                Costo = 10,
                DataEvento = new DateTime(2021, 6, 14),
                NumeroSedia = "M4",
                Posizione = Posizioni.Galleria
            };
            biglietto1.Evento = new Evento
            {
                Id = 10,
                Nome = "evento1",
                Data = DateTime.Now,
                Biglietti = new List<Biglietto> {biglietto1}
            };
            context.Biglietti.Add(biglietto1);
            
            context.Biglietti.Add(
                new Biglietto
                {
                    Id = 2,
                    Cognome = "Venditti",
                    Nome = "Antonio",
                    Costo = 10,
                    DataEvento = new DateTime(2021, 6, 14),
                    NumeroSedia = "M4",
                    Posizione = Posizioni.Galleria
                });

            context.Eventi.Add(
                new Evento
                {
                    Id = 1,
                    Nome = "Evento 1",
                    Data = new DateTime(2021, 3, 1, 10, 30, 0)
                });

            context.Eventi.Add(
                new Evento
                {
                    Id = 2,
                    Nome = "Evento 2",
                    Data = new DateTime(2021, 3, 1, 10, 30, 0)
                });
            context.SaveChanges();
        }
    }
}
