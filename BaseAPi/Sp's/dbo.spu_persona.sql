IF OBJECT_ID('dbo.spu_persona', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spu_persona
END
GO

CREATE PROCEDURE dbo.spu_persona
		@dpi VARCHAR(20), 
		@Nombre VARCHAR (50),
		@Apellido VARCHAR (50),
		@Profesion VARCHAR (50),
		@FechaNacimiento SMALLDATETIME,
		@Edad INT,
		@Telefono VARCHAR (50)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM persona WHERE dpi = @dpi)
		BEGIN
			UPDATE persona
			SET Nombre = @Nombre
			,Apellido= @Apellido
			,Profesion= @Profesion
			,FechaNacimiento= @FechaNacimiento
			,Edad= @Edad
			,Telefono= @Telefono
			WHERE dpi = @dpi
			SELECT -1
		END
		ELSE
		BEGIN
			SELECT -2
		END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH

END
GO