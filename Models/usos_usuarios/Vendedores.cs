using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models.usos_usuarios;

public class Vendedor
{
    [Key]
    public int Id_vendedores { get; set; }
    public string? Sueldo { get; set; }
    public virtual Usuario? Usuario { get; set; }
}