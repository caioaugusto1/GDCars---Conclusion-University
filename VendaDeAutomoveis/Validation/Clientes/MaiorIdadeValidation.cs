using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Validation.Clientes
{
    public class MaiorIdadeValidation
    {
        public static bool Validar(DateTime dataNascimento)
        {
            return DateTime.Now.Year - dataNascimento.Year >= 21;
        }
    }
}