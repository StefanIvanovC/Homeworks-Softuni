CREATE TABLE Directors 
(
	Id INT PRIMARY KEY,
	DirectorName VARCHAR(90) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors VALUES 
(1, 'Stefii1', 'dasdasd1'),
(2, 'Stefii2', 'dasdasd2'),
(3, 'Stefii3', 'dasdasd3'),
(4, 'Stefii4', 'dasdasd4'),
(5, 'Stefii5', 'dasdasd5')

CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName VARCHAR(90) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Genres VALUES
(1,'Tanq1', 'Tanq1'),
(2,'Tanq2', 'Tanq2'),
(3,'Tanq3', 'Tanq3'),
(4,'Tanq4', 'Tanq4'),
(5,'Tanq5', 'Tanq5')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(90) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories VALUES
(1,'HORROR1', 'HORROR1'),
(2,'HORROR2', 'HORROR2'),
(3,'HORROR3', 'HORROR3'),
(4,'HORROR4', 'HORROR4'),
(5,'HORROR5', 'HORROR5')

CREATE TABLE Movies 
(
	Id INT PRIMARY KEY,
	Title VARCHAR(90),
	DirectorId INT,
	CopyrightYear DATETIME,
	 [Length] INT,
	 GenreId INT,
	 CategoryId VARCHAR(30),
	 Rating INT,
	 Notes VARCHAR(MAX)
)

INSERT INTO Movies VALUES 
(1, 'Harry Poter', 1, 12/01/2021, 10, 5, 'Ujas1', 2, 'skuchen1'),
(2, 'Harry Poter3', 1, 15/01/2021, 11, 4, 'Ujasi2', 3, 'skuchen2'),
(3, 'Harry Poter2', 1, 18/01/2021, 12, 3, 'Ujas3', 4, 'skuchen3'),
(4, 'Harry Poter4', 1, 17/01/2021, 13, 2, 'Ujasi4', 5, 'skuchen4'),
(5, 'Harry Poter5', 1, 16/01/2021, 14, 1, 'Ujasi5', 6, 'skuchen5')