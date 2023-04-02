using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models.Usuarios
{
    public class Aluno:Usuario
    {
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        public Aluno()
        {

        }

        public Aluno(int turmaId, Turma turma)
        {
            TurmaId = turmaId;
            Turma = turma;
        }
    }
}
