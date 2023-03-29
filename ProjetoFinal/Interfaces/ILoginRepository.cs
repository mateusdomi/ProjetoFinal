using ProjetoFinal.Models;
using ProjetoFinal.Models.Logins;

namespace ProjetoFinal.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> SaveLoginAsync(Login login);
    }
}
