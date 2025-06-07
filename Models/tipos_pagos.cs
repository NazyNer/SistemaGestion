using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class tipo_pago
{
    [Key]
    public int id_tipo_pago{ get; set; }
    public string? Nombre { get; set; }
}