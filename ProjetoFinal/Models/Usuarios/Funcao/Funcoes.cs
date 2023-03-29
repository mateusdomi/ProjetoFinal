using ProjetoFinal.Models.Usuarios.Enums;

namespace ProjetoFinal.Models.Usuarios.Funcao
{
    public class Funcoes
    {
        public static FuncaoUsuario SuperAdmin = new FuncaoUsuario
        {
            Nome = "SuperAdmin",
            Permissoes = new List<Permissao>
            {
                Permissao.CriaAvaliacao,
                Permissao.VisualizaAvaliacao,
                Permissao.AlteraAvalicao,
                Permissao.CriaUsuario,
                Permissao.AlteraAvalicao,
                Permissao.VisualizaUsuario
            }
        };

        public static FuncaoUsuario Aluno = new FuncaoUsuario
        {
            Nome = "Aluno",
            Permissoes = new List<Permissao>
            {
                Permissao.VisualizaAvaliacao
            }
        };

        public static FuncaoUsuario Professor = new FuncaoUsuario
        {
            Nome = "Professor",
            Permissoes = new List<Permissao>
            {
                Permissao.CriaAvaliacao,
                Permissao.VisualizaAvaliacao,
                Permissao.AlteraAvalicao,
                Permissao.VisualizaUsuario
            }
        };
    }
}
