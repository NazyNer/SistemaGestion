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

public class ArticuloController : Controller
{
    private readonly ILogger<ArticuloController> _logger;
    private readonly ApplicationDbContext _context;
    public ArticuloController(ILogger<ArticuloController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var articulo = _context.Articulos.OrderBy(a => a.Rubro).ToList();
        return View();
    }
    public JsonResult BuscarArticulo(int Id_articulo)
    {
        var articulos = _context.Articulos.ToList();
        if (Id_articulo > 0)
        {
            articulos = articulos.Where(a => a.Id_articulo == Id_articulo).ToList();
        }
        return Json(articulos);
    }
    public JsonResult GuardarArticulo(int Id_articulo, string Descripcion, int Id_marca, int Id_rubro,
    int Codigo_provincial, string Ubicacion, decimal Costo, DateTime Fecha_compra, int Stock)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(Descripcion))
        {
            if (Id_articulo == 0)
            {
                //verificar si el articulo existe
                var articuloExist = _context.Articulos.FirstOrDefault(a => a.Descripcion == Descripcion);
                if (articuloExist == null)
                {
                    var artnuevo = new Articulo
                    {
                        Id_articulo = Id_articulo,
                        Descripcion = Descripcion,
                        Id_marca = Id_marca,
                        Id_rubro = Id_rubro,
                        Codigo_provincial = Codigo_provincial,
                        Ubicacion = Ubicacion,
                        Fecha_compra = Fecha_compra,
                        Costo = Costo,
                        Stock = Stock,
                    };
                    _context.Add(artnuevo);
                    _context.SaveChanges();
                    result = true;
                }
            }
        }
        return Json(result);
    }
    public JsonResult EliminarArticulo(int Id_articulo, int Eliminado)
    {
        int resultado = 0;
        var articulo = _context.Articulos.Find(Id_articulo);
        if (articulo != null)
        {
            if (Eliminado == 0)
            {
                articulo.Eliminado = false;
                _context.SaveChanges();
            }
            else
            {
                if (Eliminado == 1)
                {
                    articulo.Eliminado = true;
                    _context.Remove(articulo);
                    _context.SaveChanges();
                }
            }
        }
        resultado = 1;
        return Json(resultado);
    }
}