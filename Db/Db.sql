USE [master]
GO
/****** Object:  Database [DbTareas]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE DATABASE [DbTareas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbTareas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DbTareas.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DbTareas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DbTareas_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DbTareas] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbTareas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbTareas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbTareas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbTareas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbTareas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbTareas] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbTareas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DbTareas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbTareas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbTareas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbTareas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbTareas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbTareas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbTareas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbTareas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbTareas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbTareas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbTareas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbTareas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbTareas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbTareas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbTareas] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DbTareas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbTareas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DbTareas] SET  MULTI_USER 
GO
ALTER DATABASE [DbTareas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbTareas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbTareas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbTareas] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DbTareas] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DbTareas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CatalagoEstatus]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatalagoEstatus](
	[IdEstatus] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_CatalagoEstatus] PRIMARY KEY CLUSTERED 
(
	[IdEstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CatalagoTipoUsuarios]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatalagoTipoUsuarios](
	[IdTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_CatalagoTipoUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CategoriaTareas]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoriaTareas](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriaTareas] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estatus]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estatus](
	[IdEstatusUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED 
(
	[IdEstatusUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tareas](
	[IdTarea] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[FechaTerminacion] [date] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[IdTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/12/2021 02:13:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Fecha] [date] NOT NULL,
	[IdEstatusUsuario] [int] NOT NULL,
	[IdTipoUsuario] [int] NOT NULL,
	[Pass] [varchar](200) NOT NULL,
	[Salt] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211209165240_TareasV1.0', N'5.0.3')
SET IDENTITY_INSERT [dbo].[CatalagoEstatus] ON 

INSERT [dbo].[CatalagoEstatus] ([IdEstatus], [Nombre], [FechaCreacion]) VALUES (1, N'Asignada', CAST(N'2021-12-07' AS Date))
INSERT [dbo].[CatalagoEstatus] ([IdEstatus], [Nombre], [FechaCreacion]) VALUES (2, N'Terminada', CAST(N'2021-12-07' AS Date))
SET IDENTITY_INSERT [dbo].[CatalagoEstatus] OFF
SET IDENTITY_INSERT [dbo].[CatalagoTipoUsuarios] ON 

INSERT [dbo].[CatalagoTipoUsuarios] ([IdTipoUsuario], [Nombre], [FechaCreacion], [Estatus]) VALUES (1, N'Administrador', CAST(N'2021-12-07' AS Date), 1)
INSERT [dbo].[CatalagoTipoUsuarios] ([IdTipoUsuario], [Nombre], [FechaCreacion], [Estatus]) VALUES (2, N'Usuario', CAST(N'2021-12-07' AS Date), 1)
SET IDENTITY_INSERT [dbo].[CatalagoTipoUsuarios] OFF
SET IDENTITY_INSERT [dbo].[CategoriaTareas] ON 

INSERT [dbo].[CategoriaTareas] ([IdCategoria], [Nombre], [FechaCreacion], [Estatus]) VALUES (1, N'Trabajo', CAST(N'2021-12-07' AS Date), 1)
INSERT [dbo].[CategoriaTareas] ([IdCategoria], [Nombre], [FechaCreacion], [Estatus]) VALUES (2, N'Escuela', CAST(N'2021-12-07' AS Date), 1)
INSERT [dbo].[CategoriaTareas] ([IdCategoria], [Nombre], [FechaCreacion], [Estatus]) VALUES (3, N'Hogar', CAST(N'2021-12-07' AS Date), 1)
SET IDENTITY_INSERT [dbo].[CategoriaTareas] OFF
SET IDENTITY_INSERT [dbo].[Estatus] ON 

INSERT [dbo].[Estatus] ([IdEstatusUsuario], [Nombre]) VALUES (1, N'Activo')
INSERT [dbo].[Estatus] ([IdEstatusUsuario], [Nombre]) VALUES (2, N'Inactivo')
SET IDENTITY_INSERT [dbo].[Estatus] OFF
SET IDENTITY_INSERT [dbo].[Tareas] ON 

INSERT [dbo].[Tareas] ([IdTarea], [Nombre], [IdUsuario], [FechaCreacion], [FechaTerminacion], [IdStatus], [IdCategoria]) VALUES (1, N'Creacion de Modulos', 2, CAST(N'2021-12-09' AS Date), CAST(N'2021-12-09' AS Date), 1, 1)
INSERT [dbo].[Tareas] ([IdTarea], [Nombre], [IdUsuario], [FechaCreacion], [FechaTerminacion], [IdStatus], [IdCategoria]) VALUES (2, N'Depuracion DB', 1, CAST(N'2021-12-09' AS Date), CAST(N'0001-01-01' AS Date), 1, 2)
INSERT [dbo].[Tareas] ([IdTarea], [Nombre], [IdUsuario], [FechaCreacion], [FechaTerminacion], [IdStatus], [IdCategoria]) VALUES (3, N'Clean up', 2, CAST(N'2021-12-09' AS Date), CAST(N'2021-12-09' AS Date), 1, 3)
SET IDENTITY_INSERT [dbo].[Tareas] OFF
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Email], [Nombre], [Fecha], [IdEstatusUsuario], [IdTipoUsuario], [Pass], [Salt]) VALUES (1, N'sergio@sergio.com', N'Sergio Bautista', CAST(N'2021-12-09' AS Date), 1, 2, N'T4bnP+XuoJFYw9KDF/QFnTJ0aDVdrRIIWridwEJdv5g=', N'Mz+kjhHVLpi47e75LI6l6A==')
INSERT [dbo].[Usuarios] ([IdUsuario], [Email], [Nombre], [Fecha], [IdEstatusUsuario], [IdTipoUsuario], [Pass], [Salt]) VALUES (2, N'wales111_u@hotmail.com', N'Miguel Angel Tavares Olivares', CAST(N'2021-12-09' AS Date), 1, 1, N'nfUd1qpybfeqSgslyuR0fmkditPdxLayvkyM0kQJUkk=', N'xec43bcGnH6SmKNYtaAOiQ==')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
/****** Object:  Index [IX_Tareas_IdCategoria]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Tareas_IdCategoria] ON [dbo].[Tareas]
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tareas_IdStatus]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Tareas_IdStatus] ON [dbo].[Tareas]
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tareas_IdUsuario]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Tareas_IdUsuario] ON [dbo].[Tareas]
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdEstatusUsuario]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_IdEstatusUsuario] ON [dbo].[Usuarios]
(
	[IdEstatusUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Usuarios_IdTipoUsuario]    Script Date: 09/12/2021 02:13:14 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_IdTipoUsuario] ON [dbo].[Usuarios]
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_CatalagoEstatus] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[CatalagoEstatus] ([IdEstatus])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_CatalagoEstatus]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_CategoriaTareas] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CategoriaTareas] ([IdCategoria])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_CategoriaTareas]
GO
ALTER TABLE [dbo].[Tareas]  WITH CHECK ADD  CONSTRAINT [FK_Tareas_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tareas] CHECK CONSTRAINT [FK_Tareas_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_CatalagoTipoUsuarios] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[CatalagoTipoUsuarios] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_CatalagoTipoUsuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Estatus] FOREIGN KEY([IdEstatusUsuario])
REFERENCES [dbo].[Estatus] ([IdEstatusUsuario])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Estatus]
GO
USE [master]
GO
ALTER DATABASE [DbTareas] SET  READ_WRITE 
GO
