﻿using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Historicos;

namespace ProjetoFinal.Infra
{
    public class HistoricoService : IHistoricoService
    {
        private readonly MeuDbContext _dbContext;

        public HistoricoService(MeuDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Historico>> ListarHistorico()
        {
            return await _dbContext.Historicos.Include(h => h.Aluno).ToListAsync();
        }

        public async Task<Historico> BuscarHistorico(int id)
        {
            return await _dbContext.Historicos.Include(h => h.Aluno).FirstOrDefaultAsync(h => h.HistoricoNotaId == id);
        }

        public async Task<List<Historico>> FiltrarHistoricoPorAluno(int alunoId)
        {
            return await _dbContext.Historicos.Include(h => h.Aluno)
                                              .Where(h => h.AlunoId == alunoId)
                                              .ToListAsync();
        }

        public async Task InserirHistorico(Historico historico)
        {
            _dbContext.Historicos.Add(historico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarHistorico(Historico historico)
        {
            _dbContext.Entry(historico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ExcluirHistorico(int id)
        {
            var historico = await _dbContext.Historicos.FindAsync(id);
            _dbContext.Historicos.Remove(historico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> HistoricoExists(int id)
        {
            return await _dbContext.Historicos.AnyAsync(h => h.HistoricoNotaId == id);
        }
    }

}
