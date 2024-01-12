using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste___V.Models;
using Teste___V.ViewModels;

namespace Teste___V.Data.Map {
    public class ClienteMap : IEntityTypeConfiguration<ClienteM> {
        public void Configure(EntityTypeBuilder<ClienteM> builder) {
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Celular).IsRequired().HasMaxLength(15);
            builder.HasOne(cliente => cliente.Endereco).WithOne(x => x.Cliente).HasForeignKey<EndereçoM>(x => x.IdCliente);
        }
    }
}
