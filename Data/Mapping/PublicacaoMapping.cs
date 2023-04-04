using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Mapping
{
    public class PublicacaoMapping : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.ToTable("Publicacao");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(max)");

            builder.Property(prop => prop.Area)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Area")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Autor)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Autor")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.DataPublicacao)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("DataPublicacao")
                .HasColumnType("varchar(100)");
        }
    }
}
