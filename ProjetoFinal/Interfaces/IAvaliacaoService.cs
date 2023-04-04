using ProjetoFinal.Models;
using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Avalicacao.Enums;

namespace ProjetoFinal.Interfaces
{
    public interface IAvaliacaoService
    {
       
            Task<List<Avaliacao>> ListarTodasAvaliacoes();
            Task<Avaliacao> BuscarAvaliacao(int id);
            Task<List<Avaliacao>> FiltrarPeloTipoDeAvalicao(Tipo tipo);
            Task<List<Avaliacao>> FiltrarAvaliacoesPorMateria(int materiaId);
            Task InserirAvaliacao(Avaliacao avaliacao);
            Task AtualizarAvalicao(Avaliacao avaliacao);
            Task ExcluirAvaliacao(int id);
        

    }

}
