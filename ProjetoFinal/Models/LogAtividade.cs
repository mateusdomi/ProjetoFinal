namespace ProjetoFinal.Models
{
    public class LogAtividade
    {
        public int Id { get; set; } // chave primária
        public int IdUsuario { get; set; } // chave estrangeira
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
    }
}
