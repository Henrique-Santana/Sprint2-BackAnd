INSERT TipoUsuario (Titulo)
VALUES   ('Administrador'),
		 ('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES  ('C#'),
		('React'),
		('SQL');

INSERT INTO  Instituicao (NomeFantasia, CNPJ, Endereco)
VALUES ('Escola SENAI de Informatica','12345678912345','Barão de limeira');

INSERT INTO Usuario (IdTipoUsuario, Nome, Email, Senha, DataCasdastro, Genaro)
VALUES  (1, 'Administrador', 'ADM@ADM.COM', 'ADM123','06/02/2020' ,'Não informado'),
		(2, 'Carol', 'Carol@email.com', 'Carol123', '06/02/2020', 'Feminino'),
		(2, 'Saulo','Saulo@email.com', 'Saulo123', '06/02/2020', 'Masculono');

INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre, IdInstituicao, IdTipoEvento )
VALUES  ('Orientação a Objeto', '07/02/2020','Conceitos sobre os pilares da programação orientada a objetos.', 1,1, 1),
		('Cliclo de vida', '08/02/2020', 'Como utilizar os ciclos de vida com a biblioteca ReactJs', 0,1, 2),
		('Introdução a SQL', '09/02/2020', 'Comandos básicos utilizando SQL Server.', 1,1, 3);

INSERT INTO Presenca(IdUsuario, IdEvento ,Situacao)
VALUES  (2, 2,'Confirmada'),
		(2, 3, 'Não Confirmada' ),
		(3, 1,'Confirmada');