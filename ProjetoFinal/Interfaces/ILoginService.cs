using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface ILoginService
    {
        public bool Criar(Usuario usuario);
        public string VrfCodigo(string codigo);
        public bool MudarSenha(string senha,string username);
        public bool EsqueciSenha(string email);
    }
}
