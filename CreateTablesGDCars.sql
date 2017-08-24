use GDCars;

create table GDC_Logins (
	Id uniqueidentifier not null,
	Nome varchar(20) not null,
	SobreNome varchar(20) not null,
	Email varchar(50) not null,
	Senha varchar(50) not null,
	DataNascimento varchar(10) not null,
	Data_Inclusao Datetime not null,
	Tipo_Acesso char(1) not null

	PRIMARY KEY (Id)
)


create table GDC_Enderecos (
	Id uniqueidentifier not null, 
	Endereco varchar(30) not null,
	Numero varchar(5) not null,
	Complemento varchar(5),
	CEP int not null,
	Bairro varchar(30),
	Estado varchar(30),
	Cidade varchar(30),

	PRIMARY KEY (Id)
)

create table GDC_Clientes(
	Id uniqueidentifier not null,
	Nome varchar(30) not null,
	RG varchar(9) not null,
	CPF int not null,
	Tipo char(1) not null,
	Email varchar(50) not null,
	IdEndereco uniqueidentifier null FOREIGN KEY REFERENCES GDC_Enderecos(Id)

	Primary Key(Id)
)

create table GDC_Uploads(
	Id uniqueidentifier not null,
	Data_Inclusao datetime not null,
	Nome_Arquivo varchar(200) not null
	
	Primary Key(Id) 
)

create table GDC_Rodas(
	Id uniqueidentifier not null,
	Modelo varchar(20) not null,
	Cor varchar(10) not null,
	Aro int not null,
	Valor int not null,
	IdUpload uniqueidentifier null FOREIGN KEY REFERENCES GDC_Uploads(Id),

	Primary key(Id)
)

create table GDC_Cores_Externa(
	Id uniqueidentifier not null,
	Estilo char(1) not null,
	Valor decimal not null,

	Primary Key(Id)
)

create table GDC_Bancos(
	Id uniqueidentifier not null,
	Modelo char(1) not null,
	Multimidia bit not null,
	Cor varchar(10) not null,
	Valor decimal not null,
	IdUpload uniqueidentifier null FOREIGN KEY REFERENCES GDC_Uploads(Id),

	Primary key(Id)
)

create table GDC_Perfomances(
	Id uniqueidentifier not null,
	ValorTotal decimal not null,
	IdRoda uniqueidentifier null FOREIGN KEY REFERENCES GDC_Rodas(Id),
	IdBanco uniqueidentifier null FOREIGN KEY REFERENCES GDC_Bancos(Id),
	IdCliente uniqueidentifier null FOREIGN KEY REFERENCES GDC_Clientes(Id),
	IdCor uniqueidentifier null FOREIGN KEY REFERENCES GDC_Cores_Externa(Id),
	
	Primary Key(Id),
)

create table GDC_Veiculos(
	Id uniqueidentifier not null,
	Fabricante varchar(20) not null,
	Modelo varchar(20) not null,
	Ano datetime not null, 
	Valor decimal not null,
	Tipo char(1),
	IdUpload uniqueidentifier null FOREIGN KEY REFERENCES GDC_Uploads(Id),

	Primary key(Id)
)

create table GDC_Formas_Pagamentos(
	Id uniqueidentifier not null,
	Modelo varchar(30) not null,
	Tipo_Cliente char(1) not null,

	Primary Key(Id)
)

create table GDC_Vendas(
	Id uniqueidentifier not null,
	Valor decimal not null,
	Tipo_Entrega char(1) not null,
	Status char(1),
	Termo_Autorizacao bit not null,
	IdPerformance uniqueidentifier null FOREIGN KEY REFERENCES GDC_Perfomances(Id),
	IdCliente uniqueidentifier null FOREIGN KEY REFERENCES GDC_Clientes(Id),
	IdFormaPagamento uniqueidentifier null FOREIGN KEY REFERENCES GDC_Formas_Pagamentos(Id),
	IdVeiculo uniqueidentifier null FOREIGN KEY REFERENCES GDC_Veiculos(Id),

	Primary Key(Id)
)


--Senha igual a 123
insert into GDC_Logins(Id, Nome, SobreNome, Email, Senha, 
Data_Inclusao, DataNascimento, Tipo_Acesso)
values('61f87757-ac85-4929-8b79-acb7383cb457', 'Teste', 'GDCars', 'teste@gdcars.com', 
'20-2c-b9-62-ac-59-07-5b-96-4b-07-15-2d-23-4b-70', GETDATE(), GETDATE(), 1)