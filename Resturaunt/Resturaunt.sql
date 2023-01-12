
-- Data Source=DESKTOP-C46S740\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False; --

-- DROP DATABASE Restaurants;
CREATE DATABASE Restaurants;

USE Restaurants;

DROP TABLE Grade;
DROP TABLE Score;
DROP TABLE Menu;
DROP TABLE RestConnCuisine;
DROP TABLE Cuisine;
DROP TABLE Restaurant;


CREATE TABLE Restaurant(
	Id INT NOT NULL IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	Street_addr VARCHAR(255) NOT NULL,
	City VARCHAR(255) NOT NULL,
	State VARCHAR(255) NOT NULL,
	PRIMARY KEY(Id)
);


CREATE TABLE Cuisine(
	Id int NOT NULL IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	PRIMARY KEY(Id)
);


CREATE TABLE RestConnCuisine(
	Id INT NOT NULL IDENTITY(1,1),
	RestID INT NOT NULL,
	CuisineID INT NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(RestID) REFERENCES Restaurant(Id),
	FOREIGN KEY(CuisineID) REFERENCES Cuisine(Id)
);

CREATE TABLE Menu(
	Id INT NOT NULL IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	Price decimal(18, 2) NOT NULL,
	RestId INT NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(RestId) REFERENCES Restaurant(Id)
);

CREATE TABLE Score(
	Id INT NOT NULL IDENTITY(1,1),
	Score INT NOT NULL,
	date_submit DATE NOT NULL,
	RestId INT NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(RestId) REFERENCES Restaurant(Id)
);

CREATE TABLE Grade(
	Id INT NOT NULL IDENTITY(1,1),
	Grade INT NOT NULL,
	RestId INT NOT NULL,
	PRIMARY KEY(Id),
	FOREIGN KEY(RestId) REFERENCES Restaurant(Id)
);

SELECT * FROM Restaurant;
SELECT * FROM Menu;
SELECT * FROM Score;
SELECT * FROM Grade;


-- Insert into tables --

INSERT INTO Restaurant(Name, Street_addr, City, State) VALUES
	('Mcdonalds', '123 Fast Food Way', 'St. Louis', 'Missouri');

INSERT INTO Cuisine(Name) VALUES 
	('American');

INSERT INTO RestConnCuisine(RestID, CuisineID) Values 
	(1,1);

INSERT INTO Menu(Name, Price, RestId) VALUES
	('Hamburger', 1.99, 1);

INSERT INTO Score(Score, date_submit, RestId) VALUES
	(4, '2023-12-01', 1);

INSERT INTO Grade(Grade, RestId) VALUES
	(95, 1);


