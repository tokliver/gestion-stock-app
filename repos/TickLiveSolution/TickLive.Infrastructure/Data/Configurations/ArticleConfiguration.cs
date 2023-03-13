using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;

namespace TickLive.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nom).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PrixVenteHT);
            builder.Property(u => u.PrixVenteTTC);
            builder.Property(u => u.QuantiteStock);
            builder.Property(u => u.IsVenteEmporter);
            builder.Property(u => u.ArticleType).IsRequired().HasConversion<string>().HasMaxLength(50);
            
        }
    }
}
