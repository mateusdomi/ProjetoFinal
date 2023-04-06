using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Repo
{
    public class Nota:INota
    {
        private ProjetoFinalContext _context;

        public Nota(ProjetoFinalContext context)
        {
            _context = context;
        }

        public Task Atualizar(Notificacao notificacao)
        {
            throw new NotImplementedException();
        }

        public Task Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(Notificacao notificacao)
        {
            throw new NotImplementedException();
        }

        public Task<Notificacao> ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notificacao>> ObterPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
