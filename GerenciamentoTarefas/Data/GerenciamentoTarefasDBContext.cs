using GerenciamentoTarefas.Data.Map;
using GerenciamentoTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefas.Data
{
    public class GerenciamentoTarefasDBContext : DbContext
    {
        public GerenciamentoTarefasDBContext(DbContextOptions<GerenciamentoTarefasDBContext> options)
            : base(options)
        {
        }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected void onModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
