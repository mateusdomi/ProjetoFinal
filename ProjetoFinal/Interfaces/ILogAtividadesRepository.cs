namespace ProjetoFinal.Interfaces
{
    using ProjetoFinal.Models;
    using ProjetoFinal.Models.LogRegistros;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILogAtividadeRepository
    {
        Task<IEnumerable<Log>> GetLogAtividadesAsync();
        Task<Log> GetLogAtividadeByIdAsync(int id);
        Task CreateLogAtividadeAsync(Log logAtividade);
        Task UpdateLogAtividadeAsync(Log logAtividade);
        Task DeleteLogAtividadeAsync(int id);
    }
}
