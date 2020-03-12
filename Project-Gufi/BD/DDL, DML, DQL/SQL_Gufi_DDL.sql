--Cria o banco de dados com nome do project
CREATE DATABASE Gufi_Manha;

--Define o banco de dados que será utilizado.
Use Gufi_Manha;

--Criação das tabelas.
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo        VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE TipoEvento(
	IdEvento         INT PRIMARY KEY IDENTITY,
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
	Genaro        VARCHAR (255),
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
	,IdTipoEvento  INT FOREIGN KEY REFERENCES TipoEvento (IdEvento)
);
GO

CREATE TABLE Presenca (
	 IdPresenca INT PRIMARY KEY IDENTITY
	,IdUsuario  INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
	,IdEvento   INT FOREIGN KEY REFERENCES Evento (IdEvento)
	,Situacao   VARCHAR (255) NOT NULL
);