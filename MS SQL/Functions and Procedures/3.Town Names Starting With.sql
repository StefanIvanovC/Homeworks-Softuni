CREATE PROC usp_GetTownsStartingWith (@subName NVARCHAR(50))
AS 
SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @subName + '%'

	EXEC usp_GetTownsStartingWith 'b'