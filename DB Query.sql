CREATE DATABASE DB_CustomersManagement

CREATE TABLE Customers
(
	CustID INT IDENTITY(101,1) PRIMARY KEY NOT NULL,
	CustFirstName VARCHAR(50) NOT NULL,
	CustLastName VARCHAR(50) NOT NULL,
	CustPhone VARCHAR(15) NOT NULL
)

CREATE TABLE Neighborhoods
(
	NghbID INT IDENTITY(201,1) PRIMARY KEY NOT NULL,
	NghbName VARCHAR(40) NOT NULL
)

CREATE TABLE Addresses
(
	AddrsID INT IDENTITY(301,1) PRIMARY KEY NOT NULL,
	CustID INT CONSTRAINT FK_Cust FOREIGN KEY(CustID) REFERENCES Customers(CustID),
	NghbID INT CONSTRAINT FK_CustNghb FOREIGN KEY(NghbID) REFERENCES Neighborhoods(NghbID),
	AddrsStreet1 VARCHAR(40) NOT NULL,
	AddrsStreet2 VARCHAR(40),
	AddrsCountry VARCHAR(40) NOT NULL,
)

INSERT INTO Neighborhoods VALUES('Pantoja')
INSERT INTO Neighborhoods VALUES('Los Alcarrizos')
INSERT INTO Neighborhoods VALUES('Arroyo Hondo')
INSERT INTO Neighborhoods VALUES('Ensanche Julieta')
INSERT INTO Neighborhoods VALUES('Piantini')
INSERT INTO Neighborhoods VALUES('Naco')
INSERT INTO Neighborhoods VALUES('Los Mina')
INSERT INTO Neighborhoods VALUES('Viejo Arroyo Hondo')