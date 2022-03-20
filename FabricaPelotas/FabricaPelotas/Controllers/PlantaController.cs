using FabricaPelotas.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FabricaPelotas.Controllers
{
    public class PlantaController : Controller
    {
        // GET: Planta
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            Planta p = new Planta();
            GestorPlanta gp = new GestorPlanta();
            ViewBag.cboFabrica = new SelectList(gp.cboFabrica(), "idFabrica", "nombreFabrica");
            ViewBag.cboColor = new SelectList(gp.cboColor(), "idColor", "nombreColor");
            return View(p);
        }
        [HttpPost]
        public ActionResult Agregar(Planta nuevaPlanta)
        {
            GestorPlanta gp = new GestorPlanta();
            gp.AltaPlanta(nuevaPlanta);
            ViewBag.cboFabrica = new SelectList(gp.cboFabrica(), "idFabrica", "nombreFabrica", nuevaPlanta.IdFabrica);
            ViewBag.cboColor = new SelectList(gp.cboColor(), "idColor", "nombreColor", nuevaPlanta.IdColor);
            return View("Index");
        }
        public ActionResult Eliminar()
        {
            GestorPlanta gp = new GestorPlanta();
            Planta p = new Planta();
            ViewBag.cboPlanta = new SelectList(gp.cboPlanta(), "idPlanta", "nombrePlanta");
            return View(p);
        }

        [HttpPost]
        public ActionResult Eliminar(Planta borrarPlanta)
        {
            GestorPlanta gp = new GestorPlanta();
            ViewBag.cboPlanta = new SelectList(gp.cboPlanta(), "idPlanta", "nombrePlanta", borrarPlanta.IdPlanta);
            gp.BajaPlanta(borrarPlanta);
            return View("Index");
        }
        public ActionResult Modificar()
        {
            Planta p = new Planta();
            GestorPlanta gp = new GestorPlanta();
            ViewBag.cboPlanta = new SelectList(gp.cboPlanta(), "idPlanta", "nombrePlanta");
            ViewBag.cboFabrica = new SelectList(gp.cboFabrica(), "idFabrica", "nombreFabrica");
            ViewBag.cboColor = new SelectList(gp.cboColor(), "idColor", "nombreColor");
            return View(p);
        }

        [HttpPost]
        public ActionResult Modificar(Planta cambiarPlanta)
        {
            GestorPlanta gp = new GestorPlanta();
            gp.ModificarPlanta(cambiarPlanta);
            ViewBag.cboPlanta = new SelectList(gp.cboPlanta(), "idPlanta", "nombrePlanta", cambiarPlanta.IdPlanta);
            ViewBag.cboFabrica = new SelectList(gp.cboFabrica(), "idFabrica", "nombreFabrica", cambiarPlanta.IdFabrica);
            ViewBag.cboColor = new SelectList(gp.cboColor(), "idColor", "nombreColor", cambiarPlanta.IdColor);
            return View("Index");
        }
        public ActionResult Listar()
        {
            GestorPlanta gp = new GestorPlanta();
            List<PlantaDto> lista = gp.Listar();
            return View(lista);
        }
    }
}