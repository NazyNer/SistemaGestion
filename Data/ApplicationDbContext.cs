using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaGestion.Models;
using SistemaGestion.Models.usos_articulos;

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
}
