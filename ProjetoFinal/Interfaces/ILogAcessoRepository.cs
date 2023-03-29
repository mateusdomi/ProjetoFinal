using ProjetoFinal.Models;
using ProjetoFinal.Models.LogRegistros;

namespace ProjetoFinal.Interfaces
{
    public interface ILogAcessoRepository
    {
        Task<Log> GetByIdAsync(int id);
        Task<List<Log>> GetAllAsync();
        Task AddAsync(Log logAcesso);
        Task UpdateAsync(Log logAcesso);
        Task DeleteAsync(int id);
    }
}
