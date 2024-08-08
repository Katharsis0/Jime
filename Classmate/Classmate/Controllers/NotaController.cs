using Classmate.Models;
using Classmate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Classmate.Controllers
{
    public class NotaController : Controller
    {
        private Service service;

        public NotaController()
        {
            service = new Service();
        }

        // GET: NotaController
        public ActionResult Index(string? tema, string? search)
        {
            ViewBag.tema = service.mostrarTemaClass();
            var model = new List<Nota>();
            if (!string.IsNullOrEmpty(tema))
            {
                model = service.buscarTemasNotas(tema);
            }
            else
            {
                model = service.mostrarNota();
            }

            if (!string.IsNullOrEmpty(search)) //Searchbar
            {
                model = model.Where(t => t.Nombre.Contains(search)).ToList();
            }
            return View(model);
        }

        

        // GET: NotaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotaController/Create
        public ActionResult Create(DateTime fecha)
        {
            ViewBag.temas = service.mostrarTemaClass();
            var nota = new Nota { Fecha = fecha };
            return View(nota);
        }

        // POST: NotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nota nota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarNotaNueva(nota);
                    return RedirectToAction("DetallesDia", "Calendario", new { fecha = nota.Fecha.ToString("yyyy-MM-dd") });
                }
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            ViewBag.temas = service.mostrarTemaClass();
            return View(nota);
        }

        // GET: NotaController/Edit/5
        public ActionResult Edit(int id, string fechaOriginal)
        {
            try
            {
                var nota = service.buscarNota(id);
                ViewBag.temas = service.mostrarTemaClass();
                ViewBag.FechaOriginal = fechaOriginal;
                return View(nota);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: NotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nota nota, string fechaOriginal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarNota(nota);
                    return RedirectToAction("DetallesDia", "Calendario", new { fecha = fechaOriginal });
                }
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            ViewBag.temas = service.mostrarTemaClass();
            ViewBag.FechaOriginal = fechaOriginal;
            return View(nota);
        }

        // GET: NotaController/Delete/5
        public ActionResult Delete(int id, string fechaOriginal)
        {
            try
            {
                var nota = service.buscarNota(id);
                ViewBag.FechaOriginal = fechaOriginal;
                return View(nota);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: NotaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string fechaOriginal)
        {
            try
            {
                var nota = service.buscarNota(id);
                service.eliminarNota(nota);
                return RedirectToAction("DetallesDia", "Calendario", new { fecha = fechaOriginal });
            }
            catch
            {
                // Manejar la excepción apropiadamente
            }
            return View();
        }



        public ActionResult MarcarComoPendiente(int id)
        {
            try
            {
                service.MarcarNotaComoPendiente(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }



    }
}