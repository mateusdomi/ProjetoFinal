using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Materias;

namespace ProjetoFinal.Infra
{
    public class MateriaService : IMateriaService
    {
        private readonly ProjetoFinalContext _context;

        public MateriaService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Materia>> ListarTodasMaterias()
        {
            return await _context.Materia.ToListAsync();
        }

        public async Task<Materia> BuscarMateria(int id)
        {
            return await _context.Materia.FindAsync(id);
        }

        public async Task InserirMateria(Materia materia)
        {
            _context.Materia.Add(materia);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarMateria(Materia materia)
        {
            _context.Entry(materia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirMateria(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            if (materia != null)
            {
                _context.Materia.Remove(materia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MateriaExists(int id)
        {
            return await _context.Materia.AnyAsync(e => e.MateriaId == id);
        }
    }

}
