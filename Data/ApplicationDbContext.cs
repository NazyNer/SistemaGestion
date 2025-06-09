using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGestion.Models;

namespace SistemaGestion.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Localidad> Localidades { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Vendedor> vendedores { get; set; }
}
