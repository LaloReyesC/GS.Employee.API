using Dapper;
using GS.Employee.API.Models;
using System.Data;

namespace GS.Employee.API.Business;

public class PersonaDataAccess(IDbConnection dbConnection) : IDisposable, IPersonaDataAccess
{
    private readonly IDbConnection _dbConnection = dbConnection;

    // Método para obtener todas las personas
    public List<Persona> ObtenerPersonas()
    {
        return _dbConnection.Query<Persona>("sp_obtener_personas", commandType: System.Data.CommandType.StoredProcedure).ToList();
    }

    // Método para insertar una nueva persona
    public void InsertarPersona(Persona persona)
    {
        var parameters = new
        {
            nombres = persona.Nombres,
            apellido_paterno = persona.ApellidoPaterno,
            apellido_materno = persona.ApellidoMaterno,
            fecha_nacimiento = persona.FechaNacimiento,
            nivel_educativo = persona.NivelEducativo,
            numero_celular = persona.NumeroCelular,
            estatus = persona.Estatus
        };

        _dbConnection.Execute("sp_insertar_persona", parameters, commandType: System.Data.CommandType.StoredProcedure);
    }

    // Método para actualizar una persona
    public bool ActualizarPersona(Persona persona)
    {
        var parameters = new
        {
            id = persona.Id,
            nombres = persona.Nombres,
            apellido_paterno = persona.ApellidoPaterno,
            apellido_materno = persona.ApellidoMaterno,
            fecha_nacimiento = persona.FechaNacimiento,
            nivel_educativo = persona.NivelEducativo,
            numero_celular = persona.NumeroCelular,
            estatus = persona.Estatus
        };

        int affectedRosw = _dbConnection.Execute("sp_actualizar_persona", parameters, commandType: System.Data.CommandType.StoredProcedure);

        return affectedRosw > 0;
    }

    // Método para eliminar una persona
    public bool EliminarPersona(int id)
    {
        var parameters = new { id };
        int affectedRosw = _dbConnection.Execute("sp_eliminar_persona", parameters, commandType: System.Data.CommandType.StoredProcedure);

        return affectedRosw > 0;
    }

    public void Dispose()
    {
        _dbConnection.Close();
        _dbConnection.Dispose();
    }
}