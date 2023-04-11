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
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor> ObterPorIdAsync(int id)
        {
            return await _context.Professor.FindAsync(id);
        }

        public async Task InserirAsync(Professor professor)
        {
             _context.Professor.Add(professor);        
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Professor professor)
        {
             _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();
        }
    }

}
