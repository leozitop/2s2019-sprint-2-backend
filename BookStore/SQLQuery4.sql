Use M_Livros;

Select * from Autores;
Select * from Gêneros;
Select * from Livros;

Insert into Autores (Nome) values ('');

Update Livros set Nome = '', IdAutor = '', IdGenero = '' where IdLivro = '';