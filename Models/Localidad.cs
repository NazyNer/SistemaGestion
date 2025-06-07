using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Localidad
{
    [Key]
    public int LocalidadId { get; set; }
    public string LocalidadNo { get; set; }
    public string Direccion { get; set; }
    public string Codigo_postal { get; set; }
    public virtual Provincia? Provincia{ get; set; }
}