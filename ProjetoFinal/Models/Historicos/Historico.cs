using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Historicos
{
    public class Historico
    {
        public int HistoticoId { get; set; }
        public int AlunoId { get; set; } 
        public Aluno Aluno { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
