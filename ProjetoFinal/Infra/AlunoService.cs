using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AlunoService : IAlunoService
    {
        private readonly ProjetoFinalContext _context;

        public AlunoService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> ObterTodosAsync()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> ObterPorIdAsync(int id)
        {
            return await _context.Aluno.FindAsync(id);
        }

        public async Task InserirAsync(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Aluno aluno)
        {
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
