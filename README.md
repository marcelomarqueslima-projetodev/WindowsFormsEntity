CRUD C# WINDOWS FORMS com o ORM EntityFramework e SQL Server.

Utilizando o Docker:

Obtendo a imagem => docker pull mcr.microsoft.com/mssql/server

Rodando o SQL Server=> docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SuaSenha" -p 1433:1433 -d mcr.microsoft.com/mssql/server

connection string => data source=localhost,1433;initial catalog=SuaDatabase;User ID=sa;Password=SuaSenha;

Quando estiver com o SQL Server Local basta entrar SQL Server Management Studio e pegar as configurações de servidor e senha criado na instalação.

![image](https://user-images.githubusercontent.com/72136257/141782452-5bd8e455-038b-4c0b-b8c0-1bc9288e6c46.png)



Criando banco de Dados

USE [master]
GO

CREATE DATABASE [efdb]
GO

CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Sobrenome] [varchar](250) NOT NULL,
	[Cidade] [varchar](250) NOT NULL,
	[Endereco] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

Com o banco criado e só executar a aplicação.
