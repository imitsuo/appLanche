using appLanche.Domain;
using Microsoft.EntityFrameworkCore;

namespace appLanche.Infrastructure
{
    public class LancheContext : DbContext
    {
        public LancheContext(DbContextOptions<LancheContext> options)
            : base(options)
        {
        }

        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<ItemDoPedido> ItensDoPedido { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }       

        public DbSet<IngredienteLanche> IngredienteLanche {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredienteLanche>()
            .HasKey(t => new { t.LancheId, t.IngredienteId });

            modelBuilder.Entity<IngredienteLanche>()
                .HasOne(i => i.Lanche)
                .WithMany(x => x.IngredienteLanche)
                .HasForeignKey(f => f.LancheId);

            modelBuilder.Entity<IngredienteLanche>()
                .HasOne(i => i.Ingrediente);
                //.WithMany(x => x.IngredienteLanche)
                //.HasForeignKey(i => i.IngredienteId);              
        }

    }
}