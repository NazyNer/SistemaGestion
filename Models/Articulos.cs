using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Articulo
{
    [Key]
    public int id_articulo { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public int id_marca { get; set; }
    public int codigo_provincial { get; set; }
    public decimal Costo { get; set; }

    public virtual Marca Marca { get; set; } = null!;
}