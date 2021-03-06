USE [master]
GO
/****** Object:  Database [VideoClub]    Script Date: 19/11/2020 23:35:20 ******/
CREATE DATABASE [VideoClub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoClub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VideoClub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideoClub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\VideoClub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VideoClub] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoClub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoClub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoClub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoClub] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoClub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoClub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoClub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoClub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoClub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoClub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoClub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoClub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideoClub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoClub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoClub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoClub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoClub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoClub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoClub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoClub] SET RECOVERY FULL 
GO
ALTER DATABASE [VideoClub] SET  MULTI_USER 
GO
ALTER DATABASE [VideoClub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoClub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoClub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoClub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideoClub] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'VideoClub', N'ON'
GO
ALTER DATABASE [VideoClub] SET QUERY_STORE = OFF
GO
USE [VideoClub]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[CalificacionId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[CalificacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[EstadoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[EstadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Generos]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Generos](
	[GeneroId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[GeneroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[NombreLocalidad] [nvarchar](100) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[PeliculaId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](250) NOT NULL,
	[GeneroId] [int] NOT NULL,
	[FechaIncorporacion] [datetime] NOT NULL,
	[EstadoId] [int] NOT NULL,
	[DurancionEnMinutos] [int] NOT NULL,
	[CalificacionId] [int] NOT NULL,
	[Alquilado] [bit] NULL,
	[Activa] [bit] NULL,
	[Observaciones] [nvarchar](max) NULL,
	[SoporteId] [int] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[PeliculaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[CUIT] [nvarchar](13) NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[PersonaDeContacto] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socios](
	[SocioId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](150) NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Sancionado] [bit] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Socios] PRIMARY KEY CLUSTERED 
(
	[SocioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soportes]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soportes](
	[SoporteId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TiposSoportes] PRIMARY KEY CLUSTERED 
(
	[SoporteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDocumentos]    Script Date: 19/11/2020 23:35:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDocumentos](
	[TipoDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED 
(
	[TipoDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Calificaciones] ON 

INSERT [dbo].[Calificaciones] ([CalificacionId], [Descripcion]) VALUES (1, N'ATP')
INSERT [dbo].[Calificaciones] ([CalificacionId], [Descripcion]) VALUES (2, N'Mayores de 12 años')
SET IDENTITY_INSERT [dbo].[Calificaciones] OFF
SET IDENTITY_INSERT [dbo].[Estados] ON 

INSERT [dbo].[Estados] ([EstadoId], [Descripcion]) VALUES (2, N'Bueno')
INSERT [dbo].[Estados] ([EstadoId], [Descripcion]) VALUES (3, N'Regular')
INSERT [dbo].[Estados] ([EstadoId], [Descripcion]) VALUES (4, N'Malo')
INSERT [dbo].[Estados] ([EstadoId], [Descripcion]) VALUES (8, N'Muy Bueno')
SET IDENTITY_INSERT [dbo].[Estados] OFF
SET IDENTITY_INSERT [dbo].[Generos] ON 

INSERT [dbo].[Generos] ([GeneroId], [Descripcion]) VALUES (1, N'Comedia')
INSERT [dbo].[Generos] ([GeneroId], [Descripcion]) VALUES (2, N'Drama')
INSERT [dbo].[Generos] ([GeneroId], [Descripcion]) VALUES (3, N'Suspenso')
INSERT [dbo].[Generos] ([GeneroId], [Descripcion]) VALUES (4, N'Accion')
INSERT [dbo].[Generos] ([GeneroId], [Descripcion]) VALUES (5, N'Terror')
SET IDENTITY_INSERT [dbo].[Generos] OFF
SET IDENTITY_INSERT [dbo].[Localidades] ON 

INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (2, N'Roque Perez', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (3, N'Lobos', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (13, N'Monte', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (15, N'Cañuelas', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (16, N'Rosario ', 9)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (18, N'Saladillo', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (21, N'Resistencia', 10)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (23, N'San Roque', 10)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (24, N'Azul', 1)
INSERT [dbo].[Localidades] ([LocalidadId], [NombreLocalidad], [ProvinciaId]) VALUES (25, N'Cazon', 1)
SET IDENTITY_INSERT [dbo].[Localidades] OFF
SET IDENTITY_INSERT [dbo].[Peliculas] ON 

INSERT [dbo].[Peliculas] ([PeliculaId], [Titulo], [GeneroId], [FechaIncorporacion], [EstadoId], [DurancionEnMinutos], [CalificacionId], [Alquilado], [Activa], [Observaciones], [SoporteId]) VALUES (1, N'Terminator 2', 4, CAST(N'2004-08-09T00:00:00.000' AS DateTime), 2, 156, 2, 0, 1, NULL, 1)
INSERT [dbo].[Peliculas] ([PeliculaId], [Titulo], [GeneroId], [FechaIncorporacion], [EstadoId], [DurancionEnMinutos], [CalificacionId], [Alquilado], [Activa], [Observaciones], [SoporteId]) VALUES (3, N'Terminator 3', 4, CAST(N'2004-09-10T00:00:00.000' AS DateTime), 2, 161, 2, 1, 0, NULL, 1)
INSERT [dbo].[Peliculas] ([PeliculaId], [Titulo], [GeneroId], [FechaIncorporacion], [EstadoId], [DurancionEnMinutos], [CalificacionId], [Alquilado], [Activa], [Observaciones], [SoporteId]) VALUES (4, N'Titanic', 3, CAST(N'2000-11-24T00:00:00.000' AS DateTime), 3, 210, 1, 0, 1, NULL, 2)
SET IDENTITY_INSERT [dbo].[Peliculas] OFF
SET IDENTITY_INSERT [dbo].[Provincias] ON 

INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (9, N'Santa Fe')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (10, N'Chaco')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (12, N'Neuquen')
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (13, N'Jujuy')
SET IDENTITY_INSERT [dbo].[Provincias] OFF
SET IDENTITY_INSERT [dbo].[Soportes] ON 

INSERT [dbo].[Soportes] ([SoporteId], [Descripcion]) VALUES (1, N'DVD')
INSERT [dbo].[Soportes] ([SoporteId], [Descripcion]) VALUES (2, N'Blue-Ray')
INSERT [dbo].[Soportes] ([SoporteId], [Descripcion]) VALUES (6, N'Blue-Ray 3D')
SET IDENTITY_INSERT [dbo].[Soportes] OFF
SET IDENTITY_INSERT [dbo].[TiposDocumentos] ON 

INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [Descripcion]) VALUES (1, N'DNI')
INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [Descripcion]) VALUES (2, N'LC')
INSERT [dbo].[TiposDocumentos] ([TipoDocumentoId], [Descripcion]) VALUES (3, N'LE')
SET IDENTITY_INSERT [dbo].[TiposDocumentos] OFF
ALTER TABLE [dbo].[Peliculas] ADD  CONSTRAINT [DF_Peliculas_Alquilado]  DEFAULT ((0)) FOR [Alquilado]
GO
ALTER TABLE [dbo].[Peliculas] ADD  CONSTRAINT [DF_Peliculas_Activa]  DEFAULT ((1)) FOR [Activa]
GO
ALTER TABLE [dbo].[Socios] ADD  CONSTRAINT [DF_Socios_Sancionado]  DEFAULT ((0)) FOR [Sancionado]
GO
ALTER TABLE [dbo].[Socios] ADD  CONSTRAINT [DF_Socios_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Provincias]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_TiposDocumentos] FOREIGN KEY([TipoDocumentoId])
REFERENCES [dbo].[TiposDocumentos] ([TipoDocumentoId])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_TiposDocumentos]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Calificaciones] FOREIGN KEY([CalificacionId])
REFERENCES [dbo].[Calificaciones] ([CalificacionId])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Calificaciones]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Estados] FOREIGN KEY([EstadoId])
REFERENCES [dbo].[Estados] ([EstadoId])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Estados]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Generos] FOREIGN KEY([GeneroId])
REFERENCES [dbo].[Generos] ([GeneroId])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_Generos]
GO
ALTER TABLE [dbo].[Peliculas]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_TiposSoportes] FOREIGN KEY([SoporteId])
REFERENCES [dbo].[Soportes] ([SoporteId])
GO
ALTER TABLE [dbo].[Peliculas] CHECK CONSTRAINT [FK_Peliculas_TiposSoportes]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Localidades]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD  CONSTRAINT [FK_Proveedores_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Proveedores] CHECK CONSTRAINT [FK_Proveedores_Provincias]
GO
ALTER TABLE [dbo].[Socios]  WITH CHECK ADD  CONSTRAINT [FK_Socios_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Socios] CHECK CONSTRAINT [FK_Socios_Localidades]
GO
ALTER TABLE [dbo].[Socios]  WITH CHECK ADD  CONSTRAINT [FK_Socios_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Socios] CHECK CONSTRAINT [FK_Socios_Provincias]
GO
USE [master]
GO
ALTER DATABASE [VideoClub] SET  READ_WRITE 
GO
