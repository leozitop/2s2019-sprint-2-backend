Use M_OpFlix;

Insert into Categorias (Nome)
values	('Ação'), ('Terror'), ('Romance'), ('Ficção'), ('Comédia'), ('Drama'), ('Suspense'), ('Aventura');

Select * from Lancamentos;

Insert into Tipos (Nome)
values	('Filme'), ('Série');

Insert into Plataformas (Nome)
values	('Netflix'), ('Cinema'), ('Amazon');

Insert into TiposUsuarios (Nome)
values	('Administrador'), ('Cliente');

Insert into Usuarios (Nome, IdTipoUsuario, Senha, Email)
values	('Erik',		1,	'123456',	'erik@email.com')
		,('Cassiana',	1,	'123456',	'cassiana@email.com')
		,('Helena',		2,	'123456',	'helena@email.com')
		,('Roberto',	2,	'3110',		'rob@email.com');

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Vingadores: Endgame', 'Desfecho de "Infinity War", onde Thanos mata metade do universo', 1, '182 min', 1, '25/04/2019', 2);

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Annabelle 3',						'O terceiro filme da boneca do mal',								2, '106 min',	1, '26/06/2019', 2)
		,('La Casa de Papel',				'Um roubo à casa da moeda espanhola é perfeitamente arquitetado',	7, '50 min',	2, '02/05/2017', 1)
		,('Godzilla 2: Rei dos Monstros',	'Godzilla deve provar que é a criatura mais forte da Terra',		4, '132 min',	1, '30/05/2019', 2)
		,('The Boys',						'inspirada na série em quadrinhos de Super-Heróis "The Boys"',		6, '60 min',	2, '26/07/2019', 3);

--Insert into UsuariosLancamentos (IdUsuario, IdLancamento)
--values (2, 1), (3, 2), (2, 4), (3, 3), (3, 5);

Update Usuarios
Set IdTipoUsuario = 1
Where IdUsuario = 3;

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Deuses Americanos',	'serie', 6, '58 min', 2, '30/04/2017', 1)
		,('O Rei Leão',			'Traído e exilado de seu reino, o leãozinho Simba precisa crescer e retomar seu reino nas planícies da savana africana.', 6, '118 min', 1, '18/07/2019', 2);

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
values	('Coringa',					'A trajetória de um homem comum (Arthur Fleck) até se tornar "O Palhaço do Crime"', 1, '122 min', 1, '03/10/2019', 2)
		,('Guardiões da Galáxia',	'Filme que nos mostra como se deu a origem dos protetores da Galáxia',				1, '125 min', 1, '31/07/2014', 2)
		,('Guardiões da Galáxia',	'Filme que nos mostra como se deu a origem dos protetores da Galáxia',				1, '125 min', 1, '31/07/2014', 1);

Insert into Lancamentos (Nome, Sinopse, IdCategoria, Duracao, IdTipo, DataLancamento, IdPlataforma)
values	('Homem-Aranha: Far From Home', 'Peter é convocado para uma missão durante uma viagem para a Europa', 4, '129 min', 1, '04/07/2019', 2);


Update Lancamentos
Set Nome = 'La Casa de Papel 3ª Temporada'
Where IdLancamento = 3;

Update Lancamentos
Set DataLancamento = '01/04/2019'
Where IdLancamento = 3;

Insert into Favoritos (IdUsuario, IdLancamento)
values	(1, 2), (1, 4), (1, 7), (2, 1), (2, 5), (3, 8), (3, 10), (3, 12), (4, 1), (4, 3), (4, 8), (4, 12);

Alter table Lancamentos add Imagem varchar (200);

update Lancamentos set Imagem = 'https://imagens.canaltech.com.br/271675.517177-coringa.jpg' where IdLancamento = 8;

update Lancamentos set Imagem = 'https://upload.wikimedia.org/wikipedia/pt/thumb/9/9b/Avengers_Endgame.jpg/250px-Avengers_Endgame.jpg' where IdLancamento = 1;
update Lancamentos set Imagem = 'http://br.web.img3.acsta.net/pictures/19/06/06/22/15/5719779.jpg' where IdLancamento = 2;
update Lancamentos set Imagem = 'https://www.dnoticias.pt/binrepository/768x432/0c0/0d0/none/11506/YIRB/image_content_2350202_20190718165617.jpg' where IdLancamento = 3;
update Lancamentos set Imagem = 'https://upload.wikimedia.org/wikipedia/pt/thumb/7/7e/Godzilla_King_of_the_Monsters.jpg/250px-Godzilla_King_of_the_Monsters.jpg' where IdLancamento = 4;
update Lancamentos set Imagem = 'https://uploads.jovemnerd.com.br/wp-content/uploads/2019/09/NC_691_The-boys_giga-760x428.jpg' where IdLancamento = 5;
update Lancamentos set Imagem = 'http://br.web.img3.acsta.net/c_215_290/pictures/19/05/07/20/54/2901026.jpg' where IdLancamento = 7;
update Lancamentos set Imagem = 'https://kanto.legiaodosherois.com.br/w760-h398-gnw-cfill-q80/wp-content/uploads/2018/05/legiao_J6h8DRjEGSYZqwm_yiNnXQWKuFa7r5VsktvlT1o09B.jpg.jpeg' where IdLancamento = 9;
update Lancamentos set Imagem = 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeulF23jIQ8n8W4L6qfm9Kb2TnlvddD8UwtczsWggXaSkaoB30Zw' where IdLancamento = 10;
update Lancamentos set Imagem = 'http://br.web.img3.acsta.net/c_215_290/pictures/19/07/05/17/30/5167951.jpg' where IdLancamento = 12;