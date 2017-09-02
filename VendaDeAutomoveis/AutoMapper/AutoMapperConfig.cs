using AutoMapper;

namespace VendaDeAutomoveis.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ConfigMappingProfile>();
            });
        }
    }
}