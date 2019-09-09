Create Database M_OpFlix;

Use M_OpFlix;

Create table Categorias(
	IdCategoria int primary key identity not null
	,Nome varchar(255) not null unique
);

Create table Tipos(
	IdTipo int primary key identity not null
	,Nome varchar(255) not null unique
);

Create table Plataformas(
	IdPlataforma int primary key identity not null
	,Nome varchar(255) not null unique
);

Create table TiposUsuarios(
	IdTipoUsuario int primary key identity not null
	,Nome varchar(255) not null unique
);

Create table Usuarios(
	IdUsuario int primary key identity not null
	,Nome varchar(255) not null
	,IdTipoUsuario int foreign key references TiposUsuarios (IdTipoUsuario) not null
	,Senha varchar(255) not null
	,Email varchar(255) not null unique
);

Create table Lancamentos(
	IdLancamento int primary key identity not null
	,Nome varchar(255) not null
	,Sinopse text not null
	,IdCategoria int foreign key references Categorias (IdCategoria)
	,Duracao int not null
	,IdTipo int foreign key references Tipos (IdTipo)
	,DataLancamento Date not null
	,IdPlataforma int foreign key references Plataformas (IdPlataforma)
);

Create table UsuariosLancamentos(
	IdUsuario int foreign key references Usuarios (IdUsuario)
	,IdLancamento int foreign key references Lancamentos (IdLancamento)
);

Alter table Lancamentos
alter column Duracao varchar(255);

Create View PlataformasCategorias(
	IdPlataforma int foreign key references Plataformas (IdPlataforma)
);
