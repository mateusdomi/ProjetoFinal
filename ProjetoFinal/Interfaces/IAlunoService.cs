using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface IAlunoService 
    {
        Task<List<Aluno>> ObterTodosAsync();
        Task<Aluno> ObterPorIdAsync(int id);
        Task InserirAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
        Task RemoverAsync(Aluno aluno);
    }
}
