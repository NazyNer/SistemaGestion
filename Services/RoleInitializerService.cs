
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using System.Runtime.CompilerServices;

public interface IRoleInitializerService
{
    Task<JsonResult> InicializarRolesAsync();
    
}
public class RoleInitializerService : IRoleInitializerService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public RoleInitializerService(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _roleManager = roleManager;
        _context = context;
    }
    public async Task<JsonResult> InicializarRolesAsync()
    {
        Console.WriteLine("Ingresando roles...");
        var Roles_necesarios = new[] { "Administrador", "Cliente", "Proveedor", "Vendedor" };

        Console.WriteLine("Verificando roles existentes en base de datos...");
        var Roles_existentes = await _context.Roles.Where(r => Roles_necesarios.Contains(r.Name)).Select(r => r.Name).ToListAsync();

        Console.WriteLine("Verificando roles...");
        var Roles_faltantes = Roles_necesarios.Except(Roles_existentes).ToList();
        if (Roles_faltantes.Count > 0)
        {
            foreach (var rol in Roles_faltantes)
            {
                await _roleManager.CreateAsync(new IdentityRole(rol));
            }
            
        }
        else
        {
            Console.WriteLine("No hay roles para crear");
        }
        
        Console.WriteLine("Roles finalizado👍");
        return new JsonResult(Roles_necesarios);
    }
}