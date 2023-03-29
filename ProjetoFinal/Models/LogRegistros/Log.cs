using ProjetoFinal.Models.LogRegistros.Enums;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.LogRegistros
{
    public class Log
    {
        public int Id { get; set; }
        public TipoLog TipoLog { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
    }
}
