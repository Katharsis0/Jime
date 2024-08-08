using System;
using System.Linq;
using System.Collections.Generic;
using Classmate.Services;
using Classmate.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classmate.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly Service _service;

        public CalendarioController(Service service)
        {
            _service = service;
        }

        public IActionResult Index(DateTime? fecha)
        {
            if (!fecha.HasValue)
            {
                fecha = DateTime.Today;
            }

            var viewModel = new CalendarioViewModel
            {
                FechaActual = new DateTime(fecha.Value.Year, fecha.Value.Month, 1),
                Eventos = ObtenerEventosDelMes(fecha.Value)
            };

            return View(viewModel);
        }

        private List<EventoCalendario> ObtenerEventosDelMes(DateTime fecha)
        {
            var primerDiaDelMes = new DateTime(fecha.Year, fecha.Month, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            var tareas = _service.Tarea
                .Where(t => t.Fecha >= primerDiaDelMes && t.Fecha <= ultimoDiaDelMes)
                .Select(t => new EventoCalendario
                {
                    Fecha = t.Fecha,
                    Titulo = t.Nombre,
                    Tipo = "Tarea",
                    Id = t.Id
                }).ToList();

            var notas = _service.Nota
                .Where(n => n.Fecha >= primerDiaDelMes && n.Fecha <= ultimoDiaDelMes)
                .Select(n => new EventoCalendario
                {
                    Fecha = n.Fecha,
                    Titulo = n.Nombre,
                    Tipo = "Nota",
                    Id = n.Id
                }).ToList();

            return tareas.Concat(notas).ToList();
        }

        public IActionResult DetallesDia(DateTime fecha)
        {
            var viewModel = new DetallesDiaViewModel
            {
                Fecha = fecha,
                Tareas = ObtenerTareasDelDia(fecha),
                Notas = ObtenerNotasDelDia(fecha)
            };

            return View(viewModel);
        }

        private List<Tarea> ObtenerTareasDelDia(DateTime fecha)
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fechaInicio.AddDays(1).AddTicks(-1);

            return _service.Tarea
                .Where(t => t.Fecha >= fechaInicio && t.Fecha < fechaFin)
                .ToList();
        }

        private List<Nota> ObtenerNotasDelDia(DateTime fecha)
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fechaInicio.AddDays(1).AddTicks(-1);

            return _service.Nota
                .Where(n => n.Fecha >= fechaInicio && n.Fecha < fechaFin)
                .ToList();
        }
    }
}