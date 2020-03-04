--DEFINE QUAL BANCO DE DADOS SERÁ USADO
USE InLock_Games_Manha;
GO

-- Listar todos os usuários
SELECT * FROM Usuario;

-- Listar todos os estúdios
SELECT * FROM Estudio;

-- Listar todos os jogos
SELECT * FROM Jogo;

-- Listar todos os jogos e seus respectivos estúdios
SELECT NomeJogo, NomeEstudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio;

-- Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência
SELECT * FROM Estudio LEFT OUTER JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio;

-- Busca um usuário através do E-mail e da Senha
SELECT U.IdUsuario, U.Email, U.IdTipoUsuario, TU.Titulo FROM Usuario U
INNER JOIN TipoUsuario TU
ON U.IdTipoUsuario = TU.IdTipoUsuario
WHERE U.Email = 'admin@admin.com' AND U.Senha = 'admin'

-- Buscar um jogo por IdJogo;
SELECT NomeJogo, Descricao, DataLancamento, Valor FROM Jogo
WHERE IdJogo = 2;

-- Buscar um estúdio por IdEstudio
SELECT NomeEstudio FROM Estudio
WHERE IdEstudio = 3;
