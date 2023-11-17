using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContex : DbContext
    {

        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options)
            : base(options)
        {
        }

        public SistemaTarefasDBContex(DbSet<UsuarioModel> usuarios,
                                      DbSet<TarefaModel> tarefas)
        {
            Usuarios = usuarios;
            this.Tarefas = tarefas;
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }



        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.Entity<TarefaModel>().Ignore(e => e.UsuarioId); // ignore incluido
            modelBuilder.Entity<TarefaModel>().HasKey(e => e.UsuarioId); // haskey incluido


            base.OnModelCreating(modelBuilder);
        }
    }
}
