using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Models.Usuarios
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public Professor()
        {

        }

        public Professor(int professorId, int pessoaId, Pessoa pessoa, int disciplinaId, Disciplina disciplina)
        {
            ProfessorId = professorId;
            PessoaId = pessoaId;
            Pessoa = pessoa;
            DisciplinaId = disciplinaId;
            Disciplina = disciplina;
        }
    }
}
