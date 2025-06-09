namespace SistemaGestion.Models;

public class ErrorViewModel
{
    public string? Requestid { get; set; }

    public bool Showrequestid => !string.IsNullOrEmpty(Requestid);
}
