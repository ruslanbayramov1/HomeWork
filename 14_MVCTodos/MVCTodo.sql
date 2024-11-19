CREATE DATABASE MVCTodo
USE MVCTodo

CREATE TABLE Todos
(
	Id int identity PRIMARY KEY,
	Title nvarchar(64) NOT NULL,
	[Description] nvarchar(255) NOT NULL,
	Deadline datetime NOT NULL,
	[Status] varchar(32) DEFAULT 'pending',
	IsDone bit DEFAULT 0
)

CREATE TABLE Teams
(
	Id int identity PRIMARY KEY,
	[Name] nvarchar(64) NOT NULL UNIQUE,
)

CREATE TABLE Roles
(
	Id int identity PRIMARY KEY,
	[Role] nvarchar(32) UNIQUE NOT NULL,
)

CREATE TABLE TeamTodo
(
	Id int identity PRIMARY KEY,
	TeamId int REFERENCES Teams(Id),
	TodoId int REFERENCES Todos(Id)
)

CREATE TABLE Employees
(
	Id int identity PRIMARY KEY,
	[Name] nvarchar(32) NOT NULL,
	Surname nvarchar(42) NOT NULL,
	Username nvarchar(32) UNIQUE NOT NULL,
	[Password] nvarchar(32) NOT NULL,
	TeamId int REFERENCES Teams(Id),
	RoleId int REFERENCES Roles(Id),
	HireDate datetime DEFAULT GETDATE(),
	Salary decimal(10, 2) DEFAULT 1200
)

CREATE TABLE Admins
(
	Id int identity PRIMARY KEY,
	Username nvarchar(32) UNIQUE NOT NULL,
	[Password] nvarchar(32) NOT NULL
)

ALTER TABLE Admins
ADD RoleId int

ALTER TABLE Admins
ADD FOREIGN KEY (RoleId) REFERENCES Roles(id)

INSERT INTO Roles(Role) VALUES 
('Admin'), ('Employee')

SELECT * FROM Admins

INSERT INTO Admins(Username, [Password]) VALUES
('jack.eo', 'jack123')

INSERT INTO Employees(Name, Surname, Username, [Password], HireDate, RoleId, TeamId) VALUES
('fred', 'froa', 'fredd01', 'fred123', '2024-11-05', 2, 1)

INSERT INTO Teams(Name) VALUES
('BK06'), ('BK01')

INSERT INTO Todos(Title, [Description], Deadline) VALUES
('MVC', 'Creating a task about MVC', '2024-11-20 12:00:00')

INSERT INTO TeamTodo(TeamId, TodoId) VALUES
(1, 4)

SELECT * FROM Teams
SELECT * FROM Todos
SELECT * FROM TeamTodo
INNER JOIN Todos ON TeamTodo.TodoId = Todos.Id
INNER JOIN Teams ON TeamTodo.TeamId = Teams.Id

SELECT * FROM Admins

-- TRIGGER AFTER TEAM TODO