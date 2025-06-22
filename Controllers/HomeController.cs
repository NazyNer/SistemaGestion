using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
namespace SistemaGestion.Controllers;

public class HomeController : Controller
{
    private readonly IRoleInitializerService _roleInitializerService;
    private readonly IAdminCreateService _adminCreateService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IRoleInitializerService roleInitializerService, IAdminCreateService adminCreateService)
    {
        _logger = logger;
        _roleInitializerService = roleInitializerService;
        _adminCreateService = adminCreateService;
    }

    public async Task<IActionResult> Index()
    {
        var Roles = await _roleInitializerService.InicializarRolesAsync();
        if (Roles != null)
        {
            Console.WriteLine("Cargando Vista...");
        }
        await _adminCreateService.InitializarAdminAsync();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { Requestid = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
