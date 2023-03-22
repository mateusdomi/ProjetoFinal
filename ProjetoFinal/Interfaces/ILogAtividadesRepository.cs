namespace ProjetoFinal.Interfaces
{
    using ProjetoFinal.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogAtividadeRepository
    {
        Task<IEnumerable<LogAtividade>> GetLogAtividadesAsync();
        Task<LogAtividade> GetLogAtividadeByIdAsync(int id);
        Task CreateLogAtividadeAsync(LogAtividade logAtividade);
        Task UpdateLogAtividadeAsync(LogAtividade logAtividade);
        Task DeleteLogAtividadeAsync(int id);
    }
}
