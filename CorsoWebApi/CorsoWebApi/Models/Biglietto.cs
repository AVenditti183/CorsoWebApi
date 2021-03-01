using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoWebApi.Models
{
    public class Biglietto: EntityBase
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        public DateTime? DataEvento { get; set; }

        [Required]
        [Range(2, 200)]
        public decimal? Costo { get; set; }
        public Posizioni? Posizione { get; set; }
        [Required]
        public string NumeroSedia { get; set; }
    }
    
    public enum Posizioni
    {
        Platea,
        Galleria
    }
}
