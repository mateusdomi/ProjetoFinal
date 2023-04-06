using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models.Usuarios;
using ProjetoFinal.Models.Disciplinas;
using ProjetoFinal.Models.Avaliacoes;
using ProjetoFinal.Models.Materias;
using ProjetoFinal.Models.Notificacoes;
using ProjetoFinal.Models.Turmas;
using ProjetoFinal.Models.Series;

namespace ProjetoFinal.Data
{
    public class ProjetoFinalContext : DbContext
    {
        public ProjetoFinalContext(DbContextOptions<ProjetoFinalContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Avaliacao>()
                .Property(p => p.Nota)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Alunos)
                .WithOne(a => a.Turma);


            modelBuilder.Entity<Usuario>().HasOne(p => p.Pessoa);


        }

        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Notificacao> Notificacao { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Serie> Serie { get; set; }
    }
}
