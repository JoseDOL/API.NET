IF OBJECT_ID('dbo.spd_persona', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.spd_persona
END
GO

CREATE PROCEDURE dbo.spd_persona
	@dpi VARCHAR(50)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM persona WHERE dpi = @dpi)
	BEGIN
		DELETE persona WHERE dpi = @dpi
		SELECT -1
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
GO