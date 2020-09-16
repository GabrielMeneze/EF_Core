using EF_Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1TD889U\SQLexpress;Initial Catalog=EF_Core;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
