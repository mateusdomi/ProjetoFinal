using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AdministradorService : IAdministradorService
    {
        private readonly ProjetoFinalContext _context;

        public AdministradorService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Administrador>> ObterTodosAsync()
        {
            return await _context.Administrador.ToListAsync();
        }

        public async Task<Administrador> ObterPorIdAsync(int id)
        {
            return await _context.Administrador.FindAsync(id);
        }

        public async Task InserirAsync(Administrador administrador)
        {
            _context.Administrador.Add(administrador);
            await _context.SaveChangesAsync();

        }

        public async Task AtualizarAsync(Administrador administrador)
        {
            _context.Entry(administrador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Administrador administrador)
        {
            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();
        }
    }

}
