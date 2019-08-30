Create Database M_Ekips;

Use M_Ekips;

	--DDL--

Create Table Permissoes(
	IdPermissao int primary key identity
	,Permissao varchar(200) unique not null
);

Create Table Usuarios(
	IdUsuario int primary key identity
	,Email varchar(200) not null
	,Senha varchar(200) unique not null
	,Permissao int foreign key references Permissoes(IdPermissao) not null
);

Create Table Cargos(
	IdCargo int primary key identity
	,Nome varchar(200) not null
	,Ativo varchar(200) not null
);

Create Table Departamentos(
	IdDepartamento int primary key identity
	,Nome varchar(200) not null
);

Create Table Funcionarios(
	IdFuncionario Int Primary Key Identity
	,Funcionario Varchar (255) Not Null Unique
	,CPF Varchar (255) Not Null Unique
	,DataNascimento Date Not Null
	,Salario BigInt
	,IdDepartamento Int Foreign Key References Departamentos (IdDepartamento)
	,IdCargo Int Foreign Key References Cargos (IdCargo)
	,IdUsuario Int Foreign Key References Usuarios (IdUsuario)
);

	--DML--

Insert Into Permissoes	(Permissao)
	Values				('ADMINISTRADOR')
						,('COMUM');

Insert Into Departamentos	(Nome)
	Values					('Jurídico ')
							,('Tecnologia')
							,('Limpeza');


Insert Into Cargos	(Nome, Ativo)
	Values			('Advogado Trabalhista' , 'Ativo')
					,('Operador de máquinas' , 'Desativado')
					,('Engenheiro' , 'Ativo')
					,('Lixeiro(gari)' , 'Desativado');

Insert Into Usuarios	(Email , Senha , Permissao)
	Values			('b@email.com', 12345, 1)
					,('f@email.com', 123456, 1)
					,('m@email.com', 1234567, 2);

Insert Into Funcionarios(Funcionario , CPF , DataNascimento , Salario , IdDepartamento , IdCargo , IdUsuario)
	Values			('Roger' , 737759178-10, '1990-05-10', 1000, 1, 1, 3)
					,('Luana', 630097228-34, '1997-09-06', 3212, 2, 2, 4)
					,('Mario', 426569158-72, '2000-03-13', 9349024, 3, 4, 5);

		--DQL--

Select * from Usuarios;
Select * from Permissoes;
Select * from Cargos;
Select * from Departamentos;
Select * from Funcionarios;