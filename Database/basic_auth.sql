/****** Object:  Table [dbo].[Users] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'developer', N'developer')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'tester', N'tester')
SET IDENTITY_INSERT [dbo].[Users] OFF

/****** Object:  Table [dbo].[Employees] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Department] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT [dbo].[Employees] ([Id], [Name], [Department]) VALUES (2, N'Nilay Mehta', N'Development')
INSERT [dbo].[Employees] ([Id], [Name], [Department]) VALUES (3, N'Shubham Koladiya', N'Development')
INSERT [dbo].[Employees] ([Id], [Name], [Department]) VALUES (4, N'Priyank Patel', N'Testing')
INSERT [dbo].[Employees] ([Id], [Name], [Department]) VALUES (5, N'Dhaval Shah', N'Testing')
INSERT [dbo].[Employees] ([Id], [Name], [Department]) VALUES (6, N'Ravi Shah', N'Development')
SET IDENTITY_INSERT [dbo].[Employees] OFF