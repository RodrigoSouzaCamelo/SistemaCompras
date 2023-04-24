using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoCompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _context;
        
        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this._context = context;
        }
        
        public void Registrar(SolicitacaoCompraAgg.SolicitacaoCompra entity)
        {
            _context.Set<SolicitacaoCompraAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}