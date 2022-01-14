using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVC.Models;

namespace NetCoreMVC.Controllers;

public class EscuelaController : Controller
{

    private EscuelaContext _context;

    public EscuelaController(EscuelaContext context){
        _context=context;
    }
    public IActionResult Index()
    {
        var escuela =  _context.Escuelas.FirstOrDefault();
        ViewBag.CosaDinamica="La Monja";
        return View(escuela);

        /* 
        //escuela.AñoDeCreación=2005;
        // escuela.Id=Guid.NewGuid().ToString();
        // escuela.Nombre="Lider del Norte";
        // escuela.Ciudad="Lima";
        // escuela.Pais="Perú";
        // escuela.Dirección="Av Javier Prado Este 1018";
        // escuela.TipoEscuela=TiposEscuela.Secundaria;
        */

    }

}