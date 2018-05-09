using SENAI.BrownFit_Thanara.Data.Repositorios;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(UsuarioViewModel usuario)
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