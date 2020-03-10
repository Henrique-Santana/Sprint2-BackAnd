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
VALUES	(' SALVADOTiR - 5 DIAS / 4 DIÁRIAS', ' O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação.', '06/08/2020', '10/08/2020', 854.00, 1, 1),
		('RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS', 'O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.', '12/05/2020', '18/05/2020', 1826.00, 1, 1),
		('BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS', 'Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas dágua da região.', '28/03/2020', '01/04/2020', 1004.00, 1, 2);
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

--Listar todos os usuários mostrando o título do tipo de usuário.
SELECT Email, Senha, TiposUsuario.Titulo FROM Usuarios INNER JOIN TiposUsuario ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario;

--Listar os pacotes e mostrar o nome da cidade.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, Cidades.NomeCidade FROM Pacotes INNER JOIN Cidades ON Pacotes.IdCidade = Cidades.IdCidade;