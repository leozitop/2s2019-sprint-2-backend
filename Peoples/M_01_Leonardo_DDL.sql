Create database M_Peoples;

Use M_Peoples;

Create Table Funcionarios(
	IdFuncionario int primary key identity
	,Nome varchar(255) not null
	,Sobrenome varchar(255) not null
);