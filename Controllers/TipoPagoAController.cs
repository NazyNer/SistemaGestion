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

public class TipoPagoAController : Controller
{
    private readonly ILogger<TipoPagoAController> _logger;
    private readonly ApplicationDbContext _context;
    public TipoPagoAController(ILogger<TipoPagoAController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var tipo_pag_a = _context.Articulos_Tipos_Pago.OrderBy(a => a.Id_articulo);
        return View();
    }
    public JsonResult BuscarArt_TP(int Id_articulos_tipos_pago)
    {
        var buscar = _context.Articulos_Tipos_Pago.ToList();
        if (Id_articulos_tipos_pago > 0)
        {
            buscar = buscar.Where(a => a.Id_articulos_tipos_pago == Id_articulos_tipos_pago).ToList();
        }
        return Json(buscar);
    }
    public JsonResult GuardarArtTP(int Id_articulos_tipos_pago, int Id_articulo, int Id_tipo_pago, decimal Precio)
    {
        bool result = false;
        if (Id_articulos_tipos_pago > 0)
        {
            if (Id_tipo_pago == 0)
            {
                var tipo_pag_a = new Articulo_tipo_pago
                {
                    Id_articulo = Id_articulo,
                    Id_articulos_tipos_pago = Id_articulos_tipos_pago,
                    Id_tipo_pago = Id_tipo_pago,
                    Precio = Precio
                };
                _context.Articulos_Tipos_Pago.Add(tipo_pag_a);
                _context.SaveChanges();
                result = true;
            }
            else
            {
                var tipo_pag_a = _context.Articulos_Tipos_Pago.FirstOrDefault(a => a.Id_articulos_tipos_pago == Id_articulos_tipos_pago && a.Id_tipo_pago == Id_tipo_pago
                && a.Id_articulo == Id_articulo);
                if (tipo_pag_a == null)
                {
                    var editar_tipo = _context.Articulos_Tipos_Pago.Find(Id_articulos_tipos_pago);
                    if (editar_tipo == null)
                    {
                        editar_tipo.Precio = Precio;
                        _context.SaveChanges();
                        result = true;
                    }
                }
            }
        }
        return Json(result);
    }
}