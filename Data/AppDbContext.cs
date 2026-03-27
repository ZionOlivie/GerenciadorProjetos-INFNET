using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configura nomes das tabelas
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Projeto>().ToTable("Projetos");
            modelBuilder.Entity<Tarefa>().ToTable("Tarefas");

         
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.Gerente)
                .WithMany() 
                .HasForeignKey(p => p.GerenteResponsavelId)
                .OnDelete(DeleteBehavior.Restrict); 

         
            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Equipa)
                .WithMany(u => u.ProjetosParticipados)
                .UsingEntity(j => j.ToTable("ProjetoEquipes")); 

            base.OnModelCreating(modelBuilder);
        }
    }
}