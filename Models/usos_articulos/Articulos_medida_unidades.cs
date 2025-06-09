using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models.usos_articulos;

public class Articulos_medida_unidades
{
    [Key]
    public int Id_articulos_medida_unidades { get; set; }
    public int Id_articulo { get; set; }
    public int Id_medida_unidades { get; set; }
}