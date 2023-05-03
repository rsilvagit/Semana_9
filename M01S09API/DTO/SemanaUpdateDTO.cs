namespace m02s09_exercicio.DTO
{
    public class SemanaUpdateDTO
    {
        public int Id { get; set; }
        public DateTime DataSemana { get; set; }
        public string? Conteudo { get; set; }
        public bool ConteudoAplicado { get; set; }
    }
}