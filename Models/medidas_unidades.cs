using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Medida_unidades
{
    [Key]
    public int Id_medida_unidades { get; set; }
    public string? Nombre { get; set; }
    public int? Cantidad { get; set; }
}