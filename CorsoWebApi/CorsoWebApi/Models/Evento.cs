using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoWebApi.Models
{
    public class Evento:EntityBase
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Biglietto> Biglietti {get;set;}
    }
}
