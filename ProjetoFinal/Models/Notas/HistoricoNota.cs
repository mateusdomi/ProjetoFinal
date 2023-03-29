using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Notas
{
    public class HistoricoNota
    {
        public int Id { get; set; }
        public int IdAluno { get; set; } 
        public Aluno Aluno { get; set; }
        public int IdDisciplina { get; set; } 
        public Disciplina Disciplina { get; set; }
        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}
