using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Infra
{
    public class MensagemService : IMensagemService
    {
        private readonly MeuDbContext _context;

        public MensagemService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mensagem>> ObterTodasAsync()
        {
            return await _context.ObterTodasAsync();
        }

        public async Task<Mensagem> ObterPorIdAsync(int id)
        {
            return await _context.ObterPorIdAsync(id);
        }

        public async Task InserirAsync(Mensagem mensagem)
        {
            await _context.InserirAsync(mensagem);
        }

        public async Task AtualizarAsync(Mensagem mensagem)
        {
            await _context.AtualizarAsync(mensagem);
        }

        public async Task RemoverAsync(Mensagem mensagem)
        {
            await _context.RemoverAsync(mensagem);
        }
    }

}
