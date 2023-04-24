using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class CompraRegistradaEventHandler : INotificationHandler<CompraRegistradaEvent>
    {
        public Task Handle(CompraRegistradaEvent request, CancellationToken cancellationToken)
        {
            return null; //Todo SignalIR
        }
    }
}