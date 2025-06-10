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

public class MarcaController : Controller
{
    private readonly ILogger<MarcaController> _logger;
    private readonly ApplicationDbContext _context;
    public MarcaController(ILogger<MarcaController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var marca = _context.Marcas.OrderBy(m => m.Nombre);
        return View();
    }
    public JsonResult BuscarMarca(int id_marca)
    {
        var buscar = _context.Marcas.ToList();
        if (id_marca > 0)
        {
            buscar = buscar.Where(m => m.Id_marca == id_marca).ToList();
        }
        return Json(buscar);
    }
    public JsonResult GuardarMarca(int id_marca, string Nombre)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(Nombre))
        {
            if (id_marca == 0)
            {
                var marcaExist = _context.Marcas.FirstOrDefault(m => m.Nombre == Nombre);
                if (marcaExist == null)
                {
                    var nueva_marca = new Marca
                    {
                        Nombre = Nombre,
                    };
                    _context.Marcas.Add(nueva_marca);
                    _context.SaveChanges();
                    result = true;
                }
            }
            else
            {
                var marcaExist = _context.Marcas.FirstOrDefault(m => m.Nombre == Nombre && id_marca != id_marca);
                if (marcaExist == null)
                {
                    var editar_marca = _context.Marcas.Find(id_marca);
                    if (editar_marca != null)
                    {
                        editar_marca.Nombre = Nombre;
                        _context.SaveChanges();
                        result = false;
                    }
                }
            }
        }
        return Json(result);
    }
    public JsonResult EliminarMarca(int Id_marca, int Eliminado)
    {
        int result = 0;
        var marca = _context.Marcas.Find(Id_marca);
        if (marca != null)
        {
            if (Eliminado == 0)
            {
                marca.Eliminado = false;
                _context.SaveChanges();
            }
            else if (Eliminado == 1)
            {
                marca.Eliminado = true;
                _context.Remove(marca);
                _context.SaveChanges();
            }
        }
        result = 1;
        return Json(result);
    }
}