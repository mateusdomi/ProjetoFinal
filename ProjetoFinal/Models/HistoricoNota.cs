namespace ProjetoFinal.Models
{
    public class HistoricoNota
    {
        public int Id { get; set; } // chave primária
        public int IdAluno { get; set; } // chave estrangeira
        public Usuario Aluno { get; set; }
        public int IdDisciplina { get; set; } // chave estrangeira
        public Disciplina Disciplina { get; set; }
        public decimal NotaValor { get; set; }
    }
}

