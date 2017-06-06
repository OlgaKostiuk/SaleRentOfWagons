CREATE DATABASE RentOfWagons2;

USE RentOfWagons2;

CREATE TABLE Wagons (
	WagonID int NOT NULL IDENTITY PRIMARY KEY,
	Number int NOT NULL UNIQUE
	);
CREATE TABLE Contractors (
	ContractorID int NOT NULL IDENTITY PRIMARY KEY,
	Name nvarchar(255) NOT NULL
	);
CREATE TABLE Departments (
	DepartmentID int NOT NULL IDENTITY PRIMARY KEY,
	Name nvarchar(255) NOT NULL,
	ContractorID int UNIQUE,
	CONSTRAINT FK_ConractorDepartment FOREIGN KEY (ContractorID)
	REFERENCES Contractors(ContractorID)
	);
CREATE TABLE OperationTypes (
	TypeID int NOT NULL IDENTITY PRIMARY KEY,
	Name nvarchar(255) NOT NULL,
	Attribute int NOT NULL
	);
CREATE TABLE Operations (
	OperationID int NOT NULL IDENTITY PRIMARY KEY,
	WagonID int NOT NULL,
	TypeID int NOT NULL,
	StartDate date NOT NULL,
	EndDate date,
	TransmitterContractorID int,
	TransmitterDepartmentID int,
	ReceiverContractorID int NOT NULL,
	ReceiverDepartmentID int,
	ContractNumber nvarchar(10) NOT NULL UNIQUE,
	ContractDate date NOT NULL,
	RentLevel int NOT NULL,
	CONSTRAINT FK_WagonOperation FOREIGN KEY (WagonID)
	REFERENCES Wagons(WagonID),
	CONSTRAINT FK_TypeOperation FOREIGN KEY (TypeID)
	REFERENCES OperationTypes(TypeID),
	CONSTRAINT FK_TransmitterContractorOperation FOREIGN KEY (TransmitterContractorID)
	REFERENCES Contractors(ContractorID),
	CONSTRAINT FK_TransmitterDepartmentOperation FOREIGN KEY (TransmitterDepartmentID)
	REFERENCES Departments(DepartmentID),
	CONSTRAINT FK_ReceiverContractorOperation FOREIGN KEY (ReceiverContractorID)
	REFERENCES Contractors(ContractorID),
	CONSTRAINT FK_ReceiverDepartmentOperation FOREIGN KEY (ReceiverDepartmentID)
	REFERENCES Departments(DepartmentID)
	);

INSERT INTO Wagons(Number)
VALUES(93683316);

INSERT Wagons(Number) VALUES
(52462991),
(51712909),
(65017147),
(58089822),
(53777690),
(50280320),
(00003159),
(00000013),
(52597945);

INSERT Contractors(Name) VALUES
('Наша фирма(департамент) 1'),
('Арендодатель 1'),
('Арендодатель 2'),
('Продавец 1'),
('Продавец 2'),
('Наша фирма(департамент) 2'),
('Наша фирма(департамент) 3');

INSERT OperationTypes VALUES
('Краткосрочная аренда: до 1 года', 1),
('Среднесрочная аренда: 1-5 лет', 1),
('Долгосрочная аренда: 5-49 лет', 1),
('Купля', 0);

INSERT Departments VALUES
('Наша фирма 1', 1),
('Наша фирма 2', 6),
('Наша фирма 3', 7);