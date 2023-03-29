using ProjetoFinal.Models.Disciplinas;

namespace ProjetoFinal.Models.Turmas
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Turma()
        {

        }
        public Turma(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarDisciplinas(Disciplina disciplina)
        {
            Disciplinas.Add(disciplina);
        }
        public void RemoverDisciplinas(Disciplina disciplina)
        {
            Disciplinas.Remove(disciplina);
        }
    }
}
