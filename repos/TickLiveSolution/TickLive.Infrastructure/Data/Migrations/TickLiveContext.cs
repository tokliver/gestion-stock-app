using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;

namespace TickLive.Infrastructure.Data
{
    public class TickLiveContext : DbContext
    {
        public TickLiveContext()
        {
        }

        public TickLiveContext(DbContextOptions<TickLiveContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase(databaseName: "GestionStockDb");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GORJMGN\\SQLEXPRESS;Initial Catalog=GestionStock;Integrated Security=True;Pooling=False");

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }
  
}
