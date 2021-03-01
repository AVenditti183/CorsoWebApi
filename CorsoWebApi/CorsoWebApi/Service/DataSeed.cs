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
            context.Biglietti.Add(new Biglietto
            {
                Id = 1,
                Cognome = "Venditti",
                Nome = "Antonio",
                Costo = 10,
                DataEvento = new DateTime(2021, 6, 14),
                NumeroSedia = "M4",
                Posizione = Posizioni.Galleria
            });
            
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
            context.SaveChanges();
        }
    }
}
