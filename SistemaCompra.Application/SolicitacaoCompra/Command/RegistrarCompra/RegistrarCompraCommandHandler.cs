using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        
        public RegistrarCompraCommandHandler(
            IProdutoRepository produtoRepository,
            ISolicitacaoCompraRepository solicitacaoCompraRepository, 
            IUnitOfWork uow, 
            IMediator mediator) : base(uow, mediator)
        {
            _produtoRepository = produtoRepository;
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solicitacaoCompra = new Domain.SolicitacaoCompraAggregate.SolicitacaoCompra(
                request.NomeFornecedor,
                request.NomeFornecedor
            );

            
            solicitacaoCompra.AdicionarCondicaoPagamento(request.CondicaoPagamento);
            solicitacaoCompra.RegistrarCompra(solicitacaoCompra.Itens);
            
            foreach (var item in request.Itens)
            {
                var produto = _produtoRepository.Obter(item.ProdutoId);
                solicitacaoCompra.AdicionarItem(produto, item.Quantidade);
            }

            _solicitacaoCompraRepository.Registrar(solicitacaoCompra);

            Commit();
            PublishEvents(solicitacaoCompra.Events);

            return Task.FromResult(true);
        }
    }
}