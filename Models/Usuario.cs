using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Usuario
{
    [Key]
    public int Id_usuario { get; set; }
    public string? Contraseña { get; set; }
    public string? Email { get; set; }
    public string? Cuit { get; set; }
    public string? Contacto { get; set; }
    public string? Direccion { get; set; }
    public string? Razon_social { get; set; }
    public string? Celular { get; set; }
    public string? Condicion_iva { get; set; }
    public virtual ICollection<Localidad>? Localidad { get; set; } 
    public virtual ICollection<Clientes>? Clientes { get; set;}
    public virtual ICollection<Proveedores>? Proveedores { get; set; }
    public virtual ICollection<Vendedores>? Vendedores { get; set; }
}