using ProjetoFinal.Models.LogRegistros.Enums;
using ProjetoFinal.Models.LogRegistros;

namespace ProjetoFinal.Interfaces
{
    public interface ILogService
    {

        Task<List<Log>> ListarLogs();
        Task<Log> BuscarLog(int id);
        Task<List<Log>> FiltrarLogsPorTipo(TipoLog tipo);
        Task<List<Log>> FiltrarLogsPorUsuario(int usuarioId);
        Task InserirLog(Log log);
        Task AtualizarLog(Log log);
        Task ExcluirLog(int id);
        Task<bool> LogExists(int id);
    }


}
