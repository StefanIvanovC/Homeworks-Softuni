USE SoftUni

SELECT TOP (1) AVG(Salary) AS AvarageSelary
	FROM Employees AS e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	GROUP BY e.DepartmentID 
	ORDER BY AvarageSelary ASC