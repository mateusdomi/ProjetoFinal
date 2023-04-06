using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Avalicacao.Enums;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Infra;
using ProjetoFinal.Models.Avaliacoes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFinal.Data;

namespace ProjetoFinal.Infra
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly ProjetoFinalContext _context;

        public AvaliacaoService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public async Task<List<Avaliacao>> ListarTodasAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> BuscarAvaliacao(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task<List<Avaliacao>> FiltrarPeloTipoDeAvalicao(Tipo tipo)
        {
            return await _context.Avaliacoes.Where(a => a.Tipo == tipo).ToListAsync();
        }

        public async Task<List<Avaliacao>> FiltrarAvaliacoesPorMateria(int materiaId)
        {
            return await _context.Avaliacoes.Where(a => a.MateriaId == materiaId).ToListAsync();
        }

        public async Task InserirAvaliacao(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAvalicao(Avaliacao avaliacao)
        {
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AvaliacaoExists(int id)
        {
            return await _context.Avaliacoes.AnyAsync(a => a.AvaliacaoId == id);
        }
    }
}




