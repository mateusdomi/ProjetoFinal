using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Infra
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly ProjetoFinalContext _context;

        public NotificacaoService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacao>> ObterTodasAsync()
        {
            return await _context.Notificacao.ToListAsync();
        }

        public async Task<Notificacao> ObterPorIdAsync(int id)
        {
            return await _context.Notificacao.FindAsync(id);
        }

        public async Task InserirAsync(Notificacao notificacao)
        {
            _context.Notificacao.Add(notificacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Notificacao notificacao)
        {
            _context.Entry(notificacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Notificacao notificacao)
        {
             _context.Notificacao.Remove(notificacao);
            await _context.SaveChangesAsync();
        }
    }

}
