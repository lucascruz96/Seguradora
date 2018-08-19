using Seguradora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguradora.Controllers
{
    public class HomeController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        public ActionResult Index()
        {
            if (Session["idUsuarioLogado"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario u)
        {
            if (ModelState.IsValid)
            {
                string hashSenha = Util.Util.GerarHashMd5(u.Senha);
                var v = db.usuario.Where(a => a.Email.Equals(u.Email) && a.Senha.Equals(hashSenha)).FirstOrDefault();
                if (v != null)
                {
                    Session["idUsuarioLogado"] = v.IdUsuario.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Usuário não encontrado";
                }
            }

            return View(u);
        }

        public ActionResult Sair()
        {
            Session["idUsuarioLogado"] = null;
            return RedirectToAction("Login", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}