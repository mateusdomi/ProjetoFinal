using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Notificacoes
{
    public class Notificacao
    {
        public int NotificacaoId { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public int IdMensagem { get; set; }
        public Mensagem Mensagem { get; set; }
        public Notificacao()
        {
                
        }

        public Notificacao(int id, int usuarioId, Usuario usuario, DateTime data, int idMensagem, Mensagem mensagem)
        {
            NotificacaoId = id;
            UsuarioId = usuarioId;
            Usuario = usuario;
            Data = data;
            IdMensagem = idMensagem;
            Mensagem = mensagem;
        }
    }
}
