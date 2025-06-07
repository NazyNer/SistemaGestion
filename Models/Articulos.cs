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
    public DateTime fecha_compra { get; set; }
    public int stock_minimo { get; set; } = 0;
    public int Stock { get; set; } = 0;
    public string Ubicacion { get; set; } = "S/U";
    public DateTime fecha_modificacion { get; set; }
    public int porcentaje_ganancia { get; set; } = 0;
    public virtual Marca Marca { get; set; } = null!;
}