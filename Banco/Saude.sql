Create Database Saudeplus;

use Saudeplus;

drop table tblClientes;

Create table tblFunc(
	codigoFunc int primary key not null,
    nome varchar(40),
    senha varchar(4));
    
Create table tblClientes(
	codCli int primary key not null,
    cli_nome varchar(40),
    cli_cpf varchar(40),
    cli_rg varchar(40),
    cli_telefone varchar(40),
    cli_celular varchar(40),
    cli_rua varchar(80),
    cli_cep varchar(40),
    cli_bairro varchar(60),
    cli_cidade varchar(60),
    cli_estado varchar(35),
    cli_email varchar(70),
    cli_sexo varchar(40));



select * from tblFunc;
select * from tblClientes;