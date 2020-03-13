create database dbTS;
use dbTS;
/*TABELA USUARIO*/
create table tbUsuario
(
	IdUsuario int auto_increment primary key,
	Cargo enum("Adm","Func","Geral")
);

/*TABELA LOGIN*/
create table tbLogin
(
	idLogin int auto_increment primary key,
	Usuario varchar(255),
    Senha int,
    Id_User int,
    constraint FK_IdUserLogin foreign key(Id_User) references tbUsuario(IdUsuario) ON UPDATE CASCADE ON DELETE CASCADE/*FOREIGN KEY*/
);

/*TABELA ENDEREÇO*/
create table tbEndereco
(
	IdEndereco int auto_increment primary key,
    CEP varchar(255),
	Rua varchar(255),
    Numero varchar(255),
    Bairro varchar(255),
    Logradouro varchar(255),
    Estado varchar(2),
    Pais varchar(255)
);

/*TABELA FUNCIONÁRIO*/
create table tbFuncionario
(
	idFunc int auto_increment primary key,
	NomeFunc varchar(255),
	Rt int,
    Cpf varchar(14),
    Rg varchar(12),
    Tel varchar(14),
    Email text,
    id_User int,    
    Id_End  int,
    constraint FK_IdEndFun foreign key(Id_End) references tbendereco(IdEndereco) ON UPDATE CASCADE ON DELETE CASCADE, /*FOREIGN KEY*/  
	constraint FK_IdUserFunc foreign key(Id_User) references tbUsuario(IdUsuario) ON UPDATE CASCADE ON DELETE CASCADE /*FOREIGN KEY*/        
);

/*TABELA EMPRESA*/
create table tbEmpresa
(
	IdEmpresa int auto_increment primary key,
    NomeEmpresa varchar(255),
    CNPJ varchar(255),
    Id_End  int,
    constraint FK_IdEndEmpresa foreign key(Id_End) references tbendereco(IdEndereco) ON UPDATE CASCADE ON DELETE CASCADE /*FOREIGN KEY*/    
);

/*CONTRATO*/
create table tbContrato
(
	IdContrato int auto_increment primary key,	
    Numero long,
    Descricao text,
    DataContrato varchar(10),
    Id_Emp int,
    constraint FK_IdEmpContrato foreign key(Id_Emp) references tbEmpresa(IdEmpresa) ON UPDATE CASCADE ON DELETE CASCADE /*FOREIGN KEY*/
);

/*TABELA SERVICO*/
create table tbServico
(
	IdServico int auto_increment primary key,    
    StatusServico Enum('Concluido','Andamento','Cancelado','Não Iniciado'),
    Id_Emp int,
    Id_Contrato int,
    Id_Func int,
    constraint FK_IdEmpServico foreign key(Id_Emp) references tbEmpresa(IdEmpresa) ON UPDATE CASCADE ON DELETE CASCADE,  /*FOREIGN KEY*/
    constraint FK_IdContratoServico foreign key(Id_Contrato) references tbContrato(IdContrato) ON UPDATE CASCADE ON DELETE CASCADE, /*FOREIGN KEY*/
    constraint FK_IdFuncServico foreign key(Id_Func) references tbFuncionario(idFunc) ON UPDATE CASCADE ON DELETE CASCADE /*FOREIGN KEY*/
);

/*TABELA RELATÓRIO*/
create table tbRelatorio
(
	IdRelatorio int auto_increment primary key,
    DataRelatorio date,
    HorasInicial time,
	HorasTermino time,
    Decricao text,
    AcompanhanteNome varchar(255),
	LocalAssinatura varchar(255),
    id_Servico int,
    constraint FK_IdServico foreign key(id_Servico) references tbServico(IdServico)  ON UPDATE CASCADE ON DELETE CASCADE /*FOREIGN KEY*/
);

-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*PROCEDURES*/ -- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- CADASTRO FUNCIONARIO
DELIMITER #
create procedure sp_CadastroFuncionario(SetUsuario varchar(255) , SetSenha varchar(255), SetRua varchar(255), SetNum varchar(255), 
				 SetBairro varchar(255), SetLogradouro varchar(255), SetEstado char(2), SetPais varchar(255), SetNome varchar(255),
                 SetRT int, SetCPF varchar(14), SetRG varchar(12), SetTel varchar(14), SetCEP varchar(255), SetEmail text)
begin
    insert tbusuario values(null,'Func');
    insert tblogin values(null, SetUsuario, SetSenha, (select MAX(IdUsuario) from tbUsuario));
    insert tbEndereco values(null, SetCEP, SetRua, SetNum, SetBairro, SetLogradouro, SetEstado, SetPais);
    insert tbfuncionario values(null, SetNome, SetRT, SetCPF, SetRG, SetTel, SetEmail, (select MAX(IdUsuario) from tbUsuario), (select MAX(IdEndereco) from tbendereco));	
end
#

-- CADASTRO EMPRESA
DELIMITER #
create procedure sp_CadastroEmpresa(SetEmpresaNome varchar(255), SetCNPJ varchar(18), SetCEP varchar(255), SetRua varchar(255), SetNum varchar(255), 
				 SetBairro varchar(255), SetLogradouro varchar(255), SetEstado char(2), SetPais varchar(255))
begin	
    insert tbEndereco values(null, SetCEP, SetRua, SetNum, SetBairro, SetLogradouro, SetEstado, SetPais);    
    insert tbempresa values(null, SetEmpresaNome, SetCNPJ, (select MAX(IdEndereco) from tbendereco)); 
end
#

-- CADASTRO ADIMINISTRADOR
DELIMITER #
create procedure sp_CadastroAdministrador(SetUsuario varchar(255) , SetSenha varchar(255), SetRua varchar(255), SetNum varchar(255), 
				 SetBairro varchar(255), SetLogradouro varchar(255), SetEstado char(2), SetPais varchar(255), SetNome varchar(255),
                 SetRT int, SetCPF varchar(14), SetRG varchar(12), SetTel varchar(14), SetCEP varchar(255), SetEmail text)
begin
    insert tbusuario values(null,'Adm');
    insert tblogin values(null, SetUsuario, SetSenha, (select MAX(IdUsuario) from tbUsuario));
    insert tbEndereco values(null, SetCEP, SetRua, SetNum, SetBairro, SetLogradouro, SetEstado, SetPais);
    insert tbfuncionario values(null, SetNome, SetRT, SetCPF, SetRG, SetTel, SetEmail, (select MAX(IdUsuario) from tbUsuario), (select MAX(IdEndereco) from tbendereco));	
end
#

-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- GET DADOS LOGIN
DELIMITER #
CREATE PROCEDURE sp_GetLogin(GetUser varchar(255))
BEGIN
	select Usuario,Senha,Id_User from tblogin where Usuario = GetUser;
END
#

-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- GET ALL DADOS LOGIN
DELIMITER #
CREATE PROCEDURE sp_GetDadosLogado(GetIDUser int)
BEGIN
	SELECT FUNC.* , ENDE.* , LOGIN.* , U.*
    FROM tbusuario U
    INNER JOIN tbfuncionario FUNC ON FUNC.id_User = U.IdUsuario
    INNER JOIN tbendereco ENDE ON ENDE.IdEndereco = FUNC.Id_End
    INNER JOIN tblogin  LOGIN ON LOGIN.Id_User = U.IdUsuario
    WHERE  U.IdUsuario = GetIDUser;    
END
#

-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- CADASTRA SERVIÇOS
DELIMITER #
CREATE PROCEDURE sp_SetServicosFunc(SetEmailFunc varchar(255), SetIDEmp int, SetNumContrato long, SetDescricao text, SetDataContrato varchar(10))
BEGIN
	insert tbcontrato values(null, SetNumContrato, SetDescricao, SetDataContrato, SetIDEmp);
    insert tbservico values(null, 'Não Iniciado', SetIDEmp , (select MAX(IdContrato) from tbcontrato), (Select idFunc from tbfuncionario where Email = SetEmailFunc));
END
#
-- GET SERVIÇOS
DELIMITER #
CREATE PROCEDURE sp_GetServicosFunc(GetIDFunc int)
BEGIN
	SELECT Servico.*, Contrato.*, EMP.*
    FROM tbservico Servico
    INNER JOIN tbcontrato Contrato ON Contrato.IdContrato = Servico.Id_Contrato
    INNER JOIN  tbempresa EMP ON EMP.IdEmpresa = Servico.Id_Emp        
    WHERE  Servico.Id_Func = GetIDFunc;    
END
#
 
 -- GET ALL EMPRESAS 
 select * from tbempresa;

-- GET ALL CONTRATO EMPRESA
DELIMITER #
CREATE PROCEDURE sp_GetAllContratoEmpresa(GetIdEmp int)
BEGIN
	SELECT Servico.*, Contrato.*
    FROM tbempresa EMP
    INNER JOIN tbservico Servico ON Servico.Id_Emp = EMP.IdEmpresa
    INNER JOIN tbcontrato Contrato ON Contrato.Id_Emp = EMP.IdEmpresa
    WHERE EMP.IdEmpresa = GetIdEmp;
END
#
 
 -- GET ALL DATA EMPRESA
 DELIMITER #
 CREATE PROCEDURE sp_GetAllDataEmpresa (GetIdEmp int)
BEGIN
	SELECT EMP.*, ENDE.*
    FROM tbempresa EMP
    INNER JOIN tbendereco ENDE ON ENDE.IdEndereco = EMP.Id_End
    WHERE EMP.IdEmpresa = GetIdEmp;
END
#  
 -- DELETAR EMPRESA
 DELIMITER #
 CREATE PROCEDURE sp_DeletarEmpresa(GetIdEmpresa int)
 BEGIN
	DELETE EMP.*, ENDE.*, Contrato.*
    FROM tbempresa EMP
    INNER JOIN tbendereco ENDE ON ENDE.IdEndereco = EMP.Id_End    
    INNER JOIN tbcontrato Contrato ON Contrato.Id_Emp = EMP.IdEmpresa
    WHERE EMP.IdEmpresa = GetIdEmpresa;
 END
 #
 
call dbts.sp_CadastroAdministrador('Adm@gmail.com', '1234', '1', '1', '1', '1', '1', '1', 'Henrique', 1, '1', '1', '1', '1', 'Adm@gmail.com');
call dbts.sp_CadastroFuncionario('Lucas@gmail.com', '1234', '111', '1', '1', '1', '1', '1', 'Lucas', 1, '1', '1', '1', '1', 'Lucas@gmail.com');
call dbts.sp_CadastroEmpresa('Microsofty S/A', '1', '1', '1', '1', '1', '1', '1', '1');
call dbts.sp_SetServicosFunc('Lucas@gmail.com', 1, '1', '1', '1');
insert into tbrelatorio values(null,'2020/02/10','13:00','14:00','nada','lucas', 'Av. Heiyor', 1);

