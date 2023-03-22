namespace ProjetoFinal.Models
{
    public class Avaliacao
    {
        public int Id { get; set; } // chave primária
        public string Materia { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public int IdTurma { get; set; } // chave estrangeira
        public Turma Turma { get; set; }
        public int IdDisciplina { get; set; } // chave estrangeira
        public Disciplina Disciplina { get; set; }
        public int IdProfessor { get; set; } // chave estrangeira
        public Usuario Professor { get; set; }
    }
}
