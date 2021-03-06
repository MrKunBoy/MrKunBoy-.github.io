USE [Nguyen_Trinh_DB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/21/2021 1:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/21/2021 1:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UnitCost] [int] NULL,
	[Quantity] [int] NULL,
	[Image] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Status] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/21/2021 1:57:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (1, N'DELL', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (2, N'ASUS', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (3, N'HP', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (4, N'APPLE', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (5, N'ACER', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (6, N'LENNOVO', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (7, N'SAMSUNG', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (8, N'MICROSOFT', NULL)
INSERT [dbo].[Category] ([ID], [Name], [Description]) VALUES (9, N'MSI', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (1, N'Dell 1200', 15000000, 2, N'Image/laptop4.jpg', N'chưa thêm', N'Hiển thị', 1)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (3, N'Hp 1920', 15000000, 2, N'Image/laptop6.jpg', N'no', N'Hiển thị', 3)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (4, N'Mac 54', 34000000, 5, N'Image/laptop8.jpg', N'dffdgh', N'Hiển thị', 4)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (5, N'Lennovo 1', 15000000, 1, N'Image/laptop1.jpg', N'a', N'Không hiển thị', 6)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (6, N'Asus 1280', 19000000, 5, N'Image/laptop1.jpg', N'd', N'Hiển thị', 2)
INSERT [dbo].[Product] ([ID], [Name], [UnitCost], [Quantity], [Image], [Description], [Status], [CategoryID]) VALUES (1002, N'Acer 9210', 17000000, 9, N'Image/laptop5.jpg', N'CPU: AMD Ryzen 55600H3.30 GHz
RAM: 8 GBDDR4 
Ổ cứng: Hỗ trợ khe cắm HDD 
Thời điểm ra mắt: 2021', N'Hiển thị', 5)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'Admin')
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (3, N'trinh', N'28415172efb5548286345b74313c260f', N'Blocked')
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (1003, N'khachhang1', N'd87607769cb8cca82dd377ed39a5dbdf', N'Customer')
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (1004, N'vantrinh', N'6f2008b2a318fa5f1a2fcdb9833e08be', N'Customer')
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (2002, N'vantuan', N'd78d517479004db9f09939af58e3fddc', N'Customer')
INSERT [dbo].[UserAccount] ([ID], [UserName], [Password], [Status]) VALUES (2003, N'laido', N'8a1fca0524562319cfa3b22109a06aa1', N'Customer')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
