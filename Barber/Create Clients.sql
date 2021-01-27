DROP TABLE Clients

CREATE TABLE Clients
(
	id INT PRIMARY KEY NOT NULL IDENTITY,
	name NVARCHAR (64) NOT NULL CHECK (LEN(REPLACE(name, ' ', '')) > 0),
	surname NVARCHAR (64) NOT NULL CHECK (LEN(REPLACE(surname, ' ', '')) > 0),
	email NVARCHAR (64) CHECK (email LIKE '%_@__%.__%'),
	phone NVARCHAR (20) CHECK( phone LIKE '%[^0-9-]%'),
	genderID INT
)