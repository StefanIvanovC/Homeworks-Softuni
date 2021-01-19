CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(30),
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories VALUES
(1,'Van',1,2,3,4),
(2,'Sedan',2,3,1,5),
(3,'Combi',3,2,3,4)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY,
	PlateNumber VARCHAR(10),
	Manufacturer VARCHAR(10),
	Model VARCHAR(10),
	CarYear DATETIME,
	CategoryId INT,
	Doors INT,
	Picture VARCHAR(100),
	Condition VARCHAR(10),
	Available VARCHAR(10)
)

INSERT INTO Cars VALUES
(1, 'st1234sf', 'BMW', 'S1', 02/02/2001, 1, 4, 'dasff23rasdsde', 'new', 'YES'),
(2, 'st6666sf', 'Tita', 'Vag', 02/02/2005, 2, 4, 'dasff23rasdasddsde', 'new', 'YES'),
(3, 'st3553sf', 'Jaguar', 'x-type', 02/02/2006, 3, 4, 'dadassff23rasdsde', 'old', 'no')

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY,
	FirstNAme VARCHAR(30),
	Title VARCHAR(30),
	Notes VARCHAR(MAX),
)

INSERT INTO Employees VALUES
(1, 'Stefi', 'President', 'Mnogo umen'),
(2, 'Kalina', 'TeamLEad', 'Nategachka'),
(3, 'Tanq', 'Chistach', 'umen')

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber VARCHAR(10),
	FullName VARCHAR(10),
	[Address] VARCHAR(30),
	City VARCHAR(10),
	ZIPCode INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES 
(1,'hh1112ax', 'Stefi S', 'Stara Zagora', 'Plowdiv', 6000, 'vzima'),
(2,'hh4242as', 'Stefi T', 'Jeleznik', 'Sofia', 5000, 'ne vzima'),
(3,'ha2222xx', 'Stefi P', 'Stara Zagora', 'Plowdiv', 3300, 'Nqma pari')

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY,
	EmployeeId INT,
	CustomerId INT,
	CarId INT,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus VARCHAR(10),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1, 2, 2, 3, 4, 5, 6, 7, 05/05/2007, 05/06/2002, 1,2,3,'Kupi', 'Ne stava'),
(2, 2, 3, 4, 5, 5, 5, 5, 05/05/2007, 05/06/2002, 1,2,3,'Kupi', 'Ne stava'),
(3, 2, 3, 4, 5, 5, 6, 7, 05/05/2007, 05/06/2002, 1,2,3,'Kupi', 'Ne stava')
						 





