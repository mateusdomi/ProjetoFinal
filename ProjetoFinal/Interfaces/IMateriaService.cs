using ProjetoFinal.Models.Materias;

namespace ProjetoFinal.Interfaces
{
    public interface IMateriaService
    {

        Task<List<Materia>> ListarTodasMaterias();
        Task<Materia> BuscarMateria(int id);
        Task InserirMateria(Materia materia);
        Task AtualizarMateria(Materia materia);
        Task ExcluirMateria(int id);
        Task<bool> MateriaExists(int id);

    }
}
