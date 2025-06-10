using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Marca
{
    [Key]
    public int Id_marca { get; set; }
    public string? Nombre { get; set; }
    public bool Eliminado { get; set; }
}