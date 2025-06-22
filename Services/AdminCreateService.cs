
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Data;
using System.Runtime.CompilerServices;
using SistemaGestion.Models;
public interface IAdminCreateService
{
    Task<JsonResult> InitializarAdminAsync();

}

public class AdminCreateService : IAdminCreateService
{
    private readonly IConfiguration _configuration;
    private readonly IRoleInitializerService _roleInitializerService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AdminCreateService(RoleManager<IdentityRole> roleManager, ApplicationDbContext context, UserManager<IdentityUser> userManager, IRoleInitializerService roleInitializerService, IConfiguration configuration)
    {
        _roleManager = roleManager;
        _context = context;
        _userManager = userManager;
        _roleInitializerService = roleInitializerService;
        _configuration = configuration;
    }

    public async Task<JsonResult> InitializarAdminAsync()
    {
        //Contraseña configurada anterior mente desde la terminal para no subir al repositorio las contraseñas default y tener mas seguridad
        var defaultPassword = _configuration["AdminSettings:DefaultPassword"];
        Console.WriteLine("Password desde configuración: " + defaultPassword);
        if (string.IsNullOrEmpty(defaultPassword))
        {
            return new JsonResult(new { success = false, message = "No se configuró la contraseña" });
        }


        var RolAdmin = _context.Roles.Where(r => r.Name == "Administrador").SingleOrDefault();
        if (RolAdmin == null)
        {
            var Roles = await _roleInitializerService.InicializarRolesAsync();
        }

        var usuario = await _userManager.FindByNameAsync("Administrador");

        if (usuario == null)
        {
            var user = new IdentityUser { UserName = "Administrador", Email = "admin@administrador.com" };
            var result = await _userManager.CreateAsync(user,defaultPassword);
            
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var resultConfirm = await _userManager.ConfirmEmailAsync(user, code);
                var NewUsuario = new Usuario
                {
                    Id_user = user.Id,
                    Id_rol = RolAdmin.Id,
                    Email = user.Email
                };
                _context.Usuarios.Add(NewUsuario);
                await _context.SaveChangesAsync();
                var usuarioAdmin = await _userManager.FindByNameAsync("Administrador");
                await _userManager.AddToRoleAsync(usuarioAdmin, RolAdmin.Name);
            }
            return new JsonResult(new { success = false, message = "Operación incompleta" });
        }
        return new JsonResult(new { success = true, message = "Operación completada" });
    }
}