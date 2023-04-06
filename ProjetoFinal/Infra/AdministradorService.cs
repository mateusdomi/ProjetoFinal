using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Infra
{
    public class AdministradorService 
    {
        private readonly ProjetoFinalContext _context;

        public AdministradorService(ProjetoFinalContext context)
        {
           _context = context;
        }
    }

}
