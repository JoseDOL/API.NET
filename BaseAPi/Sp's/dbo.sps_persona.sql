IF OBJECT_ID('dbo.sps_persona', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.sps_persona
END
GO

CREATE PROCEDURE dbo.sps_persona
	@dpi VARCHAR(50),
	@opcion INT
AS
BEGIN
	IF (@opcion = 0)
	BEGIN
		IF EXISTS (SELECT 1 FROM persona WHERE dpi = @dpi) 
		BEGIN
			SELECT -1
		END
		ELSE
		BEGIN
			SELECT 0
		END
	END
	ELSE
	BEGIN
		SELECT
			dpi,
			Nombre,
			Apellido,
			Profesion,
			FechaNacimiento,
			Edad,
			Telefono
		FROM persona WHERE dpi = @dpi
	END
	
END
GO