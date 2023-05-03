using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace m02s09_exercicio.Model
{
    [Table("Semana")]
    public class SemanaModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataSemana { get; set; }

        [MaxLength(100)]
        public string? Conteudo { get; set; }

        public bool AplicadoConteudo { get; set; }                
    }
}
