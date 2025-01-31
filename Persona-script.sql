CREATE DATABASE ExamenGS
GO
USE ExamenGS;
GO
CREATE TABLE persona (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombres VARCHAR(100) NOT NULL,
    apellido_paterno VARCHAR(100) NOT NULL,
    apellido_materno VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    nivel_educativo VARCHAR(50) NOT NULL,
    numero_celular VARCHAR(15) NOT NULL,
    estatus BIT NOT NULL,
	eliminado BIT NOT NULL DEFAULT(0),
);
GO
CREATE OR ALTER PROCEDURE sp_insertar_persona
    @nombres VARCHAR(100),
    @apellido_paterno VARCHAR(100),
    @apellido_materno VARCHAR(100),
    @fecha_nacimiento DATE,
    @nivel_educativo VARCHAR(50),
    @numero_celular VARCHAR(15),
    @estatus BIT
AS
BEGIN
    INSERT INTO persona (nombres, apellido_paterno, apellido_materno, fecha_nacimiento, nivel_educativo, numero_celular, estatus)
    VALUES (@nombres, @apellido_paterno, @apellido_materno, @fecha_nacimiento, @nivel_educativo, @numero_celular, @estatus);
END
GO
CREATE OR ALTER PROCEDURE sp_obtener_personas
AS
BEGIN
    SELECT id Id, nombres Nombres, apellido_paterno ApellidoPaterno, apellido_materno ApellidoMaterno, fecha_nacimiento FechaNacimiento, nivel_educativo NivelEducativo, numero_celular NumeroCelular, estatus Estatus
    FROM persona
	WHERE eliminado = 0
	ORDER BY fecha_nacimiento;
END
GO
CREATE OR ALTER PROCEDURE sp_actualizar_persona
    @id INT,
    @nombres VARCHAR(100),
    @apellido_paterno VARCHAR(100),
    @apellido_materno VARCHAR(100),
    @fecha_nacimiento DATE,
    @nivel_educativo VARCHAR(50),
    @numero_celular VARCHAR(15),
    @estatus BIT
AS
BEGIN
    UPDATE persona
    SET 
        nombres = @nombres,
        apellido_paterno = @apellido_paterno,
        apellido_materno = @apellido_materno,
        fecha_nacimiento = @fecha_nacimiento,
        nivel_educativo = @nivel_educativo,
        numero_celular = @numero_celular,
        estatus = @estatus
    WHERE id = @id;
END
GO
CREATE OR ALTER PROCEDURE sp_eliminar_persona
    @id INT
AS
BEGIN
	UPDATE persona
    SET 
        eliminado = 1
    WHERE id = @id;
END
GO
CREATE OR ALTER PROCEDURE sp_obtener_persona_por_id
	@id INT
AS
BEGIN
    SELECT id Id, nombres Nombres, apellido_paterno ApellidoPaterno, apellido_materno ApellidoMaterno, fecha_nacimiento FechaNacimiento, nivel_educativo NivelEducativo, numero_celular NumeroCelular, estatus Estatus
    FROM persona
	WHERE id = @id;
END