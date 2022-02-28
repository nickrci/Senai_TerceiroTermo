USE SpMedical;
GO

INSERT INTO tipoUsuario (tipoUsuario)
VALUES('Administrador'),('Médico'),('Cliente');
GO

INSERT INTO usuario (idTipoUsuario, email, senha)
VALUES
(1, 'fernandostrada@gmail.com', 'fernandostrada123'),
(3, 'ligia@gmail.com', 'ligia123'),
(3, 'alexandre@gmail.com', 'alexandre123'),
(3, 'fernando@gmail.com', 'fernando123'),
(3, 'henrique@gmail.com', 'henrique123'),
(3, 'joao@hotmail.com', 'joao123'),
(3, 'bruno@gmail.com', 'bruno123'),
(3, 'mariana@outlook.com', 'mariana123'),
(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardolemos123'),
(2, 'roberto.possarle@spmedicalgroup.com.br', 'robertopossarle123'),
(2, 'helena.souza@spmedicalgroup.com.br', 'helenasouza123');
GO

INSERT INTO cliente (idUsuario, nomeCliente, dataNascCliente, telefoneCliente, rgCliente, cpfCliente, enderecoCliente) 
VALUES
(2, 'Ligia', '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
(3, 'Alexandre', '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
(4, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
(5, 'Henrique', '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(6, 'João', '27/8/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
(7, 'Bruno', '21/3/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
(8, 'Mariana', '05/03/2018', null, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO especialidadeMedico (nomeEspecialidade)
VALUES
('Acupuntura'),
('Anestesiologia'),
('Angiologia'),
('Cardiologia'),
('Cirurgia Cardiovascular'),
('Cirurgia da Mão'),
('Cirurgia do aparelho digestivo'),
('Cirurgia geral'),
('Cirurgia pediátrica'),
('Cirurgia plástica'),
('Cirurgia torácica'),
('Cirurgia vascular'),
('Dermatologia'),
('Radioterapia'),
('Urologia'),
('Pediatria'),
('Psiquiatria');
GO

INSERT INTO clinica (enderecoClinica, horarioInicio, horarioFim, cnpj, nomeFantasia, razaoSocial)
VALUES
('Av. Barão Limeira, 532, São Paulo, SP', '08:00', '20:00', '86.400.902/0001-30', 'Clinica Possarle' , 'SP Medical Group')
GO

INSERT INTO medico (idUsuario, idEspecialidadeMedico, idClinica, crmMedico, nomeMedico)
VALUES 
(9, 2, 1, '54356-SP', 'Ricardo Lemos'),
(10, 17, 1,	'53452-SP',	'Roberto Possarle'),
(11, 16, 1,	'65463-SP',	'Helena Strada');
GO

INSERT INTO situacao (tipoSituacao)
VALUES 
('Agendada'),
('Realizada'),
('Cancelada');
GO

INSERT INTO consulta (idCliente, idMedico, idSituacao,	dataConsulta)
VALUES
(7,	3,	2,	'20/01/2020 15:00'),
(2,	2,	3,	'06/01/2020 10:00'),	
(3,	2,	2,	'07/02/2020 11:00'),	
(2,	2,	2,	'06/02/2018 10:00'),	
(4, 1,	3,	'07/02/2019 11:00'),	
(7,	3,	1,	'08/03/2020 15:00'),	
(4,	1,	1,	'09/03/2020 11:00');	
GO