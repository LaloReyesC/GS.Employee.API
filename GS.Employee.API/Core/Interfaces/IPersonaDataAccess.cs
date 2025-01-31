namespace GS.Employee.API.Core.Interfaces;

public interface IPersonaDataAccess : IDisposable
{
    bool ActualizarPersona(Persona persona);

    bool EliminarPersona(int id);

    void InsertarPersona(Persona persona);

    List<Persona> ObtenerPersonas();
}