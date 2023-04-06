using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AdministradorService : IAdministradorService
    {
        private readonly ApplicationDbContext _context;

        public AdministradorService(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<List<Administrador>> ObterTodosAsync()
        {
            return await _context.ObterTodosAsync();
        }

        public async Task<Administrador> ObterPorIdAsync(int id)
        {
            return await _context.ObterPorIdAsync(id);
        }

        public async Task InserirAsync(Administrador administrador)
        {
            await _context.InserirAsync(administrador);
        }

        public async Task AtualizarAsync(Administrador administrador)
        {
            await _context.AtualizarAsync(administrador);
        }

        public async Task RemoverAsync(Administrador administrador)
        {
            await _context.RemoverAsync(administrador);
        }
    }

}
