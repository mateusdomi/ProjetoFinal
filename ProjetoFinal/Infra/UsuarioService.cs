using Microsoft.EntityFrameworkCore;
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
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task InserirAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

