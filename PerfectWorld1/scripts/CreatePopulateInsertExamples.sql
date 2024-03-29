/****** 
	1. Create a database named InsertExamples under localDb 
	2. Run this script

	* Data was created using Bogus NuGet package from project DapperPersonRepository
******/


USE [InsertExamples]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/15/2023 3:37:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/15/2023 3:37:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (1, N'Stefanie', N'Buckley', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (2, N'Sandy', N'Mc Gee', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (3, N'Lee', N'Warren', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (4, N'Regina', N'Forbes', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (5, N'Daniel', N'Kim', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (6, N'Dennis', N'Nunez', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (7, N'Myra', N'Zuniga', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (8, N'Teddy', N'Ingram', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (9, N'Annie', N'Larson', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (10, N'Herman', N'Anderson', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (11, N'Jenifer', N'Livingston', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (12, N'Stefanie', N'Perez', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (13, N'Chastity', N'Garcia', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (14, N'Evelyn', N'Stokes', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (15, N'Jeannie', N'Daniel', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (16, N'Rickey', N'Santos', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (17, N'Bobbie', N'Hurst', 1)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (18, N'Lesley', N'Lawson', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (19, N'Shawna', N'Browning', 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Active]) VALUES (20, N'Theresa', N'Ross', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Ricky', N'Howe', CAST(N'2001-11-17' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Pam', N'Steuber', CAST(N'2002-01-13' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Sonia', N'Larkin', CAST(N'2002-03-01' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Lawrence', N'Schneider', CAST(N'1999-07-30' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Virginia', N'O''Connell', CAST(N'2006-04-07' AS Date))
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
USE [master]
GO
ALTER DATABASE [InsertExamples] SET  READ_WRITE 
GO
