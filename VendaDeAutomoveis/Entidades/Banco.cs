﻿using System;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Banco : Entity
    {
        public CorBanco CorBanco { get; set; }

        public ModeloBanco Modelo { get; set; }

        public bool Multimidia { get; set; }
    
        public Guid IdPerformance { get; set; }
    }
}