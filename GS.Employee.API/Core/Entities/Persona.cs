namespace GS.Employee.API.Core.Entities;

public class Persona
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string NivelEducativo { get; set; }
    public string NumeroCelular { get; set; }
    public bool Estatus { get; set; }
    public bool Eliminado { get; set; }
}