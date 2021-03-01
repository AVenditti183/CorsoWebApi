using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoWebApi.Models
{
    public class ModificaBigliettoCognomeNome
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
    }
}
