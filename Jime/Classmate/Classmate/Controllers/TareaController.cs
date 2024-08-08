using Classmate.Models;
using Classmate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classmate.Controllers
{
    public class TareaController : Controller
    {
        private Service service;

        public TareaController()
        {
            service = new Service();
        }

        // GET: TareaController
        public ActionResult Index(string? tema, string? search)
        {
            ViewBag.tema = service.mostrarTemaClass();
            var model = new List<Tarea>();
            if (!string.IsNullOrEmpty(tema))
            {
                model = service.buscarTemasTareas(tema);
            }
            else
            {
                model = service.mostrarTarea();
            }

            if (!string.IsNullOrEmpty(search)) //Searchbar
            {
                model = model.Where(t => t.Nombre.Contains(search)).ToList();
            }
            return View(model);
        }

        // GET: TareaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TareaController/Create
        public ActionResult Create(DateTime fecha)
        {
            ViewBag.temas = service.mostrarTemaClass();
            var tarea = new Tarea { Fecha = fecha };
            return View(tarea);
        }

        // POST: TareaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarea tarea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarTareaNueva(tarea);
                    return RedirectToAction("DetallesDia", "Calendario", new { fecha = tarea.Fecha.ToString("yyyy-MM-dd") });
                }
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            ViewBag.temas = service.mostrarTemaClass();
            return View(tarea);
        }

        // GET: TareaController/Edit/5
        public ActionResult Edit(int id, string fechaOriginal)
        {
            try
            {
                var tarea = service.buscarTarea(id);
                ViewBag.temas = service.mostrarTemaClass();
                ViewBag.FechaOriginal = fechaOriginal;
                return View(tarea);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: TareaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarea tarea, string fechaOriginal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarTarea(tarea);
                    return RedirectToAction("DetallesDia", "Calendario", new { fecha = fechaOriginal });
                }
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            ViewBag.temas = service.mostrarTemaClass();
            ViewBag.FechaOriginal = fechaOriginal;
            return View(tarea);
        }

        // GET: TareaController/Delete/5
        public ActionResult Delete(int id, string fechaOriginal)
        {
            try
            {
                var tarea = service.buscarTarea(id);
                ViewBag.FechaOriginal = fechaOriginal;
                return View(tarea);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: TareaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string fechaOriginal)
        {
            try
            {
                var tarea = service.buscarTarea(id);
                service.eliminarTarea(tarea);
                return RedirectToAction("DetallesDia", "Calendario", new { fecha = fechaOriginal });
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            return View();
        }

        // GET: TareaController/BuscarPorTema
        public ActionResult BuscarPorTema(string tema)
        {
            var tareasPorTema = service.mostrarTarea().Where(t => t.Tema == tema).ToList();
            return View("Index", tareasPorTema);
        }

        public ActionResult MarcarComoPendiente(int id)
        {
            try
            {
                service.MarcarTareaComoPendiente(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }





    }
}