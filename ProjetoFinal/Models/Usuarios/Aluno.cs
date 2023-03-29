using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Models.Usuarios
{
    public class Aluno:Usuario
    {
        public Turma Turma { get; set; }
        public Aluno()
        {
        }
        public Aluno(Turma turma)
        {
            Turma = turma;
        }
    }
}
