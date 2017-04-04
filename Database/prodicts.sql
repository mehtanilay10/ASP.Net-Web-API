/****** Object:  Table [dbo].[Products] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BoxSize] [int] NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON
INSERT [dbo].[Products] ([ProductId], [Name], [Quantity], [BoxSize], [Price]) VALUES (1, N'Pencil', 20, 10, CAST(12.00 AS Decimal(5, 2)))
INSERT [dbo].[Products] ([ProductId], [Name], [Quantity], [BoxSize], [Price]) VALUES (3, N'Pen', 50, 30, CAST(20.00 AS Decimal(5, 2)))
INSERT [dbo].[Products] ([ProductId], [Name], [Quantity], [BoxSize], [Price]) VALUES (4, N'File folder', 5, 2, CAST(30.00 AS Decimal(5, 2)))
INSERT [dbo].[Products] ([ProductId], [Name], [Quantity], [BoxSize], [Price]) VALUES (5, N'Marker', 10, 10, CAST(10.00 AS Decimal(5, 2)))
INSERT [dbo].[Products] ([ProductId], [Name], [Quantity], [BoxSize], [Price]) VALUES (10, N'Blue Ink', 0, 10, CAST(12.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF