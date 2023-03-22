namespace ProjetoFinal.Models
{
    public class Nota
    {
        public int Id { get; set; } // chave primária
        public int IdAvaliacao { get; set; } // chave estrangeira
        public Avaliacao Avaliacao { get; set; }
        public int IdAluno { get; set; } // chave estrangeira
        public Usuario Aluno { get; set; }
        public decimal NotaValor { get; set; }
    }
}

