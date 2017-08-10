using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class Upload
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string NomeArquivo { get; set; }
    }
}