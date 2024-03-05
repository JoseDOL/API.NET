IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'crudpro')
BEGIN
	CREATE DATABASE crudpro
END
GO