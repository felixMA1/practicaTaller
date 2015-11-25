using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica2.Models;

namespace Practica2.Controllers
{

    [Authorize]
    public class VehiculoController : Controller
    {
        TallerEntities db = new TallerEntities();
        // GET: Vehiculo
        public ActionResult Index(int id)
        {
            ViewBag.idTipo = id;
            return View(db.Vehiculo.Where(o => o.idTipo == id));
        }

        [OutputCache(Duration = 0, VaryByParam = "*")]
        public ActionResult Buscar(String busqueda, int id, String filtro)
        {
            IQueryable<Vehiculo> data;
            if (busqueda.Equals(""))
            {
                data = db.Vehiculo.Where(o => o.idTipo == id);
            }
            else
            {
                if (filtro.Equals("Marca"))
                    data = db.Vehiculo.Where(o => o.marca.Contains(busqueda) && o.idTipo == id);
                else if (filtro.Equals("Matricula"))
                    data = db.Vehiculo.Where(o => o.matricula.Contains(busqueda) && o.idTipo == id);
                else
                {
                    data = null;
                }
            }


            return PartialView("_listadoVehiculo", data);
        }

        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {
            db.Vehiculo.Add(model);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Json(model);
        }
    }
}