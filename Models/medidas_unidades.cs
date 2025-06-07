using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class medida_unidades
{
    [Key]
    public int id_medida_unidades { get; set; }
    public string? Nombre { get; set; }
    public int? Cantidad { get; set; }
}