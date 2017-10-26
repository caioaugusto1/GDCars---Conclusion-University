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

            CreateMap<GDC_Enderecos, Endereco>()
                .ForMember(e => e.EnderecoNome, map => map.MapFrom(y => y.Endereco));

            CreateMap<Endereco, GDC_Enderecos>()
               .ForMember(e => e.Endereco, map => map.MapFrom(y => y.EnderecoNome));

            CreateMap<GDC_Logins, Login>().ReverseMap();
            CreateMap<GDC_Vendas, Venda>().ReverseMap();
            CreateMap<GDC_Veiculos, Veiculo>().ReverseMap();
            CreateMap<GDC_Formas_Pagamentos, FormaDePagamento>().ReverseMap();
            CreateMap<GDC_Perfomances, Performance>().ReverseMap();
            CreateMap<GDC_Rodas, Roda>().ReverseMap();
            CreateMap<GDC_Bancos, Banco>().ReverseMap();
            CreateMap<GDC_Cor_Veiculos, Cor_Veiculo>().ReverseMap();
            CreateMap<GDC_Uploads, Upload>().ReverseMap();
        }
    }
}