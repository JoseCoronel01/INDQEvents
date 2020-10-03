/****** Object:  Table [dbo].[Event]    Script Date: 03/10/2020 09:40:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[id] [varchar](36) NOT NULL,
	[title] [varchar](80) NULL,
	[description] [varchar](80) NULL,
	[date] [datetime] NULL,
	[image] [varchar](255) NULL,
	[attendances] [bigint] NULL,
	[willYouAttend] [bit] NULL,
	[latitude] [decimal](18, 2) NULL,
	[longitude] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/10/2020 09:40:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[password] [varchar](15) NULL,
	[gender] [tinyint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Event] ([id], [title], [description], [date], [image], [attendances], [willYouAttend], [latitude], [longitude]) VALUES (N'51cb5248-50a1-449b-b86f-446dd4ebc92b', N'prueba 3', N'prueba tres', CAST(N'2020-10-06T00:00:00.000' AS DateTime), N'/images/Persona3.jpg', 0, 0, NULL, NULL)
GO
INSERT [dbo].[Event] ([id], [title], [description], [date], [image], [attendances], [willYouAttend], [latitude], [longitude]) VALUES (N'b4cd0363-b532-4eee-8650-2630bc0c6ba1', N'partido', N'holanda vs mexico', CAST(N'2020-10-07T00:00:00.000' AS DateTime), N'/images/Persona4.jpg', 0, 0, NULL, NULL)
GO
INSERT [dbo].[Event] ([id], [title], [description], [date], [image], [attendances], [willYouAttend], [latitude], [longitude]) VALUES (N'e9f4fe91-baa4-448b-bab6-e085169ed97e', N'prueba 1', N'prueba uno', CAST(N'2020-10-03T00:00:00.000' AS DateTime), N'/images/Persona1.jpg', 0, 0, NULL, NULL)
GO
INSERT [dbo].[Event] ([id], [title], [description], [date], [image], [attendances], [willYouAttend], [latitude], [longitude]) VALUES (N'f1e2c9e3-55c8-4c07-8e6a-2bffddcf1527', N'prueba 2', N'prueba dos', CAST(N'2020-10-05T00:00:00.000' AS DateTime), N'/images/Persona2.jpg', 0, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([id], [email], [firstName], [lastName], [password], [gender]) VALUES (1, N'admin@admin.com', N'JUAN', N'PEREZ', N'123', 0)
GO
INSERT [dbo].[User] ([id], [email], [firstName], [lastName], [password], [gender]) VALUES (2, N'omar9@email.es', N'OMAR', N'BRAVO', N'123', 0)
GO
INSERT [dbo].[User] ([id], [email], [firstName], [lastName], [password], [gender]) VALUES (3, N'user@net.es', N'USUARIO', N'NET', N'123', 0)
GO
INSERT [dbo].[User] ([id], [email], [firstName], [lastName], [password], [gender]) VALUES (4, N'pablo@email.es', N'PABLO', N'PEREZ', N'123', 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
