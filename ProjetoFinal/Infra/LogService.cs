using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.LogRegistros.Enums;
using ProjetoFinal.Models.LogRegistros;
using ProjetoFinal.Data;

namespace ProjetoFinal.Infra
{
    public class LogService : ILogService
    {
        private readonly ProjetoFinalContext _context;

        public LogService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> ListarLogs()
        {
            return await _context.Log.ToListAsync();
        }

        public async Task<Log> BuscarLog(int id)
        {
            return await _context.Log.FindAsync(id);
        }

        public async Task<List<Log>> FiltrarLogsPorTipo(TipoLog tipo)
        {
            return await _context.Log.Where(l => l.TipoLog == tipo).ToListAsync();
        }

        public async Task<List<Log>> FiltrarLogsPorUsuario(int usuarioId)
        {
            return await _context.Log.Where(l => l.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task InserirLog(Log log)
        {
            _context.Log.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarLog(Log log)
        {
            _context.Entry(log).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirLog(int id)
        {
            var log = await _context.Log.FindAsync(id);
            _context.Log.Remove(log);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LogExists(int id)
        {
            return await _context.Log.AnyAsync(l => l.Id == id);
        }
    }

}
