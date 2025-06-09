using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Articulo
{
    [Key]
    public int Id_articulo { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public int Id_marca { get; set; }
    [Required]
    public int Id_rubro { get; set; }
    [Required]
    public int Codigo_provincial { get; set; }
    [Required]
    public decimal Costo { get; set; }
    public DateTime Fecha_compra { get; set; }
    public int Stock_minimo { get; set; } = 0;
    public int Stock { get; set; } = 0;
    public string Ubicacion { get; set; } = "S/U";
    public DateTime Fecha_modificacion { get; set; }
    public int Porcentaje_ganancia { get; set; } = 0;
    public virtual Marca Marca { get; set; } = null!;
    public virtual Rubro Rubro { get; set; } = null!;
}