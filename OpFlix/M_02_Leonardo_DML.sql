Use M_OpFlix;

Insert into Categorias (Nome)
values	('A��o'), ('Terror'), ('Romance'), ('Fic��o'), ('Com�dia'), ('Drama'), ('Suspense'), ('Aventura');

Select * from UsuariosLancamentos;

Insert into Tipos (Nome)
values	('Filme'), ('S�rie');

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
		,('La Casa de Papel', 'Um roubo � casa da moeda espanhola � perfeitamente arquitetado', 7, '50 min', 2, '02/05/2017', 1)
		,('Godzilla 2: Rei dos Monstros', 'Godzilla deve provar que � a criatura mais forte da Terra', 4, '132 min', 1, '30/05/2019', 2)
		,('The Boys', 'inspirada na s�rie em quadrinhos de Super-Her�is "The Boys"', 6, '60 min', 2, '26/07/2019', 3);

Insert into UsuariosLancamentos (IdUsuario, IdLancamento)
values (2, 1), (3, 2), (2, 4), (3, 3), (3, 5);

Update Usuarios
Set IdTipoUsuario = 1
Where IdUsuario = 3;

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Deuses Americanos', 'serie', 6, '58 min', 2, '30/04/2017', 1)
		,('O Rei Le�o', 'Tra�do e exilado de seu reino, o le�ozinho Simba precisa crescer e retomar seu reino nas plan�cies da savana africana.', 6, '118 min', 1, '18/07/2019', 2);

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
values	('Document�rio'), ('Anima��o');

Update Lancamentos
Set IdCategoria = 10
Where IdLancamento = 7;

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Coringa', 'A trajet�ria de um homem comum (Arthur Fleck) at� se tornar "O Palha�o do Crime"', 1, '122 min', 1, '03/10/2019', 2)
		,('Guardi�es da Gal�xia', 'Filme que nos mostra como se deu a origem dos protetores da Gal�xia', 1, '125 min', 1, '31/07/2014', 2)
		,('Guardi�es da Gal�xia', 'Filme que nos mostra como se deu a origem dos protetores da Gal�xia', 1, '125 min', 1, '31/07/2014', 1);

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Homem-Aranha: Far From Home', 'Peter � convocado para uma miss�o durante uma viagem para a Europa', 4, '129 min', 1, '04/07/2019', 2);


Update Lancamentos
Set Nome = 'La Casa de Papel 3� Temporada'
Where IdLancamento = 3;

Update Lancamentos
Set DataLancamento = '01/04/2019'
Where IdLancamento = 3;