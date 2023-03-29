using ProjetoFinal.Models.Disciplinas;

namespace ProjetoFinal.Models.Materias
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }

        public Materia()
        {
                
        }
        public Materia(int id, string name, int idDisciplina, Disciplina disciplina)
        {
            Id = id;
            Name = name;
            IdDisciplina = idDisciplina;
            Disciplina = disciplina;
        }
    }
}
