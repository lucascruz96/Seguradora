using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguradora.Models;

namespace Seguradora.Controllers
{
    public class SegurosController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

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

        public ActionResult Listar()
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            return View(db.seguro.ToList());
        }

        public ActionResult Details(long? id)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            seguro seguro = db.seguro.Find(id);

            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        public ActionResult Create()
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeguro,CpfCnpjCliente,TipoSeguro,Objeto")] seguro seguro)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            if (ModelState.IsValid)
            {
                db.seguro.Add(seguro);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(seguro);
        }

        public ActionResult Edit(long? id)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            seguro seguro = db.seguro.Find(id);

            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeguro,CpfCnpjCliente,TipoSeguro,Objeto")] seguro seguro)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            if (ModelState.IsValid)
            {
                db.Entry(seguro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seguro);
        }

        public ActionResult Delete(long? id)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            seguro seguro = db.seguro.Find(id);

            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            if (Session["idUsuarioLogado"] == null)
                return RedirectToAction("Login", "Home");

            seguro seguro = db.seguro.Find(id);
            db.seguro.Remove(seguro);
            db.SaveChanges();
            return RedirectToAction("Index");
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
