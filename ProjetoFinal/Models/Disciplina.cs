namespace ProjetoFinal.Models
{
    public class Disciplina
    {
        public int Id { get; set; } // chave primária
        public string Nome { get; set; }
        public int IdProfessor { get; set; } // chave estrangeira
        public Usuario Professor { get; set; }
    }
}

