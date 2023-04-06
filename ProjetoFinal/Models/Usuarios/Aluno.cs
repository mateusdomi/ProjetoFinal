using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models.Usuarios
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
        public Aluno()
        {

        }
        public Aluno(int alunoId, int pessoaId, Pessoa pessoa, int turmaId, Turma turma)
        {
            AlunoId = alunoId;
            PessoaId = pessoaId;
            Pessoa = pessoa;
            TurmaId = turmaId;
            Turma = turma;
        }
    }
}
