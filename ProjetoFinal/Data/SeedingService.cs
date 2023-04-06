using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Series;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Usuarios;
using ProjetoFinal.Models.Usuarios.Enums;

namespace ProjetoFinal.Data
{
    public class SeedingService
    {
        private ProjetoFinalContext _context;

        public SeedingService(ProjetoFinalContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Aluno.Any() ||
                _context.Professor.Any() ||
                _context.Usuario.Any() ||
                _context.Disciplina.Any() ||
                _context.Turma.Any() ||
                _context.Serie.Any())
            {
                return;
            }

            Materia materia1 = new Materia(1, "Pronome");
            Materia materia2 = new Materia(1, "Algebra");

            Disciplina disciplina1 = new Disciplina(1, "Portugues");
            Disciplina disciplina2 = new Disciplina(2, "Matemática");
            disciplina1.Materias.Add(materia1);
            disciplina2.Materias.Add(materia2);


            Serie serie1 = new Serie(1, "Segundo Ano");
            serie1.Disciplinas.Add(disciplina1);
            serie1.Disciplinas.Add(disciplina2);

            Turma turma1 = new Turma(1, "2001");
            Turma turma2 = new Turma(2, "2002");
            serie1.Turmas.Add(turma1);
            serie1.Turmas.Add(turma2);

            Pessoa pessoa1 = new Pessoa(1, "Joao", "Miranda", "joao@gmail.com", "(21)99452845", new DateTime(2003, 05, 18));
            Pessoa pessoa2 = new Pessoa(2, "Lucas", "Damazio", "lucas@gmail.com", "(21)939452845", new DateTime(2001, 03, 23));
            Pessoa pessoa3 = new Pessoa(3, "Maria", "Lopes", "maria@gmail.com", "(21)99425845", new DateTime(2000, 05, 23));
            Pessoa pessoa4 = new Pessoa(4, "Joana", "Ribeiro", "joana@gmail.com", "(21)994452845", new DateTime(2006, 01, 27));

            Professor professor1 = new Professor(1, 1, pessoa1, 1, disciplina1);
            Professor professor2 = new Professor(2, 2, pessoa2, 2, disciplina2);
            Aluno aluno1 = new Aluno(1, 3, pessoa3, 1, turma1);
            Aluno aluno2 = new Aluno(2, 4, pessoa4, 2, turma1);
            disciplina1.Professores.Add(professor1);
            disciplina2.Professores.Add(professor2);
            turma1.Alunos.Add(aluno1);
            turma2.Alunos.Add(aluno2);

            Usuario usuario1 = new Usuario(1, "joaoM", "joao@gmail.com", "joao", new DateTime(2023, 02, 01), Atividade.Sim, 1, pessoa1);
            Usuario usuario2 = new Usuario(2, "lucasD", "lucas@gmail.com", "lucas", new DateTime(2023, 03, 02), Atividade.Sim, 2, pessoa2);

            Avaliacao avaliacao1 = new Avaliacao(1, Models.Avalicacao.Enums.Tipo.Exercicio, new DateTime(2023, 04, 03), 1, materia1, 100);
            Avaliacao avaliacao2 = new Avaliacao(2, Models.Avalicacao.Enums.Tipo.Prova, new DateTime(2023, 05, 03), 1, materia2, 70);
            Avaliacao avaliacao3 = new Avaliacao(3, Models.Avalicacao.Enums.Tipo.Exercicio, new DateTime(2023, 04, 03), 1, materia1, 100);
            Avaliacao avaliacao4 = new Avaliacao(4, Models.Avalicacao.Enums.Tipo.Prova, new DateTime(2023, 05, 03), 1, materia2, 65);

            aluno1.Avaliacoes.Add(avaliacao1);
            aluno1.Avaliacoes.Add(avaliacao2);
            aluno2.Avaliacoes.Add(avaliacao3);
            aluno2.Avaliacoes.Add(avaliacao4);



            turma1.Alunos.Add(aluno1);


            _context.Serie.Add(serie1);
            _context.Turma.AddRange(turma1, turma2);
            _context.Disciplina.AddRange(disciplina1, disciplina2);
            _context.Materia.AddRange(materia1, materia2);
            _context.Professor.AddRange(professor1, professor2);
            _context.Avaliacao.AddRange(avaliacao1, avaliacao2, avaliacao3, avaliacao4);
            _context.Aluno.AddRange(aluno1, aluno2);

            _context.SaveChanges();

        }
    }
}
