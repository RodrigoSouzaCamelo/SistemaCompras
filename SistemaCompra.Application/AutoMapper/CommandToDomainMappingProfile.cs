using AutoMapper;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<ItemDto, Item>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.ProdutoId))
                .ForMember(d => d.Qtde, o => o.MapFrom(src => src.Quantidade))
                .ForMember(d => d.Produto, o => o.Ignore())
                .ForMember(d => d.Events, o => o.Ignore())
                .ForMember(d => d.Subtotal, o => o.Ignore());
        }
    }
}