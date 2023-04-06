using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class MensagemService : IMensagemService
    {
        private readonly ProjetoFinalContext _context;

        public MensagemService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Mensagem>> ObterTodasAsync()
        {
            return await _context.Mensagem.ToListAsync();
        }

        public async Task<Mensagem> ObterPorIdAsync(int id)
        {
            return await _context.Mensagem.FindAsync(id);
        }

        public async Task InserirAsync(Mensagem mensagem)
        {
            _context.Mensagem.Add(mensagem);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Mensagem mensagem)
        {
            _context.Entry(mensagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Mensagem mensagem)
        {
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
        }
    }

}
