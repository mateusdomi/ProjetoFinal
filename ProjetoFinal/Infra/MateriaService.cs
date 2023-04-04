using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Materias;

namespace ProjetoFinal.Infra
{
    public class MateriaService : IMateriaService
    {
        private readonly MeuDbContext _context;

        public MateriaService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<List<Materia>> ListarTodasMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task<Materia> BuscarMateria(int id)
        {
            return await _context.Materias.FindAsync(id);
        }

        public async Task InserirMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarMateria(Materia materia)
        {
            _context.Entry(materia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> MateriaExists(int id)
        {
            return await _context.Materias.AnyAsync(e => e.MateriaId == id);
        }
    }

}
