using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CorsoWebApi.Models;

namespace CorsoWebApi.DTO
{
    public class BigliettoDto:DtoEntity
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

        public EventoBigliettoDto Evento { get; set; }
    }

    public class EventoBigliettoDto:DtoEntity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }

    public abstract class DtoEntity
    {
        [Key]
        public int Id { get; set; }
    }

}
