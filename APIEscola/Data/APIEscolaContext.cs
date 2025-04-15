using APIEscola.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIEscola.Data
{
    public class APIEscolaContext : IdentityDbContext // Herança do IdentityDbContext para autenticação
    {
        // Construtor que recebe as opções de configuração do DbContext
        public APIEscolaContext(DbContextOptions<APIEscolaContext> options) : base(options)
        { }

        // Propriedade DbSet para cada tabela 
        public DbSet<Aluno> Alunos { get; set; } // Tabela de Alunos
        public DbSet<Curso> Cursos { get; set; } // Tabela de Cursos
        public DbSet<Turma> Turmas { get; set; } // Tabela de Turmas
        public DbSet<Matricula> Matriculas { get; set; } // Tabela de Matrículas


        // Sobrecarga do método OnModelCreating para configurar o modelo a partir da IdentityDbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama o método OnModelCreating da classe base para a criação das tabelas padrão
            base.OnModelCreating(modelBuilder);
            // Configurar a criação de tabelas adicionais aqui
            modelBuilder.Entity<Aluno>().ToTable("Alunos"); // Define o nome da tabela para Alunos
            modelBuilder.Entity<Curso>().ToTable("Cursos");
            modelBuilder.Entity<Turma>().ToTable("Turmas");
            modelBuilder.Entity<Matricula>().ToTable("Matriculas");

        }
    }
}

