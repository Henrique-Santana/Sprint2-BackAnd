--Cria o banco de dados com nome do project
CREATE DATABASE Gufi_Manha;
GO

--Define o banco de dados que será utilizado.
Use Gufi_Manha;
GO

--Criação das tabelas.
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo        VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE TipoEvento(
	IdTipoEvento         INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Instituicao(
	IdInstitucao INT PRIMARY KEY IDENTITY,
	CNPJ         CHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR (255) UNIQUE,
	Endereco     VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuario (
	IdUsuario     INT PRIMARY KEY IDENTITY,
	Nome          VARCHAR (255) NOT NULL,
	Email         VARCHAR (255) UNIQUE,
	Senha         VARCHAR (255) NOT NULL,
	DataCasdastro DateTime2,
	Genero        VARCHAR (255),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);
GO

CREATE TABLE Evento (
	 IdEvento       INT PRIMARY KEY IDENTITY
	,NomeEvento    VARCHAR (255) NOT NULL
	,DataEvento    DATETIME2 NOT NULL
	,Descricao     VARCHAR (255) NOT NULL
	,AcessoLivre   BIT DEFAULT (1) NOT NULL --DEFAULT(Numero), POR PADRÃO SERA INSERIDO UM VALOR MESMO SE NÃO FOR ENVIADO UM. 
	,IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (IdInstitucao)
	,IdTipoEvento  INT FOREIGN KEY REFERENCES TipoEvento (IdTipoEvento)
);
GO

CREATE TABLE Presenca (
	 IdPresenca INT PRIMARY KEY IDENTITY
	,IdUsuario  INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,IdEvento   INT FOREIGN KEY REFERENCES Evento (IdEvento)
	,Situacao   VARCHAR (255) NOT NULL
);
GO
SELECT * FROM Presenca;
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;

INSERT TipoUsuario (Titulo)
VALUES   ('Administrador'),
		 ('Comum');
GO

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES  ('C#'),
		('React'),
		('SQL');
GO

INSERT INTO  Instituicao (NomeFantasia, CNPJ, Endereco)
VALUES ('Escola SENAI de Informatica','12345678912345','Barão de limeira');
GO

INSERT INTO Usuario (IdTipoUsuario, Nome, Email, Senha, DataCasdastro, Genero)
VALUES  (1, 'Administrador', 'ADM@ADM.COM', 'ADM123','06/02/2020' ,'Não informado'),
		(2, 'Carol', 'Carol@email.com', 'Carol123', '06/02/2020', 'Feminino'),
		(2, 'Saulo','Saulo@email.com', 'Saulo123', '06/02/2020', 'Masculono');
GO

INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre, IdInstituicao, IdTipoEvento )
VALUES  ('Orientação a Objeto', '07/02/2020','Conceitos sobre os pilares da programação orientada a objetos.', 1,1, 1),
		('Cliclo de vida', '08/02/2020', 'Como utilizar os ciclos de vida com a biblioteca ReactJs', 0,1, 2),
		('Introdução a SQL', '09/02/2020', 'Comandos básicos utilizando SQL Server.', 1,1, 3);
GO

INSERT INTO Presenca(IdUsuario, IdEvento ,Situacao)
VALUES  (2, 2,'Confirmada'),
		(2, 3, 'Não Confirmada' ),
		(3, 1,'Confirmada');
GO

--- LISTAR TODOS OS USUÁRIOS CADASTRADOS
SELECT IdUsuario, Nome, Email, Senha, DataCasdastro, Genero, Titulo FROM Usuario -- Após o FROM vai as tabelas que serão relacionadas.
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario; -- Após o ON vai as tabelas e o atributo que será a ponte entre eles( A chave estrangeira)

--LISTAR TODAS AS INSTITUIÇÕES CADASTRADAS
SELECT NomeFantasia, CNPJ, Endereco FROM Instituicao;

--LISTAR TODOS OS EVENTOS
SELECT  NomeEvento, DataEvento, Descricao, AcessoLivre, NomeFantasia, TituloTipoEvento FROM Evento
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdTipoEvento 
INNER JOIN Instituicao ON Instituicao.IdInstitucao = Evento.IdInstituicao;

--LISTAR TODOS OS TIPOS DE EVENTOS
SELECT TituloTipoEvento FROM TipoEvento;

--LISTAR APENAS OS EVENTOS QUE SÃO PÚBLICOS
SELECT NomeFantasia, TipoEvento.TituloTipoEvento, NomeEvento, DataEvento, Descricao, AcessoLivre FROM Evento 
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstitucao 
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdTipoEvento
WHERE AcessoLivre = 1;

--LISTAR TODOS OS EVENTOS QUE UM DETERMINADO USUÁRIO PARTICIPA
SELECT NomeEvento, Nome AS NomeUsuario, DataEvento, Descricao, AcessoLivre, NomeFantasia,  TituloTipoEvento   FROM Presenca 
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento 
INNER JOIN Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstitucao
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdTipoEvento
WHERE Nome= 'Carol' AND Situacao = 'Confirmada';

SELECT I.CNPJ, I.Endereco ,NomeEvento, DataEvento, Descricao, NomeFantasia, TituloTipoEvento,
CASE AcessoLivre
	 WHEN 1 THEN 'Público'
	 WHEN 0 THEN 'Privado'
END  AcessoLivre
FROM Evento
INNER JOIN Instituicao I ON Evento.IdInstituicao = I.IdInstitucao 
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdEvento