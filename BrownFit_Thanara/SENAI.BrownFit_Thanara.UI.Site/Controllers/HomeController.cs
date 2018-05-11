using SENAI.BrownFit_Thanara.Data.Repositorios;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuPrincipal()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {

            if (ModelState.IsValid)
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();

                var usuarioAutenticado = usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioAutenticado != null)
                {
                    var permissoes = usuarioRepository.
                        RetornarPermissoes(usuarioAutenticado.UsuarioId);

                    FormsAuthentication.SetAuthCookie(usuarioAutenticado.Email, false);
                    var authTicket = new FormsAuthenticationTicket(1, usuarioAutenticado.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, permissoes);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    return RedirectToAction("Index", "UsuarioPerfils");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}