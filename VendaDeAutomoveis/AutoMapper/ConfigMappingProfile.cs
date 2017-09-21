using AutoMapper;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.AutoMapper
{
    public class ConfigMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<GDC_Clientes, Cliente>().ReverseMap();
            CreateMap<GDC_Enderecos, Endereco>().ReverseMap();
            CreateMap<GDC_Logins, Login>().ReverseMap();
            CreateMap<GDC_Vendas, Venda>().ReverseMap();
            CreateMap<GDC_Veiculos, Veiculo>().ReverseMap();
            CreateMap<GDC_Rodas, Roda>().ReverseMap();
        }
    }
}