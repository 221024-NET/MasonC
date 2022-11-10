

# Plan to make a Database so that I can store the Users and passwords into a table of users.

# I will also make another table that will reference the users table by ID so 
# that I can have the tickets stored there.

# Use a text file to store connection string so that github doesn't have the connection string


CREATE TABLE Users( 
    UserId INTEGER NOT NULL IDENTITY,
	Email varchar(100) NOT NULL,
	Password varchar(100) DEFAULT NULL,
	PRIMARY KEY (UserId)
 );

SELECT * FROM Users;

INSERT INTO USERS (Email, Password)
VALUES (
	'Admin@admin.com',
	'Admin'
);

 CREATE TABLE Tickets(
	TicketId INT NOT NULL IDENTITY,
	Status varchar(255) DEFAULT 'Pending',
	Amount FLOAT NOT NULL,
	Description varchar(MAX) NOT NULL,
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

# Tables and information have been made and inserted respectively