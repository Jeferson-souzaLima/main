using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAulas.Business.Models;

namespace ProjetoAulas.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //Relacionamento 1 p/ 1 
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //Relacionamento 1 p/N
            builder.HasMany(f => f.Produtos)
               .WithOne(e => e.Fornecedor)
               .HasForeignKey(propa => propa.FornecedorId);

            builder.ToTable("TB_FORNECEDOR");




        }
    }
}
