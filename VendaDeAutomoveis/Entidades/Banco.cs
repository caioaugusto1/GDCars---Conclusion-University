using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class Banco : Entity
    {
        public CorBanco CorBanco { get; set; }

        public Modelo Modelo { get; set; }

        public bool Multimidia { get; set; }
    }

    public enum CorBanco
    {
        [Display(Name = "Branco")]
        Branco = 'B',
        [Display(Name = "Caramelo")]
        Caramelo = 'C',
        [Display(Name = "Cinza")]
        Cinza = 'I',
        [Display(Name = "Preto")]
        Preta = 'P'
    }

    public enum Modelo
    {
        [Display(Name = "Couro")]
        Couro = 'C',
        [Display(Name = "Pano")]
        Pano = 'P'
    }
}