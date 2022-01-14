using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models;
using System.Linq;


namespace NetCoreMVC.Controllers;

public class AlumnoController : Controller
{
    private EscuelaContext _context;

    public AlumnoController(EscuelaContext context){
        _context=context;
    }
    public IActionResult MultiAlumno()
    {
        
        // var listaAlumnos =new List<Alumno>(){
        //     new Alumno{Nombre="Juan Perez",UniqueId = Guid.NewGuid().ToString()},
        //     new Alumno{Nombre="Daniel Romero",UniqueId = Guid.NewGuid().ToString()},
        //     new Alumno{Nombre="Elmer Curio",UniqueId = Guid.NewGuid().ToString()},
        //     new Alumno{Nombre="Elsa Pato",UniqueId = Guid.NewGuid().ToString()},
        //     new Alumno{Nombre="Susana Oria",UniqueId = Guid.NewGuid().ToString()}
        //};

        ViewBag.Fecha=DateTime.Now;

        return View("MultiAlumno",_context.Alumnos.ToList());
    }

    public IActionResult Index()
    {
        // var alumno = new Alumno();

        // alumno.Id = Guid.NewGuid().ToString();
        // alumno.Nombre = "Juan Perez";

        // ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha=DateTime.Now;

        return View(_context.Alumnos.FirstOrDefault());
    }

    [Route("AlumnoController/Index")]
    [Route("AlumnoController/Index/{asignaturaId}")]
    public IActionResult Index(string id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            var alumno = from alum in _context.Asignaturas where alum.Id == id select alum;
            return View(alumno.SingleOrDefault());
        }
        else
        {
            return View("MultiAsignatura", _context.Asignaturas.ToList());
        }


    }



    
}
