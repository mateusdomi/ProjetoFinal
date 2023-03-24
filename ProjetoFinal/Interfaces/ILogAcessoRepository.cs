using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface ILogAcessoRepository
    {
        Task<LogAcesso> GetByIdAsync(int id);
        Task<List<LogAcesso>> GetAllAsync();
        Task AddAsync(LogAcesso logAcesso);
        Task UpdateAsync(LogAcesso logAcesso);
        Task DeleteAsync(int id);
    }
}
