using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Series;

namespace ProjetoFinal.Infra
{
    public class SerieService : ISerieService
    {
        private readonly MeuDbContext _context;

        public SerieService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<List<Serie>> ObterTodosAsync()
        {
            return await _context.Series.ToListAsync();
        }

        public async Task<Serie> ObterPorIdAsync(int id)
        {
            return await _context.Series.FindAsync(id);
        }

        public async Task InserirAsync(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Serie serie)
        {
            _context.Entry(serie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Serie serie)
        {
            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();
        }
    }

}
