IF OBJECT_ID('dbo.spi_persona', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spi_persona
END
GO

CREATE PROCEDURE dbo.spi_persona
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
		IF NOT EXISTS (SELECT 1 FROM persona WHERE dpi = @dpi)
		BEGIN
			INSERT INTO persona(dpi,Nombre,Apellido,Profesion,FechaNacimiento,Edad,Telefono)
			VALUES (@dpi,@Nombre,@Apellido,@Profesion,@FechaNacimiento,@Edad,@Telefono)
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