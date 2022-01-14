using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models;


namespace NetCoreMVC.Controllers;

public class AsignaturaController : Controller
{

    private EscuelaContext _context;

    public AsignaturaController(EscuelaContext context)
    {
        _context = context;
    }
    public IActionResult MultiAsignatura()
    {
        // var listaAsignaturas =new List<Asignatura>(){
        //     new Asignatura{Nombre="Matemáticas",Id = Guid.NewGuid().ToString()},
        //     new Asignatura{Nombre="Castellano",Id = Guid.NewGuid().ToString()},
        //     new Asignatura{Nombre="Ciencias Naturales",Id = Guid.NewGuid().ToString()},
        //     new Asignatura{Nombre="Educacion Fisica",Id = Guid.NewGuid().ToString()},
        //     new Asignatura{Nombre="Programacion",Id = Guid.NewGuid().ToString()}

        // };

        ViewBag.Fecha = DateTime.Now;

        return View("MultiAsignatura", _context.Asignaturas.ToList());
    }

    // public IActionResult Index()
    // {
    //     // var asignatura = new Asignatura();

    //     // asignatura.Id = Guid.NewGuid().ToString();
    //     // asignatura.Nombre = "Programacion";

    //     // ViewBag.CosaDinamica = "La Monja";
    //     // ViewBag.Fecha=DateTime.Now;

    //     return View(_context.Asignaturas.FirstOrDefault());
    // }
    [Route("AsignaturaController/Index")]
    [Route("AsignaturaController/Index/{asignaturaId}")]
    public IActionResult Index(string asignaturaId)
    {
        if (!string.IsNullOrWhiteSpace(asignaturaId))
        {
            var asignatura = from asig in _context.Asignaturas where asig.Id == asignaturaId select asig;
            return View(asignatura.SingleOrDefault());
        }
        else
        {
            return View("MultiAsignatura", _context.Asignaturas.ToList());
        }


    }
}
