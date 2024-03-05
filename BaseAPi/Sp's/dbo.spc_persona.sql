IF OBJECT_ID('dbo.spc_persona', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spc_persona
END
GO

CREATE PROCEDURE dbo.spc_persona
AS
BEGIN
	SELECT
		dpi,
		Nombre,
		Apellido,
		Profesion,
		FechaNacimiento,
		Edad,
		Telefono
	FROM persona
END
GO