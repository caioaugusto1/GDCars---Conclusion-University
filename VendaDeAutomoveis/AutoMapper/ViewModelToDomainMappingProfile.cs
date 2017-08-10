using AutoMapper;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;

namespace VendaDeAutomoveis.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected void Configure()
        {
            CreateMap<Cliente, GDC_Clientes>();
            CreateMap<Endereco, GDC_Enderecos>();
        }
    }
}