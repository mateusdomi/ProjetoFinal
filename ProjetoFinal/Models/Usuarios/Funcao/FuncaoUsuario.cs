using ProjetoFinal.Models.Usuarios.Enums;

namespace ProjetoFinal.Models.Usuarios.Funcao
{
    public class FuncaoUsuario
    {
        public string Nome { get; set; }
        public List<Permissao> Permissoes { get; set; }

        public FuncaoUsuario()
        {

        }
        public FuncaoUsuario(string nome)
        {
            Nome = nome;
        }
    }
}
