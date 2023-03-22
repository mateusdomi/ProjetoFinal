namespace ProjetoFinal.Models
{
    public class Notificacao
    {
        public int Id { get; set; } // chave primária
        public int IdUsuario { get; set; } // chave estrangeira
        public Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
    }
}
