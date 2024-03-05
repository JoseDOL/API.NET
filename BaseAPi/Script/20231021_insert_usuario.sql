IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = 'usercrud')
BEGIN
    CREATE LOGIN usercrud WITH PASSWORD = 'Jose124578'
    CREATE USER usercrud FOR LOGIN usercrud
	GRANT SELECT, INSERT, UPDATE, DELETE, EXEC TO usercrud
END
