using AutoMapper;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Models;
using VendaDeAutomoveis.Repository.ConnectionContext;

namespace VendaDeAutomoveis.AutoMapper
{
    public class ConfigMappingProfile : Profile
    {
        protected override void Configure()
        {
            #region Class / Entities

            CreateMap<GDC_Clientes, Cliente>()
                .ForMember(map => map.Endereco, e => e.MapFrom(y => y.GDC_Enderecos))
                .ReverseMap();

            CreateMap<GDC_Enderecos, Endereco>()
                .ForMember(e => e.EnderecoNome, map => map.MapFrom(y => y.Endereco));

            CreateMap<Endereco, GDC_Enderecos>()
               .ForMember(e => e.Endereco, map => map.MapFrom(y => y.EnderecoNome));

            CreateMap<GDC_Logins, Login>().ReverseMap();

            CreateMap<GDC_Vendas, Venda>()
                .ForMember(f => f.IdFormaDePagamento, map => map.MapFrom(y => y.IdFormaPagamento))
                .ForMember(f => f.IdPerfomance, map => map.MapFrom(y => y.IdPerformance))
                .ReverseMap();

            CreateMap<GDC_Veiculos, Veiculo>().ReverseMap();
            CreateMap<GDC_Formas_Pagamentos, FormaDePagamento>().ReverseMap();

            CreateMap<GDC_Perfomances, Performance>()
                .ForMember(e => e.IdCorVeiculo, map => map.MapFrom(y => y.IdCor_Veiculo))
                .ReverseMap();

            CreateMap<GDC_Rodas, Roda>().ReverseMap();
            CreateMap<GDC_Bancos, Banco>().ReverseMap();
            CreateMap<GDC_Cor_Veiculos, Cor_Veiculo>().ReverseMap();
            CreateMap<GDC_Uploads, Upload>().ReverseMap();

            #endregion

            #region ViewMoels 

            CreateMap<GDC_Vendas, DetailsDeleteVendaViewModel>()
                .ForMember(map => map.Cliente, map => map.MapFrom(y => y.GDC_Clientes))
                .ForMember(map => map.FormaDePagamento, map => map.MapFrom(y => y.GDC_Formas_Pagamentos))
                 .ForMember(map => map.Performance, map => map.MapFrom(y => y.GDC_Perfomances)).ReverseMap();

            CreateMap<Venda, CadastrarVendaViewModel>()
                .ForMember(map => map.Clientes, map => map.MapFrom(y => y.Cliente))
                .ForMember(map => map.FormasDePagamentos, map => map.MapFrom(y => y.FormaDePagamento))
                 .ForMember(map => map.Performance, map => map.MapFrom(y => y.Perfomance))
                 .ForMember(map => map.Veiculos, map => map.MapFrom(y => y.Veiculo))
                 .ReverseMap();

            CreateMap<CadastrarVendaViewModel, Veiculo>()
                .ReverseMap();

            CreateMap<CadastrarVendaViewModel, GDC_Veiculos>()
              .ReverseMap();

            CreateMap<CadastrarVendaViewModel, DetailsDeleteVendaViewModel>()
                 .ForMember(map => map.Cliente, map => map.MapFrom(y => y.Clientes))
                  .ForMember(map => map.FormaDePagamento, map => map.MapFrom(y => y.FormasDePagamentos))
                   .ForMember(map => map.Performance, map => map.MapFrom(y => y.Performance))
                    .ForMember(map => map.Veiculo, map => map.MapFrom(y => y.Veiculos))
                     .ForMember(map => map.Venda, map => map.MapFrom(y => y.Venda));

            CreateMap<DetailsDeleteVendaViewModel, CadastrarVendaViewModel>()
                .ForMember(map => map.Clientes, map => map.MapFrom(y => y.Cliente))
                 .ForMember(map => map.FormasDePagamentos, map => map.MapFrom(y => y.FormaDePagamento))
                  .ForMember(map => map.Performance, map => map.MapFrom(y => y.Performance))
                   .ForMember(map => map.Veiculos, map => map.MapFrom(y => y.Veiculo))
                    .ForMember(map => map.Venda, map => map.MapFrom(y => y.Venda));

            #endregion
        }
    }
}