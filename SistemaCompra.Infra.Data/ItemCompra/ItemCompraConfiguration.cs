using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.ItemCompra
{
    public class ItemCompraConfiguration: IEntityTypeConfiguration<SolicitacaoCompraAgg.ItemCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.ItemCompra> builder)
        {
            builder.ToTable("ItemCompra");
            builder.HasOne(ic => ic.SolicitacaoCompras)
                .WithMany(sc => sc.Itens)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(sc => sc.Produto)
                .WithMany(p => p.ItemsCompra)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}