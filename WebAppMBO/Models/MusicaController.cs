using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebAppMBO.Models
{
    public class MusicaController : Controller
    {
        private MusicaContext db = new MusicaContext();

        // GET: Musica
        public ActionResult Index()
        {
            return View(db.Musicas.ToList());
        }

        public ActionResult VerificarTitulo(string Titulo)
        {
            return Json(db.Musicas
                .All(m => m.Titulo.ToLower() != Titulo.ToLower())
                , JsonRequestBehavior.AllowGet);
        }



        // GET: Musica/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // GET: Musica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musica/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Categoria,TipoMidia,DataCadastro")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Musicas.Add(musica);
                db.SaveChanges();
                TempData["Mensagem"] = "Música cadastrada com sucesso!";
                return RedirectToAction("Index");
            }

            return View(musica);
        }

        // GET: Musica/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musica/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Categoria,TipoMidia,DataCadastro")] Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Música editada com sucesso!";
                return RedirectToAction("Index");
            }
            return View(musica);
        }

        // GET: Musica/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
            db.SaveChanges();
            TempData["Mensagem"] = "Música excluida com sucesso!";
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
