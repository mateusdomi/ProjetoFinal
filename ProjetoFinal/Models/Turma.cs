namespace ProjetoFinal.Models
{
    public class Turma
    {
        public int Id { get; set; } // chave primária
        public string Nome { get; set; }
        public DateTime Horario { get; set; }
        public int IdProfessor { get; set; } // chave estrangeira
        public Usuario Professor { get; set; }
    }
}
