SELECT * FROM Presenca;
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Usuario;
SELECT * FROM Evento;
--- LISTAR TODOS OS USUÁRIOS CADASTRADOS
SELECT IdUsuario, Nome, Email, Senha, DataCasdastro, Genaro, Titulo FROM Usuario -- Após o FROM vai as tabelas que serão relacionadas.
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario; -- Após o ON vai as tabelas e o atributo que será a ponte entre eles( A chave estrangeira)

--LISTAR TODAS AS INSTITUIÇÕES CADASTRADAS
SELECT NomeFantasia, CNPJ, Endereco FROM Instituicao;

--LISTAR TODOS OS EVENTOS
SELECT  NomeEvento, DataEvento, Descricao, AcessoLivre, NomeFantasia, TituloTipoEvento FROM Evento
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdEvento 
INNER JOIN Instituicao ON Instituicao.IdInstitucao = Evento.IdInstituicao;

--LISTAR TODOS OS TIPOS DE EVENTOS
SELECT TituloTipoEvento FROM TipoEvento;

--LISTAR APENAS OS EVENTOS QUE SÃO PÚBLICOS
SELECT NomeFantasia, TipoEvento.TituloTipoEvento, NomeEvento, DataEvento, Descricao, AcessoLivre FROM Evento 
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstitucao 
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdEvento
WHERE AcessoLivre = 1;

--LISTAR TODOS OS EVENTOS QUE UM DETERMINADO USUÁRIO PARTICIPA
SELECT NomeEvento, Nome AS NomeUsuario, DataEvento, Descricao, AcessoLivre, NomeFantasia,  TituloTipoEvento   FROM Presenca 
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento 
INNER JOIN Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstitucao
INNER JOIN TipoEvento ON Evento.IdEvento = TipoEvento.IdEvento
WHERE Nome= 'Carol' AND Situacao = 'Confirmada';

SELECT NomeEvento, DataEvento, Descricao, NomeFantasia, TituloTipoEvento, 
CASE AcessoLivre
	 WHEN 1 THEN 'Público'
	 WHEN 0 THEN 'Privado'
END  AcessoLivre
FROM Evento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstitucao 
INNER JOIN TipoEvento ON TipoEvento.IdEvento = Evento.IdEvento

