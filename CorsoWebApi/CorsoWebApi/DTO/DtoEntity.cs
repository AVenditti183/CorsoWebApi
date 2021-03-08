using System.ComponentModel.DataAnnotations;

namespace CorsoWebApi.DTO
{
    public abstract class DtoEntity
    {
        [Key]
        public int Id { get; set; }
    }

}
