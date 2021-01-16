--CREATE DATABASE Hotel

--USE Hotel

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50),
	Notes VARCHAR(MAX),
)

INSERT INTO Employees (Id, FirstName,LastName,Title, Notes) VALUES 
( 1, 'Stefan', 'Ivanov','Unemployeed', Null),
( 2, 'Stefan2', 'Ivanov2','Unemployeed2', 'Random Note'),
( 3, 'Stefan3', 'Ivanov3','Unemployeed3', Null)

CREATE TABLE Customers 
(
  AccountNumber INT PRIMARY KEY, 
  FirstName VARCHAR(90) NOT NULL,
  LastName VARCHAR(90) NOT NULL,
  PhoneNumber CHAR(10) NOT NULL,
  EmergencyName VARCHAR(90) NOT NULL,
  EmergencyNumber CHAR(10) NOT NULL,
  Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES 
(120, 'Sedefcho', 'Ivanov', '87428342', 'Sedef', '83241228', NULL),
(121, 'Sedefc2ho', 'Ivanov1', '734283442', 'Sedef', '82241228', NULL),
(123, 'Sedefc3ho', 'Ivanov2', '844238342', 'Sedef', '32431228', NULL)

CREATE TABLE RoomStatus
(
   RoomStatus VARCHAR(20) NOT NULL,
   Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Free', NULL),
('Not free', NULL),
('Cleaning', NULL)

CREATE TABLE RoomTypes 
(
   RoomType VARCHAR(20) NOT NULL,
   Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes  VALUES
('Apartmant', NULL),
('Bedroom', NULL ),
('Kitchen', NULL )

CREATE TABLE BedTypes 
(
   BedType VARCHAR(20),
   Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Triple', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR (20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(7, 'Apartment', 'Single', 10, 'Free', NULL),
(4, 'Bedroom', 'Triple', 10, 'Not free', NULL),
(5, 'Kitchen', 'Double', 10, 'Cleaning', NULL)

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2),
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes VARCHAR(MAX)
)


INSERT INTO Payments VALUES
(1,1,GETDATE(), 120, 5/5/2012, 5/8/2012, 3, 450.23, NULL, NULL, 450.23, NULL),
(2,2,GETDATE(), 121, 6/6/2013, 9/9/2014, 30, 460.23, NULL, NULL, 460.23, NULL),
(3,3,GETDATE(), 123, 7/7/2014, 8/8/2015, 40, 470.23, NULL, NULL, 470.23, NULL)

CREATE TABLE Occupancies
(
--(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	Id INT PRIMARY KEY,
	EmployeeId INT,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, 120, GETDATE(), 120, 120, 0, 0, NULL),
(2, 121, GETDATE(), 121, 121, 0, 0, NULL),
(3, 123, GETDATE(), 123, 123, 0, 0, NULL)
