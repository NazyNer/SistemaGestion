using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Proveedor
{
    [Key]
    public int Id_proveedores { get; set; }
    public string? Saldo { get; set; }
    public string? Web { get; set; }
    public virtual Usuario? Usuario { get; set; }
}