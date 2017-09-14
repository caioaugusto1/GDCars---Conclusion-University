using System;

namespace VendaDeAutomoveis.Entidades
{
    public class Upload : Entity
    {
        public string NomeArquivo { get; set; }

        public DateTime Data_Inclusao { get; set; }
    }
}