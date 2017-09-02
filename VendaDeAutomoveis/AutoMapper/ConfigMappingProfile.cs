using AutoMapper;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.AutoMapper
{
    public class ConfigMappingProfile : Profile
    {
        protected void Configure()
        {
            CreateMap<GDC_Clientes, Cliente>().ReverseMap();
            CreateMap<GDC_Enderecos, Endereco>().ReverseMap();
        }
    }
}