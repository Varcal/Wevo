using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wevo.Dominio.Entidades;

namespace Wevo.Dados.Mapeamentos
{
    public sealed class ClienteMap: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente", "dbo");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Nome, config =>
            {
                config.Property(x => x.Texto)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Cpf, config =>
            {
                config.Property(x => x.Numero)
                    .HasColumnName("Cpf")
                    .HasColumnType("char(11)")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Email, config =>
            {
                config.Property(x => x.Endereco)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(150)")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Telefone, config =>
            {
                config.Property(x => x.Numero)
                    .HasColumnName("Telefone")
                    .HasColumnType("char(11)")
                    .IsRequired();
            });

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
