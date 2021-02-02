CREATE PROC usp_GetEmployeesFromTown (@nameOfTown NVARCHAR(50))
AS 
SELECT FirstName, LastName
	FROM Employees as e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID 
	WHERE t.Name = @nameOfTown

	EXEC usp_GetEmployeesFromTown 'Sofia'
	
