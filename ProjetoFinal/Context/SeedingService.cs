using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Series;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Usuarios;
using ProjetoFinal.Models.Usuarios.Enums;
using ProjetoFinal.Models.Avalicacao.Enums;

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

            Materia materia1 = new Materia { Nome = "Pronome" };
            Materia materia2 = new Materia { Nome = "Algebra" };

            Disciplina disciplina1 = new Disciplina { Nome = "Portugues" };
            Disciplina disciplina2 = new Disciplina { Nome = "Matemática" };
            disciplina1.Materias.Add(materia1);
            disciplina2.Materias.Add(materia2);


            Serie serie1 = new Serie { Nome = "Segundo Ano" };
            serie1.Disciplinas.Add(disciplina1);
            serie1.Disciplinas.Add(disciplina2);

            Turma turma1 = new Turma { Nome = "2001" };
            Turma turma2 = new Turma { Nome = "2002" };
            serie1.Turmas.Add(turma1);
            serie1.Turmas.Add(turma2);

            Pessoa pessoa1 = new Pessoa { Nome = "Joao", UltimoNome = "Miranda", Email = "joao@gmail.com", Telefone = "(21)99452845", Nascimento = new DateTime(2003, 05, 18) };
            Pessoa pessoa2 = new Pessoa { Nome = "Lucas", UltimoNome = "Damazio", Email = "lucas@gmail.com", Telefone = "(21)939452845", Nascimento = new DateTime(2001, 03, 23) };
            Pessoa pessoa3 = new Pessoa { Nome = "Maria", UltimoNome = "Lopes", Email = "maria@gmail.com", Telefone = "(21)99425845", Nascimento = new DateTime(2000, 05, 23) };
            Pessoa pessoa4 = new Pessoa { Nome = "Joana", UltimoNome = "Ribeiro", Email = "joana@gmail.com", Telefone = "(21)994452845", Nascimento = new DateTime(2006, 01, 27) };

            Professor professor1 = new Professor { Pessoa = pessoa1, Disciplina = disciplina1 };
            Professor professor2 = new Professor { Pessoa = pessoa2, Disciplina = disciplina2 };
            Aluno aluno1 = new Aluno { Pessoa = pessoa3, Turma = turma1 };
            Aluno aluno2 = new Aluno { Pessoa = pessoa4, Turma = turma1 };
            disciplina1.Professores.Add(professor1);
            disciplina2.Professores.Add(professor2);
            turma1.Alunos.Add(aluno1);
            turma2.Alunos.Add(aluno2);

            Usuario usuario1 = new Usuario { UserName = "joaoM", Email = "joao@gmail.com", Password = "joao", CreateAt = new DateTime(2023, 02, 01), Atividade = Atividade.Sim, Pessoa = pessoa1 };
            Usuario usuario2 = new Usuario { UserName = "lucasD", Email = "lucas@gmail.com", Password = "lucas", CreateAt = new DateTime(2023, 03, 02), Atividade = Atividade.Sim, Pessoa = pessoa2 };

            Avaliacao avaliacao1 = new Avaliacao { Tipo = Tipo.Exercicio, Data = new DateTime(2023, 04, 03), Materia = materia1, Nota = 100 };
            Avaliacao avaliacao2 = new Avaliacao { Tipo = Tipo.Prova, Data = new DateTime(2023, 05, 03), Materia = materia2, Nota = 70 };
            Avaliacao avaliacao3 = new Avaliacao { Tipo = Tipo.Exercicio, Data = new DateTime(2023, 04, 03), Materia = materia1, Nota = 100 };
            Avaliacao avaliacao4 = new Avaliacao { Tipo = Tipo.Prova, Data = new DateTime(2023, 05, 03), Materia = materia2, Nota = 65 };

            aluno1.Avaliacoes.Add(avaliacao1);
            aluno1.Avaliacoes.Add(avaliacao2);
            aluno2.Avaliacoes.Add(avaliacao3);
            aluno2.Avaliacoes.Add(avaliacao4);



            turma1.Alunos.Add(aluno1);


            _context.Serie.Add(serie1);
            _context.Usuario.AddRange(usuario1, usuario2);
            _context.Pessoa.AddRange(pessoa1, pessoa2, pessoa3, pessoa4);
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