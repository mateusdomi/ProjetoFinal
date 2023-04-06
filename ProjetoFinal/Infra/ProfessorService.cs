using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class ProfessorService : IProfessorService
    {
        private readonly ProjetoFinalContext _context;

        public ProfessorService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> ObterTodosAsync()
        {
            return await _context.ObterTodosAsync();
        }

        public async Task<Professor> ObterPorIdAsync(int id)
        {
            return await _context.ObterPorIdAsync(id);
        }

        public async Task InserirAsync(Professor professor)
        {
            await _context.InserirAsync(professor);
        }

        public async Task AtualizarAsync(Professor professor)
        {
            await _context.AtualizarAsync(professor);
        }

        public async Task RemoverAsync(Professor professor)
        {
            await _context.RemoverAsync(professor);
        }
    }

}
