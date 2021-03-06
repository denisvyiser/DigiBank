USE [master]
GO
/****** Object:  Database [DigiBank]    Script Date: 31/12/2018 15:22:43 ******/
CREATE DATABASE [DigiBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DigiBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DigiBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DigiBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DigiBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DigiBank] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DigiBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DigiBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DigiBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DigiBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DigiBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DigiBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [DigiBank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DigiBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DigiBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DigiBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DigiBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DigiBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DigiBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DigiBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DigiBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DigiBank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DigiBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DigiBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DigiBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DigiBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DigiBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DigiBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DigiBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DigiBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DigiBank] SET  MULTI_USER 
GO
ALTER DATABASE [DigiBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DigiBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DigiBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DigiBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DigiBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DigiBank] SET QUERY_STORE = OFF
GO
USE [DigiBank]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DigiBank]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 31/12/2018 15:22:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](10) NOT NULL,
	[Senha] [nvarchar](24) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientePerfil]    Script Date: 31/12/2018 15:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientePerfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[PerfilId] [int] NOT NULL,
 CONSTRAINT [PK_ClientePerfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContaCorrente]    Script Date: 31/12/2018 15:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContaCorrente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](5) NOT NULL,
	[Saldo] [numeric](18, 2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_ContaCorrente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 31/12/2018 15:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Token]    Script Date: 31/12/2018 15:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[TokenKey] [nvarchar](710) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
	[DataExpira] [datetime] NOT NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacao]    Script Date: 31/12/2018 15:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContaOrigem] [int] NOT NULL,
	[ContaDestino] [int] NOT NULL,
	[Valor] [numeric](18, 2) NOT NULL,
	[CodigoAutenticacao] [nvarchar](15) NOT NULL,
	[DataTransacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Nome], [Login], [Senha]) VALUES (1, N'Administrador', N'admin', N'bC/vUherSx+xBJYJcttUpw==')
INSERT [dbo].[Cliente] ([Id], [Nome], [Login], [Senha]) VALUES (2, N'Denis', N'denis', N'bC/vUherSx+xBJYJcttUpw==')
INSERT [dbo].[Cliente] ([Id], [Nome], [Login], [Senha]) VALUES (3, N'Marcos', N'marcos', N'bC/vUherSx+xBJYJcttUpw==')
INSERT [dbo].[Cliente] ([Id], [Nome], [Login], [Senha]) VALUES (4, N'Antonio', N'antonio', N'bC/vUherSx+xBJYJcttUpw==')
INSERT [dbo].[Cliente] ([Id], [Nome], [Login], [Senha]) VALUES (5, N'Roberto', N'roberto', N'bC/vUherSx+xBJYJcttUpw==')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[ClientePerfil] ON 

INSERT [dbo].[ClientePerfil] ([Id], [ClienteId], [PerfilId]) VALUES (1, 1, 1)
INSERT [dbo].[ClientePerfil] ([Id], [ClienteId], [PerfilId]) VALUES (2, 2, 3)
INSERT [dbo].[ClientePerfil] ([Id], [ClienteId], [PerfilId]) VALUES (3, 3, 3)
INSERT [dbo].[ClientePerfil] ([Id], [ClienteId], [PerfilId]) VALUES (4, 4, 3)
INSERT [dbo].[ClientePerfil] ([Id], [ClienteId], [PerfilId]) VALUES (5, 5, 3)
SET IDENTITY_INSERT [dbo].[ClientePerfil] OFF
SET IDENTITY_INSERT [dbo].[ContaCorrente] ON 

INSERT [dbo].[ContaCorrente] ([Id], [Numero], [Saldo], [DataCadastro], [ClienteId]) VALUES (1, N'12345', CAST(10.10 AS Numeric(18, 2)), CAST(N'2018-12-31T14:36:37.907' AS DateTime), 2)
INSERT [dbo].[ContaCorrente] ([Id], [Numero], [Saldo], [DataCadastro], [ClienteId]) VALUES (2, N'12346', CAST(400.30 AS Numeric(18, 2)), CAST(N'2018-12-31T14:36:56.290' AS DateTime), 3)
INSERT [dbo].[ContaCorrente] ([Id], [Numero], [Saldo], [DataCadastro], [ClienteId]) VALUES (3, N'12322', CAST(1000.10 AS Numeric(18, 2)), CAST(N'2018-12-31T14:37:09.310' AS DateTime), 4)
INSERT [dbo].[ContaCorrente] ([Id], [Numero], [Saldo], [DataCadastro], [ClienteId]) VALUES (4, N'12321', CAST(1249.60 AS Numeric(18, 2)), CAST(N'2018-12-31T14:37:29.200' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[ContaCorrente] OFF
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (1, N'Gerente')
INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (2, N'Analista')
INSERT [dbo].[Perfil] ([Id], [Descricao]) VALUES (3, N'Cliente')
SET IDENTITY_INSERT [dbo].[Perfil] OFF
SET IDENTITY_INSERT [dbo].[Token] ON 

INSERT [dbo].[Token] ([Id], [ClienteId], [TokenKey], [DataCriacao], [DataExpira]) VALUES (1, 1, N'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJhZG1pbiIsImFkbWluIl0sImp0aSI6IjU3NjgyZGRlYzAzMzQ0MDdhOGEyODZjNjQ4NzEzMDhhIiwiQ2xpZW50ZUlkIjoiMSIsInJvbGUiOiJHZXJlbnRlIiwibmJmIjoxNTQ2Mjc0MzQ5LCJleHAiOjE1NDYyNzYxNDksImlhdCI6MTU0NjI3NDM0OSwiaXNzIjoiRGlnaUJhbmsgSWRlbnRpdHkiLCJhdWQiOiJEaWdpQmFuayJ9.Ru4-oXdWcLEwszMhmKbhKwuFps6fmDBu3lp70qN50BZwl2HdIxndf8ML7QauQAh8G1FhWp-J9o1QQvfSsZwZ6Z0HBZD1ltkH-9sBcCi6WOTx7ZRzJ_ZRKNo42s8-UKBNrqvF7Wo8caunmo3RpapZhY1d9z5AiJ9GHWpit1RZH2twvIDTGO0tygRaCPDmxKLdZ8f9jS9pAu4eceM4ZZAkmeDuahkGWjCde9Jvtabwr6k3PpDwh5H1AzeO18npm4nCVWuJbmtp71oSw0uVAbEoRcYXGqGVPPSSd2_H4MkJAgifXvOVgnrH1o4FJL1qZ_3n9Z0VFb8n835fGEJG3ENMDQ', CAST(N'2018-12-31T14:39:09.670' AS DateTime), CAST(N'2018-12-31T15:09:09.670' AS DateTime))
INSERT [dbo].[Token] ([Id], [ClienteId], [TokenKey], [DataCriacao], [DataExpira]) VALUES (2, 2, N'eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJkZW5pcyIsImRlbmlzIl0sImp0aSI6IjE0ZThmZTJjZWVjMjQyNGViYmIwMDc0ZjUxYTlkNDRhIiwiQ2xpZW50ZUlkIjoiMiIsInJvbGUiOiJDbGllbnRlIiwibmJmIjoxNTQ2Mjc2NTk4LCJleHAiOjE1NDYyNzgzOTgsImlhdCI6MTU0NjI3NjU5OCwiaXNzIjoiRGlnaUJhbmsgSWRlbnRpdHkiLCJhdWQiOiJEaWdpQmFuayJ9.jBtfJoP9XpA4UGSvpJbpBABvPxuxsUJ5ArJic15oTk9Qs5eqd7V2sI2RAqPQWYQAnnPWkSC2VFYvH7NKkQajrF_zZiwiKDJEkKN3XupFyjbvha_TQWQMrkvMYp-djafPNHBKiVuIFUlkErsSUhF00IQ0jpW78Qh7M5qLuKtCi-sBiCvPglh2ix_SL4L4dZGtTX0n0CHaGmHa0JOpTWFxArpdIEGPiReqjFIN8BIKWvpaOFgrjt5UF76BQHy0pFucVaH5T9jX9SeHSz8ejKl5TkLMI6h9mkfTgMmwbPrwlaP2V95nS-5GmjN_DkpY7ttzaXscRh9pCSUNvWOb1JIhTw', CAST(N'2018-12-31T15:16:38.193' AS DateTime), CAST(N'2018-12-31T15:46:38.193' AS DateTime))
SET IDENTITY_INSERT [dbo].[Token] OFF
SET IDENTITY_INSERT [dbo].[Transacao] ON 

INSERT [dbo].[Transacao] ([Id], [ContaOrigem], [ContaDestino], [Valor], [CodigoAutenticacao], [DataTransacao]) VALUES (1, 4, 4, CAST(150.10 AS Numeric(18, 2)), N'O3QETGEE1SAZ6CH', CAST(N'2018-12-31T14:43:06.790' AS DateTime))
INSERT [dbo].[Transacao] ([Id], [ContaOrigem], [ContaDestino], [Valor], [CodigoAutenticacao], [DataTransacao]) VALUES (2, 4, 2, CAST(150.10 AS Numeric(18, 2)), N'0M779DUSUGFFTOF', CAST(N'2018-12-31T14:45:41.713' AS DateTime))
INSERT [dbo].[Transacao] ([Id], [ContaOrigem], [ContaDestino], [Valor], [CodigoAutenticacao], [DataTransacao]) VALUES (3, 4, 2, CAST(150.10 AS Numeric(18, 2)), N'E4GX09ZWRNI9ZE4', CAST(N'2018-12-31T14:46:26.940' AS DateTime))
INSERT [dbo].[Transacao] ([Id], [ContaOrigem], [ContaDestino], [Valor], [CodigoAutenticacao], [DataTransacao]) VALUES (4, 4, 2, CAST(150.10 AS Numeric(18, 2)), N'9LJMOO7Y39RVXOP', CAST(N'2018-12-31T14:50:20.600' AS DateTime))
INSERT [dbo].[Transacao] ([Id], [ContaOrigem], [ContaDestino], [Valor], [CodigoAutenticacao], [DataTransacao]) VALUES (5, 4, 2, CAST(150.10 AS Numeric(18, 2)), N'AFX5PSXXGPWFGL6', CAST(N'2018-12-31T15:17:20.310' AS DateTime))
SET IDENTITY_INSERT [dbo].[Transacao] OFF
ALTER TABLE [dbo].[ClientePerfil]  WITH CHECK ADD  CONSTRAINT [FK_ClientePerfil_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[ClientePerfil] CHECK CONSTRAINT [FK_ClientePerfil_Cliente]
GO
ALTER TABLE [dbo].[ClientePerfil]  WITH CHECK ADD  CONSTRAINT [FK_ClientePerfil_Perfil] FOREIGN KEY([PerfilId])
REFERENCES [dbo].[Perfil] ([Id])
GO
ALTER TABLE [dbo].[ClientePerfil] CHECK CONSTRAINT [FK_ClientePerfil_Perfil]
GO
ALTER TABLE [dbo].[ContaCorrente]  WITH CHECK ADD  CONSTRAINT [FK_ContaCorrente_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[ContaCorrente] CHECK CONSTRAINT [FK_ContaCorrente_Cliente]
GO
ALTER TABLE [dbo].[Token]  WITH CHECK ADD  CONSTRAINT [FK_Token_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Token] CHECK CONSTRAINT [FK_Token_Cliente]
GO
ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Cliente_ContaDestino] FOREIGN KEY([ContaDestino])
REFERENCES [dbo].[ContaCorrente] ([Id])
GO
ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Cliente_ContaDestino]
GO
ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Cliente_ContaOrigem] FOREIGN KEY([ContaOrigem])
REFERENCES [dbo].[ContaCorrente] ([Id])
GO
ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Cliente_ContaOrigem]
GO
USE [master]
GO
ALTER DATABASE [DigiBank] SET  READ_WRITE 
GO
