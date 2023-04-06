using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Series;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Turmas
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma()
        {

        }

        public Turma(int turmaId, string nome)
        {
            TurmaId = turmaId;
            Nome = nome;
        }
    }
}
