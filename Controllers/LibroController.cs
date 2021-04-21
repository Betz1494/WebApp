using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LibroController : Controller
    {
        private readonly ConexionBD _conexion;

        public LibroController(ConexionBD conexion)
        {
            _conexion = conexion;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> libros = _conexion.Libro;

            return View(libros);
        }

        //http Get
        public IActionResult CrearLibro()
        {
            return View();
        }

        //HTTP POST
        [HttpPost]
        [ValidateAntiForgeryToken] //Previene enviar datos desde bots
        public IActionResult CrearLibro(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _conexion.Libro.Add(libro);
                _conexion.SaveChanges();

                TempData["mensaje"] = "El Libro se ha Agregado";
                return RedirectToAction("Index");
            }
            return View();
        }

        //http Get
        public IActionResult EditarLibro(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                var libro = _conexion.Libro.Find(Id);

                if(libro == null)
                {
                    return NotFound();
                }

                return View(libro);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Previene enviar datos desde bots
        public IActionResult ActualizarLibro(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _conexion.Libro.Update(libro);
                _conexion.SaveChanges();

                TempData["mensaje"] = "El Libro se ha Actualizado Correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        //http Get
        public IActionResult EliminarLibro(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                var libro = _conexion.Libro.Find(Id);

                if (libro == null)
                {
                    return NotFound();
                }

                return View(libro);
            }

        }

        public IActionResult DeleteLibro(int? Id)
        {
            var libro = _conexion.Libro.Find(Id);
            if(libro == null)
            {
                return NotFound();
            }

            _conexion.Libro.Remove(libro);
            _conexion.SaveChanges();

            TempData["mensaje"] = "El Libro se ha Eliminado Correctamente";
            return RedirectToAction("Index");

        }

    }
}
