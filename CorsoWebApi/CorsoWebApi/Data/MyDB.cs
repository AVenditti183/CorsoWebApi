using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CorsoWebApi.Data
{
    public class MyDB :DbContext
    {
        public MyDB(DbContextOptions<MyDB> options):base(options)
        {   
        }

        public DbSet<Biglietto> Biglietti { get; set; }
        public DbSet<Evento> Eventi { get; set; }
        public DbSet<Agenzia> Agenze { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biglietto>().HasData(
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
                    NumeroSedia = "M4",
                    Posizione = Posizioni.Galleria
                });
            
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
