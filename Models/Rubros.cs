using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Rubro
{
    [Key]
    public int Id_rubro{ get; set; }
    public string? Nombre { get; set; }
}