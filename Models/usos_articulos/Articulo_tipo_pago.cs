using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models.usos_articulos;

public class Articulo_tipo_pago
{
    [Key]
    public int Id_articulos_tipos_pago { get; set; }
    public int Id_articulo { get; set; }
    public int Id_tipo_pago { get; set; }
    public decimal Precio { get; set; }    
}