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
    public class EnderecoMapping : IEntityTypeConfiguration<FornecedorEndereco>
    {
        public void Configure(EntityTypeBuilder<FornecedorEndereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("TB_FORNECEDOR_ENDERECO");

        }
    }
}
