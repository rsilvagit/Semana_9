using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace m02s09_exercicio.DTO
{
    public class SemanaCreateDTO
    {
        public int Id { get; set; }
        public DateTime DataSemana { get; set; }
        public string? Conteudo { get; set; }
        public bool AplicadoConteudo { get; set; }
    }
}