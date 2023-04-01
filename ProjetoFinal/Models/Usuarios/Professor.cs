using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Models.Usuarios
{
    public class Professor : Usuario
    {
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

        public Professor()
        {

        }
        public Professor(int disciplinaId, Disciplina disciplina)
        {
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
        }
    }
}
