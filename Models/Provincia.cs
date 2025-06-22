using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Provincia
{
    [Key]
    public int Id_provincia { get; set; }
    public string? Provincia_nombre { get; set; }
    public virtual Pais? Pais { get; set; } 
    public virtual ICollection<Localidad>? Localidades { get; set; }
}