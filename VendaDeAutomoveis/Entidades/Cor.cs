using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class Cor : Entity
    {
        public string HexaCor { get; set; }

        public CorExterna CorExterna { get; set; }
    }

    public enum CorExterna
    {
        [Display(Name = "Brilhante")]
        Brilhante = 'B',
        [Display(Name = "Fosco")]
        Fosco = 'F',
        [Display(Name = "Normal")]
        Normal = 'N'
    }
}