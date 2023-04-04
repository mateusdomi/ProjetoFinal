using ProjetoFinal.Models.Series;

namespace ProjetoFinal.Interfaces
{
    public interface ISerieService
    {
        Task<List<Serie>> ObterTodosAsync();
        Task<Serie> ObterPorIdAsync(int id);
        Task InserirAsync(Serie serie);
        Task AtualizarAsync(Serie serie);
        Task RemoverAsync(Serie serie);
    }

}
