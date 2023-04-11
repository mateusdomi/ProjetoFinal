using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Infra
{
    public class TurmaService : ITurmaService
    {
        private readonly ProjetoFinalContext _context;

        public TurmaService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Turma>> ObterTodosAsync()
        {
            return await _context.Turma
                         .Include(t => t.Alunos)
                         .ToListAsync();
        }

        public async Task<Turma> ObterPorIdAsync(int id)
        {
            return await _context.Turma
                .Include(t => t.Alunos)
                .FirstOrDefaultAsync(t => t.TurmaId == id);
        }

        public async Task InserirAsync(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Turma turma)
        {
            _context.Entry(turma).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Turma turma)
        {
            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();
        }
    }

}
