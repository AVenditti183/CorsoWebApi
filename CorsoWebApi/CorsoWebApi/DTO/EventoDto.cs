using System;

namespace CorsoWebApi.DTO
{
    public class EventoDto : DtoEntity
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }
    }
}