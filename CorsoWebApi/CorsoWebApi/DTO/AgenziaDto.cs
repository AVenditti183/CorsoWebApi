using System.ComponentModel.DataAnnotations;

namespace CorsoWebApi.DTO
{
    public class AgenziaDto : DtoEntity
    {
        [Required]
        public string NomeAgenzia { get; set; }

        [Required]
        public string PIVAAgenzia { get; set; }
    }
}