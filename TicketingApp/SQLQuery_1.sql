CREATE TABLE Users( 
    UserId INTEGER NOT NULL IDENTITY,
	Email varchar(100) NOT NULL,
	Password varchar(100) DEFAULT NULL,
	Permission varchar(50) NOT NULL DEFAULT 'User',
	PRIMARY KEY (UserId)
 );

 DROP TABLE Users;

 DROP TABLE Tickets;

SELECT * FROM Users;

INSERT INTO Users (Email, Password, Permission)
VALUES (
	'Admin@admin.com',
	'Admin',
    'Admin'
);

 CREATE TABLE Tickets(
	TicketId INT NOT NULL IDENTITY,
	Status varchar(255) DEFAULT 'Pending',
	Amount FLOAT NOT NULL,
	Description varchar(1000) NOT NULL,
    UserId INT NOT NULL,
	PRIMARY KEY(TicketId),
	FOREIGN KEY(UserId) REFERENCES Users(UserId)
);

SELECT * FROM Tickets;

SELECT IDENT_CURRENT('Tickets');

INSERT INTO Tickets (Status, Amount, Description, UserId) VALUES ('Pending', 100, 'lol', 2);

SELECT @@IDENTITY FROM Tickets;

INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES (
	'Pending',
	1000000.00,
	'Example',
	1
);

INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 1000000.00, 'Example', 2);

INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 1.00, 'Example', 2);
INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 20.00, 'Example', 2);
INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 100.00, 'Example', 2);
INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 1000.00, 'Example', 2);
INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES ('Pending', 50.00, 'Example', 2);

SELECT * FROM Tickets;

SELECT * FROM Tickets WHERE Status = 'Pending';

SELECT * FROM Tickets WHERE UserId = 1;

SELECT * FROM Users;

ALTER TABLE Users ADD UNIQUE (Email);

DELETE FROM Users WHERE UserId = 1;

DELETE FROM Tickets WHERE UserId = 1;

SELECT * FROM Users WHERE UserId = 1;

SELECT * FROM Users WHERE Email = 'Admin@admin.com' AND Password = 'Admin';

UPDATE Users SET Permission = 'Manager' WHERE Email = 'Admin@admin.com';