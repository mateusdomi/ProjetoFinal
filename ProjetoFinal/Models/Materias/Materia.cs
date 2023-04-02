using ProjetoFinal.Models.Disciplinas;

namespace ProjetoFinal.Models.Materias
{
    public class Materia
    {
        public int MateriaId { get; set; }
        public string Nome { get; set; }

        public Materia()
        {
                
        }
        public Materia(int materiaId, string nome)
        {
            MateriaId = materiaId;
            Nome = nome;
        }
    }
}
