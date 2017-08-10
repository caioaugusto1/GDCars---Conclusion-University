using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class Roda : Entity
    {
        public string Modelo { get; set; }

        public int Aro { get; set; }

        public CorRoda Cor { get; set; }
    }

    public enum CorRoda
    {
        [Display(Name = "Cinza")]
        Cinza = 'C',
        [Display(Name = "Cromada")]
        Cromada = 'O',
        [Display(Name = "Fosco")]
        Fosco = 'F',
        [Display(Name = "Preta")]
        Preta = 'P',
    }
}