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
        
    }
}