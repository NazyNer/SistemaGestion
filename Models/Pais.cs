using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Pais
{
    [Key]
    public int Id_pais { get; set; }
    public string? Nombre { get; set; }
    public virtual ICollection <Provincia>? Provincia { get; set; }
}