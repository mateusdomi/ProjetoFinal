using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Notas
{
    public class Nota
    {
        public int Id { get; set; }
        public int IdAvaliacao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public int IdAluno { get; set; }
        public Usuario Aluno { get; set; }
        public decimal NotaValor { get; set; }

        public Nota()
        {
                
        }
        public Nota(int id, int idAvaliacao, Avaliacao avaliacao, int idAluno, Usuario aluno, decimal notaValor)
        {
            Id = id;
            IdAvaliacao = idAvaliacao;
            Avaliacao = avaliacao;
            IdAluno = idAluno;
            Aluno = aluno;
            NotaValor = notaValor;
        }
    }
}
