using AutoMapper;
using System;
using System.Web.Mvc;
using VendaDeAutomoveis.Entidades;
using VendaDeAutomoveis.Filters;
using VendaDeAutomoveis.Repository;
using VendaDeAutomoveis.Repository.ConnectionContext.Context;
using VendaDeAutomoveis.Services;

namespace VendaDeAutomoveis.Controllers
{
    //ModuloCliente (Claims/Permissões) - AD, ED, LT, VI, EX

    [RoutePrefix("acesso-ao-sistema")]
    public class LoginController : Controller
    {
        //private ContextGDCars db = new ContextGDCars();
        private LoginRepository loginRepository;
        public LoginController(LoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string email, string senha)
        {
            if (ModelState.IsValid)
            {
                var senhaCripto = Criptografia.CriptografaMd5(senha);
                
                var validarAcesso = Mapper.Map<GDC_Logins, Login>(loginRepository.AutenticarAcesso(email, senhaCripto));

                if (validarAcesso == null)
                {
                    ModelState.AddModelError("login.Invalido", "Usuário ou senha Inválido, tente novamente!");
                }
                else
                {
                    SessionManager.UsuarioLogado = validarAcesso;
                    System.Web.Security.FormsAuthentication.SetAuthCookie(validarAcesso.Email, true);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Preencha o campo com login e senha!");
            }
           
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return View("Index");
        }

        [ClaimsAuthorize("CriarAcesso", "CA")]
        public ActionResult CriarAcesso()
        {
            return View();
        }

        [HttpPost]
        [Route("novo-acesso")]
        [ClaimsAuthorize("CriarAcesso", "CA")]
        [ValidateAntiForgeryToken]
        public ActionResult CriarAcesso([Bind(Include = "Id,Nome,SobreNome,Email,Senha,Confirmar_Senha")] Login login)
        {
            if (ModelState.IsValid)
            {
                var verificarExistenciaEmail = loginRepository.BuscarPorEmail(login.Email);

                if (verificarExistenciaEmail == null)
                {
                    ModelState.AddModelError("login.invalido", "Esse e-mail já está sendo utilizado, por favor, utilize um e-mail alternativo");
                    return View(login);
                }
                else
                {
                    var loginDomain = Mapper.Map<Login, GDC_Logins>(login);

                    loginDomain.Data_Inclusao = DateTime.Now;
                    loginDomain.Senha = Criptografia.CriptografaMd5(login.Senha);

                    //loginRepository.Adicionar(login);
                    loginRepository.Inserir(loginDomain);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(login);
            }
        }

        [ClaimsAuthorize("ListarAcesso", "LTA")]
        public ActionResult ListarAcesso()
        {
            var usuarios = loginRepository.ObterTodos();
            return View(usuarios);
        }
    }
}