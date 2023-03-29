using ProjetoFinal.Models.Avalicacao.Enums;
using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Avaliacoes
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tipo Tipo { get; set; }
        public DateTime Data { get; set; }
        public int IdDisciplina { get; set; }
        public Disciplina Disciplina { get; set; }
        public int IMateria { get; set; }
        public Materia Materia { get; set; }
        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
        public int IdProfessor { get; set; }
        public Usuario Professor { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Avaliacao()
        {

        }
        public Avaliacao(int id, string nome, Tipo tipo, DateTime data, int idDisciplina, Disciplina disciplina, int iMateria, Materia materia, int idTurma, Turma turma, int idProfessor, Usuario professor)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Data = data;
            IdDisciplina = idDisciplina;
            Disciplina = disciplina;
            IMateria = iMateria;
            Materia = materia;
            IdTurma = idTurma;
            Turma = turma;
            IdProfessor = idProfessor;
            Professor = professor;
        }
    }
}
