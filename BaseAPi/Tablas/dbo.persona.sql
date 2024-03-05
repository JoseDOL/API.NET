IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'persona')
BEGIN
    CREATE TABLE dbo.persona (
		dpi VARCHAR(20), 
		Nombre VARCHAR (50),
		Apellido VARCHAR (50),
		Profesion VARCHAR (50),
		FechaNacimiento SMALLDATETIME,
		Edad INT,
		Telefono VARCHAR (50)
	)
		
END
