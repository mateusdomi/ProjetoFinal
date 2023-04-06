using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Turmas;


namespace ProjetoFinal.Models.Series
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string Nome { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
        public Serie() { }

        public Serie(int serieId, string nome)
        {
            SerieId = serieId;
            Nome = nome;
        }
    }
}
