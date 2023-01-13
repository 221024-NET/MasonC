CREATE DATABASE Students;
USE Students;

CREATE TABLE Student(
	Id INT NOT NULL IDENTITY(1,1),
	Fname VARCHAR(255) NOT NULL,
	Lname VARCHAR(255) NOT NULL,
	PRIMARY KEY(Id)
);

INSERT INTO Student(Fname, Lname) VALUES
	('John', 'Smith'),
	('Jane', 'Smith'),
	('John', 'Wick');

select * from Student where Fname like  'John%';
select * from Student where Lname like 'Smith%';