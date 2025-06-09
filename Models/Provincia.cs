using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Provincia
{
    [Key]
    public int Id_provincia { get; set; }
    public string? ProvinciaNombre { get; set; }
    public virtual Pais? Pais { get; set; } 
    public virtual ICollection<Localidad>? Localidads { get; set; }
}