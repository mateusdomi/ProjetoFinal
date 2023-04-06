using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Disciplinas;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;

namespace ProjetoFinal.Infra
{

    public class DisciplinaService : IDisciplinaService
    {
        private readonly ProjetoFinalContext _context;

        public DisciplinaService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Disciplina>> ListarTodasDisciplinas()
        {
            return await _context.Disciplina.ToListAsync();
        }

        public async Task<Disciplina> BuscarDisciplina(int id)
        {
            return await _context.Disciplina.FindAsync(id);
        }

        public async Task InserirDisciplina(Disciplina disciplina)
        {
            _context.Add(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarDisciplina(Disciplina disciplina)
        {
            _context.Update(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirDisciplina(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DisciplinaExists(int id)
        {
            return await _context.Disciplina.AnyAsync(d => d.DisciplinaId == id);
        }
    }
}



