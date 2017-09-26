﻿using System;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Roda : Entity
    {
        public string Modelo { get; set; }

        public CorRoda Cor { get; set; }

        public int Aro { get; set; }
        
        public double Valor { get; set; }

        public Guid IdCliente { get; set; }
    }
}