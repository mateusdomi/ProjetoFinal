using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Series;

namespace ProjetoFinal.Infra
{
    public class SerieService : ISerieService
    {
        private readonly ProjetoFinalContext _context;

        public SerieService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Serie>> ObterTodosAsync()
        {
            return await _context.Serie.ToListAsync();
        }

        public async Task<Serie> ObterPorIdAsync(int id)
        {
            return await _context.Serie.FindAsync(id);
        }

        public async Task InserirAsync(Serie serie)
        {
            _context.Serie.Add(serie);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Serie serie)
        {
            _context.Entry(serie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Serie serie)
        {
            _context.Serie.Remove(serie);
            await _context.SaveChangesAsync();
        }
    }

}
