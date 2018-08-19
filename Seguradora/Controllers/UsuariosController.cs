using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguradora.Util;
using Seguradora.Models;


namespace Seguradora.Controllers
{
    public class UsuariosController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (Session["idUsuarioLogado"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Email,Senha")] usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var v = db.usuario.Where(a => a.Email.Equals(usuario.Email)).FirstOrDefault();

                if (v != null)
                {
                    ViewBag.Message = $"O e-mail {usuario.Email} já está em uso.";
                }
                else
                {
                    usuario.Senha = Util.Util.GerarHashMd5(usuario.Senha);
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    Session["idUsuarioLogado"] = usuario.IdUsuario.ToString();
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(usuario);
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
