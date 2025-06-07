using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models.usos_articulos;

public class articulos_medida_unidades
{
    [Key]
    public int id_articulos_medida_unidades { get; set; }
    public int id_articulo { get; set; }
    public int id_medida_unidades { get; set; }
}