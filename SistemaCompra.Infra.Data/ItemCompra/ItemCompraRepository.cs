using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.ItemCompra
{
    public class ItemCompraRepository : SolicitacaoCompraAgg.IItemCompraRepository
    {
        private readonly SistemaCompraContext _context;

        public ItemCompraRepository(SistemaCompraContext context)
        {
            _context = context;
        }
    }
}