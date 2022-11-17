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

INSERT INTO Tickets(Status, Amount, Description, UserId)
VALUES (
	'Pending',
	1000000.00,
	'Example',
	1
);

SELECT * FROM Tickets;

SELECT * FROM Tickets WHERE Status = 'Pending';

SELECT * FROM Tickets WHERE UserId = 1;

SELECT * FROM Users;

SELECT * FROM Users WHERE UserId = 1;

SELECT * FROM Users WHERE Email = 'Admin@admin.com' AND Password = 'Admin';