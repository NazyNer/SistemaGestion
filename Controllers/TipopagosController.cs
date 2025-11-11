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

public class TipoPagosController : Controller
{
    private readonly ILogger<TipoPagosController> _logger;
    private readonly ApplicationDbContext _context;
    public TipoPagosController(ILogger<TipoPagosController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        var tipo = _context.Tipos_Pago.OrderBy(t => t.Nombre);
        return View();
    }
    public JsonResult BuscarTipo(int Id_tipo_pago)
    {
        var buscar = _context.Tipos_Pago.ToList();
        if (Id_tipo_pago > 0)
        {
            buscar = buscar.Where(t => t.Id_tipo_pago == Id_tipo_pago).ToList();
        }
        return Json(buscar);
    }
    public JsonResult GuardarTipo(int Id_tipo_pago, string Nombre)
    {
        bool result = false;
        if (!string.IsNullOrEmpty(Nombre))
        {
            if (Id_tipo_pago == 0)
            {
                var TipoExist = _context.Tipos_Pago.FirstOrDefault(t => t.Nombre == Nombre);
                if (TipoExist == null)
                {
                    var nuevo_tipo = new Tipo_pago
                    {
                        Nombre = Nombre
                    };
                    _context.Tipos_Pago.Add(nuevo_tipo);
                    _context.SaveChanges();
                    result = true;
                }
            }
        }
        return Json(result);
    }
    public JsonResult EliminarTipo(int Id_tipo_pago, int Eliminado)
    {
        int result = 0;
        var tipo = _context.Tipos_Pago.Find(Id_tipo_pago);
        if (tipo != null)
        {
            if (Eliminado == 0)
            {
                tipo.Eliminado = false;
                _context.SaveChanges();
            }
            else if (Eliminado == 1)
            {
                tipo.Eliminado = true;
                _context.Remove(tipo);
                _context.SaveChanges();
            }
        }
        result = 1;
        return Json(result);
    }
}