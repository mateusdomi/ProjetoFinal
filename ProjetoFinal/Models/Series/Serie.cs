using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Models.Series
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string Nome { get; set; }
        public Serie() { }

        public Serie(int serieId, string nome)
        {
            SerieId = serieId;
            Nome = nome;
        }
    }
}
