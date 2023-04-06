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

        public Task AtualizarAvalicao(Avaliacao avaliacao)
        {
            throw new NotImplementedException();
        }

        public Task<Avaliacao> BuscarAvaliacao(int id)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirAvaliacao(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Avaliacao>> FiltrarAvaliacoesPorMateria(int materiaId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Avaliacao>> FiltrarPeloTipoDeAvalicao(Tipo tipo)
        {
            throw new NotImplementedException();
        }

        public Task InserirAvaliacao(Avaliacao avaliacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<Avaliacao>> ListarTodasAvaliacoes()
        {
            throw new NotImplementedException();
        }
    }
}




