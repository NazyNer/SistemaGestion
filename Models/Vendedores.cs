using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Vendedor
{
    [Key]
    public int Id_vendedores { get; set; }
    public string? Sueldo { get; set; }
    public virtual Usuario? Usuario { get; set; }
}