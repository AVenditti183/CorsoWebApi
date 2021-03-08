using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CorsoWebApi.Models
{
    public class Agenzia : EntityBase
    {
        public Agenzia()
        {
            Biglietti = new HashSet<Biglietto>();
        }

        [Required]
        public string NomeAgenzia { get; set; }

        [Required]
        public string PIVAAgenzia { get; set; }

        public ICollection<Biglietto> Biglietti { get; set; }
    }
}