using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class FormaDePagamento : Entity
    {
        public string Modelo { get; set; }

        public TipoCliente Tipo_Cliente { get; set; }
    }  
}