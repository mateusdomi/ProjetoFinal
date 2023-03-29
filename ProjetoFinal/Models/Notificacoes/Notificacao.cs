using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Notificacoes
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Data { get; set; }

        public int IdMensagem { get; set; }
        public Mesagem Mensagem { get; set; }
        public Notificacao(int id, int idUsuario, Usuario usuario, DateTime data, int idMensagem, Mesagem mensagem)
        {
            Id = id;
            IdUsuario = idUsuario;
            Usuario = usuario;
            Data = data;
            IdMensagem = idMensagem;
            Mensagem = mensagem;
        }
    }
}
