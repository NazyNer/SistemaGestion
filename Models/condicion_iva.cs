using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Condicion_iva
{
    [Key]
    public int Id_condicion_iva { get; set; }
    public string? Condicion { get; set; }
    public int? Iva { get; set; }
}