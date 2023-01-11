CREATE DATABASE Whitboarding;

USE Whitboarding;

/* Create Table to populate with records */

CREATE TABLE Duplicates(
	Id INT NOT NULL IDENTITY(1,1),
	Fname VARCHAR(255) NOT NULL,
	Lname VARCHAR(255) NOT NULL,
	PRIMARY KEY(Id)
);

DROP TABLE Duplicates;

/* Populate the table with a few duplicate records*/

INSERT INTO Duplicates(Fname, Lname) VALUES 
	('John', 'Smith'),
	('John', 'Smith'),
	('Jane', 'Smith'),
	('Jane', 'Smith');

SELECT * FROM Duplicates;


/* Delete dulicate records from a table without using Rank() function. */

DELETE FROM Duplicates WHERE Id NOT IN ( SELECT Min(Id) FROM Duplicates GROUP BY Fname, Lname);

/* Delete dulicate records from a table using Rank() function. */

SELECT * FROM Duplicates;


DELETE DupRecs FROM (SELECT *, DupeRank = RANK() OVER(PARTITION BY Fname ORDER BY Id DESC) FROM Duplicates) AS DupRecs WHERE DupeRank > 1;