USE [GraphQLSampleApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25-05-2022 15:05:20 ******/
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
/****** Object:  Table [dbo].[commands]    Script Date: 25-05-2022 15:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[commands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HowTo] [nvarchar](max) NOT NULL,
	[CommandLine] [nvarchar](max) NOT NULL,
	[PlatformId] [int] NOT NULL,
 CONSTRAINT [PK_commands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Platforms]    Script Date: 25-05-2022 15:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Platforms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LicenseKey] [nvarchar](max) NULL,
 CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521122315_Initial Migration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524123617_Second Migration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220525080401_New Migration', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220525085431_Test Migration', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[commands] ON 

INSERT [dbo].[commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (1, N'Build a Project', N'dotnet build', 1)
INSERT [dbo].[commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (2, N'Run a Project', N'dotnet run', 1)
INSERT [dbo].[commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (3, N'start a docker compose', N'docker-compose up -d', 2)
SET IDENTITY_INSERT [dbo].[commands] OFF
GO
SET IDENTITY_INSERT [dbo].[Platforms] ON 

INSERT [dbo].[Platforms] ([Id], [Name], [LicenseKey]) VALUES (1, N'Dotnet6', N'123956')
INSERT [dbo].[Platforms] ([Id], [Name], [LicenseKey]) VALUES (2, N'Docker', N'45896')
INSERT [dbo].[Platforms] ([Id], [Name], [LicenseKey]) VALUES (3, N'Kubernets', N'ayt12345bgt67')
SET IDENTITY_INSERT [dbo].[Platforms] OFF
GO
ALTER TABLE [dbo].[commands]  WITH CHECK ADD  CONSTRAINT [FK_commands_Platforms_PlatformId] FOREIGN KEY([PlatformId])
REFERENCES [dbo].[Platforms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[commands] CHECK CONSTRAINT [FK_commands_Platforms_PlatformId]
GO
