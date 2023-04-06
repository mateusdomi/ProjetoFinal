using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Disciplinas;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Infra;
using ProjetoFinal.Models.Disciplinas;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task<Disciplina> BuscarDisciplina(int id)
        {
            return await _context.Disciplinas.FindAsync(id);
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
            var disciplina = await _context.Disciplinas.FindAsync(id);
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DisciplinaExists(int id)
        {
            return await _context.Disciplinas.AnyAsync(d => d.DisciplinaId == id);
        }
    }
}



