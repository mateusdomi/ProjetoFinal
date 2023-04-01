using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models.Disciplinas
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Materia> Materias { get; set; } = new List<Materia>();
        public ICollection<Professor> Professores { get; set; } = new List<Professor>();

        public Disciplina()
        {
        }

        public Disciplina(int id, string nome)
        {
            DisciplinaId = id;
            Nome = nome;
        }
    }
}
