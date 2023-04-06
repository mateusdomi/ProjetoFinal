using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ProjetoFinalContext _context;

        public UsuarioService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task InserirAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

