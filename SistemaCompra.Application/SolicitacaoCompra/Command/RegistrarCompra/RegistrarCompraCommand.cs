using System;
using System.Collections.Generic;
using MediatR;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public IList<ItemDto> Itens { get; set; }
        public int CondicaoPagamento { get; set; }
    }

    public class ItemDto
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
    
    
}