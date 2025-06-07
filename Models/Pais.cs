using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Pais
{
    [Key]
    public int PaisId { get; set; }
    public string Nombre { get; set; }
    public virtual ICollection <Provincia>? Provincia { get; set; }
}