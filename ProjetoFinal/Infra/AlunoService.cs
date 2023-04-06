using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AlunoService 
    {
        private readonly ProjetoFinalContext _context;

        public AlunoService(ProjetoFinalContext context)
        {
            _context = context;
        }
    }
}
