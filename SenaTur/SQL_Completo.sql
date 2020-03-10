CREATE DATABASE Senatur_Manha;
GO

USE Senatur_Manha;
GO

CREATE TABLE Cidades (
	IdCidade INT PRIMARY KEY IDENTITY
	,NomeCidade VARCHAR (50) NOT NULL
); 
GO

CREATE TABLE Pacotes (
	IdPacote    INT PRIMARY KEY IDENTITY 
	,NomePacote VARCHAR (255) NOT NULL
	,Descricao  TEXT NOT NULL
	,DataIda    DATE NOT NULL
	,DataVolta  DATE NOT NULL
	,Valor      DECIMAL(18, 2) NOT NULL
	,Ativo      BIT DEFAULT (1) NOT NULL
	,IdCidade   INT FOREIGN KEY REFERENCES Cidades (IdCidade)
);
GO

CREATE TABLE TiposUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY  
	,Titulo VARCHAR (255) NOT NULL
);
GO

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY
	,Email VARCHAR (50) NOT NULL
	,Senha VARCHAR (50) NOT NULL
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario (IdTipoUsuario)
);

GO

INSERT INTO Cidades (NomeCidade)
VALUES	('Salvador'),
		('Bonito');
GO

INSERT INTO Pacotes (NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, IdCidade)
VALUES	(' SALVADOTiR - 5 DIAS / 4 DI�RIAS', ' O que n�o falta em Salvador s�o atra��es. Prova disso s�o as praias, os museus e as constru��es seculares que d�o um charme mais que especial � regi�o. A cidade, sin�nimo de alegria, tamb�m � conhecida pela efervesc�ncia cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador s�o alguns dos principais pontos de visita��o.', '06/08/2020', '10/08/2020', 854.00, 1, 1),
		('RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DI�RIAS', 'O Litoral Norte da Bahia conta com in�meras praias emolduradas por coqueiros, al�m de piscinas naturais de �guas mornas que s�o protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em �guas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e cal�ad�es, passeios de bicicleta, pontos tur�sticos hist�ricos, intera��o com animais e at� baladas est�o entre as atra��es da regi�o. Destacam-se as praias de Guarajuba, Imbassa�, Praia do Forte e Costa do Sauipe.', '12/05/2020', '18/05/2020', 1826.00, 1, 1),
		('BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DI�RIAS', 'Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de �guas cristalinas, al�m de cavernas inundadas, pared�es rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecol�gicas, passeios de bote e descidas de rapel pelas in�meras quedas d�gua da regi�o.', '28/03/2020', '01/04/2020', 1004.00, 1, 2);
GO

INSERT INTO TiposUsuario (Titulo)
VALUES	('Administrador'),
		('Cliente');
GO 

INSERT INTO Usuarios (Email, Senha, IdTipoUsuario)
VALUES	('adm@email.com', 'adm123',1 ),
		('cliente@email.com', 'cliente123', 2);
GO

SELECT * FROM TiposUsuario
SELECT * FROM Usuarios
SELECT * FROM Cidades
SELECT * FROM Pacotes

--Listar todos os usu�rios mostrando o t�tulo do tipo de usu�rio.
SELECT Email, Senha, TiposUsuario.Titulo FROM Usuarios INNER JOIN TiposUsuario ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario;

--Listar os pacotes e mostrar o nome da cidade.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, Cidades.NomeCidade FROM Pacotes INNER JOIN Cidades ON Pacotes.IdCidade = Cidades.IdCidade;