using ProjetoFinal.Models.Notificacoes.Enums;

namespace ProjetoFinal.Models.Notificacoes
{
    public class Mensagem
    {
        public int MensagemId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }

        public Mensagem()
        {

        }
        public Mensagem(int id, string nome, string descricao, Status status)
        {
            MensagemId = id;
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }
    }
}
