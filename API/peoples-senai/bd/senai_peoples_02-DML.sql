-- Define o banco de dados que será utilizado
USE Peoples_manha;

-- Insere dois funcionários
INSERT INTO Funcionarios (Nome, Sobrenome) 
VALUES	('Catarina', 'Strada')
		,('Tadeu', 'Vitelli');

-- Atualiza o valor da coluna DataNascimento
UPDATE Funcionarios SET DataNascimento = '1993-03-17';

INSERT INTO TipoUsuario (Titulo)
VALUES	('Adm'),
		('Comum');

INSERT INTO Usuario (Email,Senha,IdTipoUsuario)
VALUES	('adm@email.com','adm',1),
		('comum@email.com','comum',2),
		('catarina@email.com', 'catarina',1)
		,('tadeu@email.com', 'tadeu',2);