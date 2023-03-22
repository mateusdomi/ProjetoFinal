using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> SaveLoginAsync(Login login);
    }
}
