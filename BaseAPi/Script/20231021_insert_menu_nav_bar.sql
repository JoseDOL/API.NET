DECLARE @txt_nombre VARCHAR(50) = 'CREAR REGISTRO',
		@id_nav INT = 0 

SELECT @id_nav = ISNULL(MAX(id_nav), 0) + 1 FROM menu_nav_bar

IF NOT EXISTS (SELECT 1 FROM menu_nav_bar WHERE txt_nombre = @txt_nombre)
BEGIN
	INSERT INTO dbo.menu_nav_bar (id_nav, txt_nombre, controller, accion, icono)
    VALUES (@id_nav, @txt_nombre, 'Home', 'addData', 'bi bi-database-add')
END

SELECT @id_nav = ISNULL(MAX(id_nav), 0) + 1 FROM menu_nav_bar
SET @txt_nombre = 'LEER REGISTRO'

IF NOT EXISTS (SELECT 1 FROM menu_nav_bar WHERE txt_nombre = @txt_nombre)
BEGIN
	INSERT INTO dbo.menu_nav_bar (id_nav, txt_nombre, controller, accion, icono)
    VALUES (@id_nav, @txt_nombre, 'Home', 'readData', 'bi bi-database-check')
END

SELECT @id_nav = ISNULL(MAX(id_nav), 0) + 1 FROM menu_nav_bar
SET @txt_nombre = 'MODIFICAR REGISTRO'

IF NOT EXISTS (SELECT 1 FROM menu_nav_bar WHERE txt_nombre = @txt_nombre)
BEGIN
	INSERT INTO dbo.menu_nav_bar (id_nav, txt_nombre, controller, accion, icono)
    VALUES (@id_nav, @txt_nombre, 'Home', 'updateData', 'bi bi-database-up')
END

SELECT @id_nav = ISNULL(MAX(id_nav), 0) + 1 FROM menu_nav_bar
SET @txt_nombre = 'ELIMINAR REGISTRO'

IF NOT EXISTS (SELECT 1 FROM menu_nav_bar WHERE txt_nombre = @txt_nombre)
BEGIN
	INSERT INTO dbo.menu_nav_bar (id_nav, txt_nombre, controller, accion, icono)
    VALUES (@id_nav, @txt_nombre, 'Home', 'deleteData', 'bi bi-database-x')
END

GO




