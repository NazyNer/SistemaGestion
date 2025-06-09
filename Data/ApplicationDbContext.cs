using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGestion.Models;
using SistemaGestion.Models.usos_articulos;
using SistemaGestion.Models.usos_usuarios;

namespace SistemaGestion.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Condicion_iva> Condiciones_Iva { get; set; }
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Rubro> Rubros { get; set; }
    public DbSet<Tipo_pago> Tipos_Pago { get; set; }
    public DbSet<Articulo_tipo_pago> Articulos_Tipos_Pago { get; set; }
    public DbSet<Articulos_medida_unidades> Articulos_medida_unidades { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Localidad> Localidades { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
}
