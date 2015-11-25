using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Authorize]
    public class TipoController : Controller
    {
        TallerEntities db = new TallerEntities();
        // GET: Tipo
        public ActionResult Index()
        {


            var data = db.Tipo;
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Tipo());
        }

        [HttpPost]
        public ActionResult Alta(Tipo model)
        {
            if (ModelState.IsValid)
            {
                db.Tipo.Add(model);
                db.SaveChanges();
                return View(new Tipo());
            }
            return View(model);
        }

        public ActionResult Modificar(int id)
        {
            var data = db.Tipo.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Modificar(Tipo model)
        {
            if (ModelState.IsValid)
            {
                var data = db.Tipo.FirstOrDefault(o => o.idTipo == model.idTipo);
                data.nombre = model.nombre;
                data.descripcion = model.descripcion;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            var data = db.Tipo.Find(id);
            if (data.Vehiculo.Any())
                db.Vehiculo.RemoveRange(data.Vehiculo);
            db.Tipo.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}