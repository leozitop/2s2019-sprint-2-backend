Use M_OpFlix;

Select * from Categorias order by IdCategoria;
Select * from Tipos order by IdTipo;
Select * from Plataformas order by IdPlataforma;
Select * from TiposUsuarios order by IdTipoUsuario;
Select * from Usuarios order by IdUsuario;
Select * from Lancamentos order by IdLancamento;
Select * from UsuariosLancamentos order by IdUsuario;

Select UL.*, U.*, L.*
from UsuariosLancamentos UL
join Usuarios U
ON UL.IdUsuario = U.IdUsuario
join Lancamentos L
ON UL.IdLancamento = L.IdLancamento;

Select LEN('La Casa de Papel');
--quantidade de caracteres de um lançamento--

Create Procedure Linhas
@QtdLinhas varchar(200)
As
select count(*)
from Lancamentos
where IdLancamento >= 1

Execute Linhas '1';
Drop Procedure Linhas;
--Quantidade de lançamentos--

SELECT DATEDIFF(day, getDate(), '2019-10-03');
--Diferença em dias até a data de lançamento do filme "Coringa"--

Create Procedure BuscarAcao
@CampoBusca varchar(200)
As
select count(IdCategoria)
from Lancamentos
where IdCategoria = @CampoBusca

Execute BuscarAcao '1';
Drop Procedure BuscarAcao;
--buscar por filmes de Ação--

Create Procedure Buscar
@CampoBusca varchar(200)
As
select count(IdCategoria)
from Lancamentos
where IdCategoria = @CampoBusca

Execute Buscar '4';
Drop Procedure Buscar;
--buscar filmes pelo id da categoria--

Create Procedure CategoriaPlataforma
@QtdLancamentos varchar(200)
As
select count(IdPlataforma)
from Lancamentos
where Idplataforma = @QtdLancamentos

Execute CategoriaPlataforma '4';
Drop Procedure CategoriaPlataforma;

select * from Lancamentos;

select distinct Nome, IdCategoria, IdTipo, Duracao from Lancamentos;
