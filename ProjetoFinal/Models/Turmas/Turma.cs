using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Series;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Turmas
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Turma()
        {

        }

        public Turma(int turmaId, int serieId, Serie serie)
        {
            TurmaId = turmaId;
            SerieId = serieId;
            Serie = serie;
        }
    }
}
