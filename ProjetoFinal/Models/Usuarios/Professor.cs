using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Models.Usuarios
{
    public class Professor : Usuario
    {
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();

        public Professor()
        {
        }

        public Professor(int disciplinaId, Disciplina disciplina)
        {
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
        }

        public void AdicionarDisciplinas(Turma turma)
        {
            Turmas.Add(turma);
        }
        public void RemoverDisciplinas(Turma turma)
        {
            Turmas.Remove(turma);
        }
    }
}
