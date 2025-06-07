using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models.usos_articulos;

public class articulo_tipo_pago
{
    [Key]
    public int id_articulos_tipos_pago { get; set; }
    public int id_articulo { get; set; }
    public int id_tipo_pago { get; set; }
    public decimal Precio { get; set; }    
}