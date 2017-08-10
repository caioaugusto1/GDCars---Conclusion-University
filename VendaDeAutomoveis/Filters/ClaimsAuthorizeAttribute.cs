using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace VendaDeAutomoveis.Filters
{
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;

        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //verifica se o usuário tem permissão da minha claim

            return true;

            //var identity = (ClaimsIdentity)httpContext.User.Identity;

            //var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            //return claim != null && claim.Value.Contains(_claimValue);
        }
    }
}