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

DELETE FROM Duplicates WHERE Id NOT IN ( SELECT MIN(Id) FROM Duplicates GROUP BY Fname, Lname);

/* Delete dulicate records from a table using Rank() function. */

SELECT * FROM Duplicates;


DELETE DupeRecs FROM (SELECT *, DupeRank = RANK() OVER(PARTITION BY Fname, Lname ORDER BY Id ASC) FROM Duplicates) AS DupeRecs WHERE DupeRank > 1;
SELECT * FROM Duplicates;