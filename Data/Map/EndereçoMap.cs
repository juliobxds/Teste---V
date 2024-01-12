using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste___V.Models;


namespace Teste___V.Data.Map {
    public class EndereçoMap : IEntityTypeConfiguration<EndereçoM> {
        public void Configure(EntityTypeBuilder<EndereçoM> builder) {

            builder.HasKey(keyExpression: x => x.Id);
            builder.Property(propertyExpression: x => x.NomeDaRua);
            builder.Property(x => x.NumeroDaRua);
            builder.Property(x => x.Bairro);
            builder.Property(x => x.PontoDeReferencia);
            builder.Property(x => x.IdCliente).HasColumnName("IdCliente");


        }
    }
}
