using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Marca
{
    [Key]
    public int id_marca{ get; set; }
    public string? Nombre { get; set; }
}