-- Cria o banco de dados
CREATE DATABASE Peoples_manha;

-- Define qual banco de dados será utilizado
USE Peoples_manha;

-- Cria a tabela Funcionarios
CREATE TABLE Funcionarios 
(
	IdFuncionario	INT IDENTITY PRIMARY KEY
	,Nome			VARCHAR(200) NOT NULL
	,Sobrenome		VARCHAR(255)
);
GO
CREATE TABLE TipoUsuario(
	IdTipoUsuario INT IDENTITY PRIMARY KEY,
	Titulo VARCHAR(50) NOT NULL
);

CREATE TABLE Usuario(
	IdUsuario INT IDENTITY PRIMARY KEY,
	Email VARCHAR(100) NOT NULL,
	Senha VARCHAR (70) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);

-- Adiciona a coluna IdTipoUsuario que é a chave estrangeira de TipoUsuario na tabela Funcionarios
ALTER TABLE Funcionarios
ADD IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)

ALTER TABLE Funcionarios
ADD IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)

--Complementando a tabela Funcionario com o id do funcionario
UPDATE Funcionarios SET IdUsuario = 4
WHERE IdFuncionario = 2

DROP TABLE Funcionarios;


ALTER TABLE Funcionarios
ADD DataNascimento DATE 

