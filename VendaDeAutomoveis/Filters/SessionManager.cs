using VendaDeAutomoveis.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendaDeAutomoveis.Filters
{
    public class SessionManager
    {
        public static Login UsuarioLogado
        {
            set
            {

                HttpContext.Current.Session.Add("UsuarioLogado", value);
            }
            get
            {
                return (Login)HttpContext.Current.Session["UsuarioLogado"];
            }

        }

        public static bool IsAuthenticated
        {
            get
            {
                return ((Login)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}