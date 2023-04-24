using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessRuleException = SistemaCompra.Domain.Core.BusinessRuleException;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public UsuarioSolicitante UsuarioSolicitante { get; private set; }
        public NomeFornecedor NomeFornecedor { get; private set; }
        public IList<ItemCompra> Itens { get; private set; }
        public DateTime Data { get; private set; }
        public Money TotalGeral { get; private set; }
        public Situacao Situacao { get; private set; }
        public CondicaoPagamento CondicaoPagamento { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string nomeFornecedor)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new UsuarioSolicitante(usuarioSolicitante);
            NomeFornecedor = new NomeFornecedor(nomeFornecedor);
            Data = DateTime.Now;
            Situacao = Situacao.Solicitado;
            Itens = new List<ItemCompra>();
        }

        public void AdicionarItem(Produto produto, int qtde)
        {
            Itens.Add(new ItemCompra(produto, qtde));
        }

        public void AdicionarCondicaoPagamento(int condicaoPagamento)
        {
            CondicaoPagamento = new CondicaoPagamento(condicaoPagamento);
        }

        public void RegistrarCompra(IEnumerable<ItemCompra> itens)
        {
            TotalGeral = new Money(itens.Aggregate(0, (acc, item) => item.Qtde));

            if (!itens.Any())
                throw new BusinessRuleException("O total de itens de compra deve ser maior que 0");

            if (TotalGeral.Value > 50000 && CondicaoPagamento.Valor != 30)
                throw new BusinessRuleException("Se o Total Geral for maior que 50000 a condição de pagamento deve ser 30 dias.");
            
            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral.Value));
        }
    }
}