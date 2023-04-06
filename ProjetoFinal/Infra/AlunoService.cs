using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AlunoService : IAlunoService
    {
        private readonly ApplicationDbContext _context;

        public AlunoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> ObterTodosAsync()
        {
            return await _context.ObterTodosAsync();
        }

        public async Task<Aluno> ObterPorIdAsync(int id)
        {
            return await _context.ObterPorIdAsync(id);
        }

        public async Task InserirAsync(Aluno aluno)
        {
            await _context.InserirAsync(aluno);
        }

        public async Task AtualizarAsync(Aluno aluno)
        {
            await _context.AtualizarAsync(aluno);
        }

        public async Task RemoverAsync(Aluno aluno)
        {
            await _context.RemoverAsync(aluno);
        }
    }
}
