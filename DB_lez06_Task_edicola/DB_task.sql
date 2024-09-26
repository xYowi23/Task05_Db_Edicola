DROP TABLE IF EXISTS Rivista;
CREATE TABLE Giocattolo (
	giocattoloId INT PRIMARY KEY IDENTITY (1,1),
	nome VARCHAR (250) NOT NULL,
	materiale VARCHAR (250) NOT NULL DEFAULT 'N.D.',
	etaMin  INT NOT NULL CHECK (etaMin >= 0),
	prezzo DECIMAL(5,2) NOT NULL DEFAULT 0,
	codUniGio VARCHAR (50) DEFAULT NEWID(),
	CONSTRAINT CHK_Rivista_prezzo CHECK(prezzo >= 0)
);

CREATE TABLE Rivista (
	rivistaId INT PRIMARY KEY IDENTITY (1,1),
	titolo VARCHAR (250) NOT NULL,
	prezzo DECIMAL(5,2) NOT NULL DEFAULT 0,
	casaEditrice VARCHAR (250) NOT NULL,
	codUniRiv VARCHAR (50) DEFAULT NEWID(),
	CONSTRAINT CHK_Giocattolo_prezzo CHECK(prezzo >= 0)


);

INSERT INTO Giocattolo (nome, materiale, etaMin, prezzo)
VALUES ('Action Figure', 'Plastica', 5, 19.99);

INSERT INTO Giocattolo (nome, etaMin, prezzo)
VALUES ('Peluche Orsetto', 0, 10.50); -- materiale usa il valore di default 'N.D.'

INSERT INTO Giocattolo (nome, materiale, etaMin)
VALUES ('Macchinina Telecomandata', 'Metallo', 6); -- prezzo usa il valore di default 0

INSERT INTO Giocattolo (nome, materiale, etaMin, prezzo)
VALUES ('Puzzle 500 pezzi', 'Carta', 8, 12.00);

INSERT INTO Rivista (titolo, prezzo, casaEditrice)
VALUES ('Scienza per Tutti', 5.99, 'Mondadori');

INSERT INTO Rivista (titolo, casaEditrice)
VALUES ('Moda Oggi', 'Condé Nast'); -- prezzo usa il valore di default 0

INSERT INTO Rivista (titolo, prezzo, casaEditrice)
VALUES ('Storia & Misteri', 4.50, 'De Agostini');

INSERT INTO Rivista (titolo, prezzo, casaEditrice)
VALUES ('Sportivo Mensile', 3.99, 'Gazzetta');

SELECT * FROM Giocattolo;
SELECT * FROM Rivista;

SELECT giocattoloId, nome, materiale,etaMin ,prezzo ,codUniGio FROM Giocattolo

SELECT giocattoloId,nome,materiale,etaMin,prezzo,codUniGio FROM Giocattolo

SELECT rivistaId, titolo,casaEditrice,codUniRiv FROM Rivista