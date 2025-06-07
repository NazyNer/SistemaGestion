using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Models;

public class Clientes
{
    [Key]
    public int Id_clientes { get; set; }
    public string? Contacto { get; set; }
    public string? Rubro { get; set; }
    public string? Limite_cta { get; set; }
    public string? Saldo { get; set; }
    public virtual Usuario? Usuario{ get; set; }
}