IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'menu_nav_bar')
BEGIN
	CREATE TABLE dbo.menu_nav_bar
	(
		id_nav INT NOT NULL,
		txt_nombre VARCHAR(250),
		controller VARCHAR(250),
		accion VARCHAR(250),
		icono VARCHAR(250)
	)
END
GO