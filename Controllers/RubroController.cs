using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SistemaGestion.Data;
using SistemaGestion.Models;
using SistemaGestion.Models.usos_articulos;
namespace SistemaGestion.Controllers;

public class RubroController : Controller
{
    private readonly ILogger<RubroController> _logger;
    private readonly ApplicationDbContext _context;
    public RubroController(ILogger<RubroController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var Rubro = _context.Rubros.OrderBy(r => r.Nombre).ToList();
        return View();
    }
    public JsonResult BuscarRubro(int Id_rubro)
    {
        var buscar = _context.Rubros.ToList();
        if (Id_rubro > 0)
        {
            buscar = buscar.Where(r => r.Id_rubro == Id_rubro).ToList();
        }
        return Json(buscar);
    }
    public JsonResult GuardarRubro(int Id_rubro, string Nombre)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(Nombre))
        {
            if (Id_rubro == 0)
            {
                var rubroExist = _context.Rubros.FirstOrDefault(r => r.Nombre == Nombre);
                if (rubroExist == null)
                {
                    var nuevo_rubro = new Rubro
                    {
                        Nombre = Nombre,
                    };
                    _context.Rubros.Add(nuevo_rubro);
                    _context.SaveChanges();
                    result = true;
                }
            }
            else
            {
                var rubroExist = _context.Rubros.FirstOrDefault(r => r.Nombre == Nombre && Id_rubro != Id_rubro);
                if (rubroExist == null)
                {
                    var editar_rubro = _context.Rubros.Find(Id_rubro);
                    if (editar_rubro != null)
                    {
                        editar_rubro.Nombre = Nombre;
                        _context.SaveChanges();
                        result = true;
                    }
                }
            }
        }
        return Json(result);
    }
    public JsonResult EliminarRubro(int Id_rubro, int Eliminado)
    {
        int result = 0;
        var rubro = _context.Rubros.Find(Id_rubro);
        if (rubro != null)
        {
            if (Eliminado == 0)
            {
                rubro.Eliminado = false;
                _context.SaveChanges();
            }
            else if (Eliminado == 1)
            {
                rubro.Eliminado = true;
                _context.Remove(rubro);
                _context.SaveChanges();
            }
        }
        result = 1;
        return Json(result);
    }
}