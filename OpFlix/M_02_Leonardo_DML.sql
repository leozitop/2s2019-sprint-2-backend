Use M_OpFlix;

Insert into Categorias (Nome)
values	('Ação'), ('Terror'), ('Romance'), ('Ficção'), ('Comédia'), ('Drama'), ('Suspense'), ('Aventura');

Select * from UsuariosLancamentos;

Insert into Tipos (Nome)
values	('Filme'), ('Série');

Insert into Plataformas (Nome)
values	('Netflix'), ('Cinema'), ('Amazon');

Insert into TiposUsuarios (Nome)
values	('Administrador'), ('Cliente');

Insert into Usuarios (Nome, IdTipoUsuario, Senha, Email)
values	('Erik', 1, '123456', 'erik@email.com')
		,('Cassiana', 1, '123456', 'cassiana@email.com')
		,('Helena', 2, '123456', 'helena@email.com')
		,('Roberto', 2, '3110', 'rob@email.com');

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Vingadores: Endgame', 'Desfecho de "Infinity War", onde Thanos mata metade do universo', 1, '182 min', 1, '25/04/2019', 2);

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Annabelle 3', 'O terceiro filme da boneca do mal', 2, '106 min', 1, '26/06/2019', 2)
		,('La Casa de Papel', 'Um roubo à casa da moeda espanhola é perfeitamente arquitetado', 7, '50 min', 2, '02/05/2017', 1)
		,('Godzilla 2: Rei dos Monstros', 'Godzilla deve provar que é a criatura mais forte da Terra', 4, '132 min', 1, '30/05/2019', 2)
		,('The Boys', 'inspirada na série em quadrinhos de Super-Heróis "The Boys"', 6, '60 min', 2, '26/07/2019', 3);

Insert into UsuariosLancamentos (IdUsuario, IdLancamento)
values (2, 1), (3, 2), (2, 4), (3, 3), (3, 5);

Update Usuarios
Set IdTipoUsuario = 1
Where IdUsuario = 3;

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Deuses Americanos', 'serie', 6, '58 min', 2, '30/04/2017', 1)
		,('O Rei Leão', 'Traído e exilado de seu reino, o leãozinho Simba precisa crescer e retomar seu reino nas planícies da savana africana.', 6, '118 min', 1, '18/07/2019', 2);

Insert into Plataformas (Nome)
values	('VHS');

Delete from Lancamentos
Where IdLancamento = 6;

Update Lancamentos
Set DataLancamento = '08/07/1994'
Where IdLancamento = 7;

Update Lancamentos
Set IdPlataforma = 4
Where IdLancamento = 7;

Insert into Categorias (Nome)
values	('Documentário'), ('Animação');

Update Lancamentos
Set IdCategoria = 10
Where IdLancamento = 7;

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Coringa', 'A trajetória de um homem comum (Arthur Fleck) até se tornar "O Palhaço do Crime"', 1, '122 min', 1, '03/10/2019', 2)
		,('Guardiões da Galáxia', 'Filme que nos mostra como se deu a origem dos protetores da Galáxia', 1, '125 min', 1, '31/07/2014', 2)
		,('Guardiões da Galáxia', 'Filme que nos mostra como se deu a origem dos protetores da Galáxia', 1, '125 min', 1, '31/07/2014', 1);

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Homem-Aranha: Far From Home', 'Peter é convocado para uma missão durante uma viagem para a Europa', 4, '129 min', 1, '04/07/2019', 2);


Update Lancamentos
Set Nome = 'La Casa de Papel 3ª Temporada'
Where IdLancamento = 3;

Update Lancamentos
Set DataLancamento = '01/04/2019'
Where IdLancamento = 3;