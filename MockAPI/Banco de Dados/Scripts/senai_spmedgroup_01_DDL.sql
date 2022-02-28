create database SpMedical;
GO

USE SpMedical;
GO

CREATE TABLE tipoUsuario(
   idTipoUsuario smallint PRIMARY KEY IDENTITY(1,1),
   tipoUsuario varchar(20) unique,
);
go

CREATE TABLE usuario(
   idUsuario smallint PRIMARY KEY IDENTITY(1,1),
   idTipoUsuario smallint FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario) not null,
   email varchar(100) unique not null,
   senha varchar(50) not null,
);
go

CREATE TABLE cliente(
   idCliente smallint PRIMARY KEY IDENTITY(1,1),
   idUsuario smallint FOREIGN KEY REFERENCES usuario(idUsuario) unique not null,
   nomeCliente varchar(75) not null,
   dataNascCliente date unique not null,
   telefoneCliente varchar(15),
   rgCliente varchar(10) unique not null,
   cpfCliente varchar(14) unique not null,
   enderecoCliente varchar(100)
);
go

CREATE TABLE especialidadeMedico(
   idEspecialidadeMedico smallint PRIMARY KEY IDENTITY(1,1),
   nomeEspecialidade varchar(100) unique not null
);
go

CREATE TABLE clinica(
   idClinica smallint PRIMARY KEY IDENTITY(1,1),
   enderecoClinica varchar(100) not null,
   horarioInicio time,
   horarioFim time,
   cnpj char(20) unique not null, 
   nomeFantasia varchar(100) not null,
   razaoSocial varchar(50) unique not null,
);
go

CREATE TABLE medico(
   idMedico smallint PRIMARY KEY IDENTITY(1,1),
   idUsuario smallint FOREIGN KEY REFERENCES usuario(idUsuario) unique not null,
   idEspecialidadeMedico smallint FOREIGN KEY REFERENCES especialidadeMedico(idEspecialidadeMedico) not null,
   idClinica smallint FOREIGN KEY REFERENCES clinica(idClinica) not null,
   crmMedico varchar(10) unique not null,
   nomeMedico varchar(75) not null
);
go

CREATE TABLE situacao(
   idSituacao smallint PRIMARY KEY IDENTITY(1,1),
   tipoSituacao varchar(50) not null
);
go

CREATE TABLE consulta(
   idConsulta smallint PRIMARY KEY IDENTITY(1,1),
   idCliente smallint FOREIGN KEY REFERENCES cliente(idCliente) not null,
   idMedico smallint FOREIGN KEY REFERENCES medico(idMedico) not null,
   idSituacao smallint FOREIGN KEY REFERENCES situacao(idSituacao) not null,
   dataConsulta date not null,
   descricaoConsulta varchar(1000)
);
go