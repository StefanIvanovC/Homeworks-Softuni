CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT FirstName, LastName
From Employees
WHERE DATEPART(YEAR,HireDate) > 2000