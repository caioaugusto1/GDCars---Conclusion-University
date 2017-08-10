using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;

namespace VendaDeAutomoveis.Filters
{
    public class AutorizacaoAcesso : AuthorizeAttribute
    {
        public static bool IsPermission
        {
            get
            {
                return ((Login)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}