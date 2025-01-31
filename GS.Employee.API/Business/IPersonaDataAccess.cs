using GS.Employee.API.Models;

namespace GS.Employee.API.Business
{
    public interface IPersonaDataAccess : IDisposable
    {
        bool ActualizarPersona(Persona persona);
        bool EliminarPersona(int id);
        void InsertarPersona(Persona persona);
        List<Persona> ObtenerPersonas();
    }
}