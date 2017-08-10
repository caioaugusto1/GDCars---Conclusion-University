using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Entidades
{
    public class EntityUpload
    {
        //[Required(ErrorMessage = "Informe o Modelo do Produto")]
        public Guid IdUpload { get; set; }

        public virtual Upload Upload { get; set; }
    }
}