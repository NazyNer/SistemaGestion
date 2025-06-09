using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Tipo_pago
{
    [Key]
    public int Id_tipo_pago{ get; set; }
    public string? Nombre { get; set; }
}