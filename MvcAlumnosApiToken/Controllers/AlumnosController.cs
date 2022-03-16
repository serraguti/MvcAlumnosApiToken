using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcAlumnosApiToken.Models;
using MvcAlumnosApiToken.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlumnosApiToken.Controllers
{
    public class AlumnosController : Controller
    {
        private ServiceTableAlumnos service;

        public AlumnosController(ServiceTableAlumnos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("TOKEN");
            if (token == null)
            {
                ViewData["MENSAJE"] = "Debe generar un TOKEN de acceso";
                return View();
            }
            else
            {
                List<Alumno> alumnos =
                    await this.service.GetAlumnosAsync(token);
                return View(alumnos);
            }
        }
    }
}
