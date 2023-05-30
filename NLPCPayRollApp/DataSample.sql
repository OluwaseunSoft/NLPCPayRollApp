USE [master]
GO
/****** Object:  Database [NlpcPayrollDb]    Script Date: 30/05/2023 05:58:01 ******/
CREATE DATABASE [NlpcPayrollDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NlpcPayrollDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NlpcPayrollDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NlpcPayrollDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NlpcPayrollDb_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NlpcPayrollDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NlpcPayrollDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NlpcPayrollDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NlpcPayrollDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NlpcPayrollDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NlpcPayrollDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NlpcPayrollDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET RECOVERY FULL 
GO
ALTER DATABASE [NlpcPayrollDb] SET  MULTI_USER 
GO
ALTER DATABASE [NlpcPayrollDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NlpcPayrollDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NlpcPayrollDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NlpcPayrollDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [NlpcPayrollDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30/05/2023 05:58:01 ******/
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
/****** Object:  Table [dbo].[CadreLevels]    Script Date: 30/05/2023 05:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CadreLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_CadreLevels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 30/05/2023 05:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Designation] [nvarchar](max) NOT NULL,
	[CadreLevelName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollComponents]    Script Date: 30/05/2023 05:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollComponents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BasicSalary] [float] NOT NULL,
	[Housing] [float] NOT NULL,
	[Transport] [float] NOT NULL,
	[Furniture] [float] NOT NULL,
	[Entertainment] [float] NOT NULL,
	[Lunch] [float] NOT NULL,
	[Passage] [float] NOT NULL,
	[Dressing] [float] NOT NULL,
	[Bonus] [float] NOT NULL,
	[ThirteenthMonth] [float] NOT NULL,
	[Utility] [float] NOT NULL,
	[OtherAllowances] [float] NOT NULL,
	[NHF] [float] NOT NULL,
	[NHIS] [float] NOT NULL,
	[NPS] [float] NOT NULL,
	[LifeAssurance] [float] NOT NULL,
	[GrossIncome] [float] NOT NULL,
	[TaxPayable] [float] NOT NULL,
	[CadreLevelId] [int] NOT NULL,
 CONSTRAINT [PK_PayrollComponents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230529163921_payroll', N'7.0.5')
GO
SET IDENTITY_INSERT [dbo].[CadreLevels] ON 
GO
INSERT [dbo].[CadreLevels] ([Id], [Name]) VALUES (1, N'Manager')
GO
INSERT [dbo].[CadreLevels] ([Id], [Name]) VALUES (2, N'Senior Manager')
GO
INSERT [dbo].[CadreLevels] ([Id], [Name]) VALUES (3, N'Principal Manager')
GO
SET IDENTITY_INSERT [dbo].[CadreLevels] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 
GO
INSERT [dbo].[Employees] ([Id], [Name], [Designation], [CadreLevelName]) VALUES (1, N'Mark Johnson', N'Office Administrator', N'Manager')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Designation], [CadreLevelName]) VALUES (2, N'Closeby Joel', N'Business Developer', N'Senior Manager')
GO
INSERT [dbo].[Employees] ([Id], [Name], [Designation], [CadreLevelName]) VALUES (3, N'Goodwill Kunle', N'Business Manager', N'Principal Manager')
GO
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[PayrollComponents] ON 
GO
INSERT [dbo].[PayrollComponents] ([Id], [BasicSalary], [Housing], [Transport], [Furniture], [Entertainment], [Lunch], [Passage], [Dressing], [Bonus], [ThirteenthMonth], [Utility], [OtherAllowances], [NHF], [NHIS], [NPS], [LifeAssurance], [GrossIncome], [TaxPayable], [CadreLevelId]) VALUES (1, 10500, 5250, 5250, 6300, 2100, 4200, 6300, 0, 0, 0, 0, 0, 0, 0, 3780, 378, 42000, 156, 1)
GO
INSERT [dbo].[PayrollComponents] ([Id], [BasicSalary], [Housing], [Transport], [Furniture], [Entertainment], [Lunch], [Passage], [Dressing], [Bonus], [ThirteenthMonth], [Utility], [OtherAllowances], [NHF], [NHIS], [NPS], [LifeAssurance], [GrossIncome], [TaxPayable], [CadreLevelId]) VALUES (2, 12500, 6250, 6250, 7500, 5000, 5000, 7500, 0, 0, 0, 0, 0, 0, 0, 4500, 450, 50000, 217, 2)
GO
INSERT [dbo].[PayrollComponents] ([Id], [BasicSalary], [Housing], [Transport], [Furniture], [Entertainment], [Lunch], [Passage], [Dressing], [Bonus], [ThirteenthMonth], [Utility], [OtherAllowances], [NHF], [NHIS], [NPS], [LifeAssurance], [GrossIncome], [TaxPayable], [CadreLevelId]) VALUES (4, 21000, 8750, 8750, 10500, 3500, 7000, 10500, 0, 0, 0, 0, 0, 0, 0, 6930, 693, 70000, 295, 3)
GO
SET IDENTITY_INSERT [dbo].[PayrollComponents] OFF
GO
/****** Object:  Index [IX_PayrollComponents_CadreLevelId]    Script Date: 30/05/2023 05:58:05 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PayrollComponents_CadreLevelId] ON [dbo].[PayrollComponents]
(
	[CadreLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PayrollComponents]  WITH CHECK ADD  CONSTRAINT [FK_PayrollComponents_CadreLevels_CadreLevelId] FOREIGN KEY([CadreLevelId])
REFERENCES [dbo].[CadreLevels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PayrollComponents] CHECK CONSTRAINT [FK_PayrollComponents_CadreLevels_CadreLevelId]
GO
USE [master]
GO
ALTER DATABASE [NlpcPayrollDb] SET  READ_WRITE 
GO
