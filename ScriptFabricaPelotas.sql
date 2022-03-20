CREATE DATABASE FabricaPelotas

USE FabricaPelotas

CREATE TABLE Fabrica
(
idFabrica INT IDENTITY (1,1) NOT NULL,
nombreFabrica VARCHAR(50),
CONSTRAINT PK_Fabrica PRIMARY KEY (idFabrica)
)

CREATE TABLE Color
(
idColor INT IDENTITY (1,1) NOT NULL,
nombreColor VARCHAR(50),
CONSTRAINT PK_Color PRIMARY KEY (idColor)
)

CREATE TABLE Planta
(
idPlanta INT IDENTITY (1,1) NOT NULL,
nombrePlanta VARCHAR(50),
superficie FLOAT,
idFabrica INT,
idColor INT,
CONSTRAINT FK_Planta_Fabrica FOREIGN KEY (idFabrica) REFERENCES Fabrica,
CONSTRAINT FK_Planta_Color FOREIGN KEY (idColor) REFERENCES Color
)

-- Insert de Tablas Necesarias --

INSERT INTO Fabrica
VALUES ('Fábrica 1')
INSERT INTO Fabrica
VALUES ('Fábrica 2')
INSERT INTO Fabrica
VALUES ('Fábrica 3')

INSERT INTO Color
VALUES ('Azul')
INSERT INTO Color
VALUES ('Rojo')
INSERT INTO Color
VALUES ('Amarillo')
INSERT INTO Color
VALUES ('Verde')
