using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class condicion_iva
{
    [Key]
    public int id_condicion_iva { get; set; }
    public string? Condicion { get; set; }
    public int? Iva { get; set; }
}