USE [master]
GO
/****** Object:  Database [EFProject]    Script Date: 3/27/2023 8:24:43 PM ******/
CREATE DATABASE [EFProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EFProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EFProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EFProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EFProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EFProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EFProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EFProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EFProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EFProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [EFProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EFProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EFProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EFProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EFProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EFProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EFProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EFProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EFProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EFProject] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EFProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EFProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EFProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EFProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EFProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EFProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EFProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EFProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EFProject] SET  MULTI_USER 
GO
ALTER DATABASE [EFProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EFProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EFProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EFProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EFProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EFProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EFProject', N'ON'
GO
ALTER DATABASE [EFProject] SET QUERY_STORE = OFF
GO
USE [EFProject]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Client_Id] [int] NOT NULL,
	[Client_Name] [nvarchar](50) NOT NULL,
	[Telephone] [int] NOT NULL,
	[Mobile] [int] NOT NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasurementUnits]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasurementUnits](
	[Prod_Code] [int] NOT NULL,
	[Measurement_Unit] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MeasurementUnits] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC,
	[Measurement_Unit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Prod_Code] [int] NOT NULL,
	[Client_Id] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC,
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Prod_Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Entry_Date] [date] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Warehouse]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Warehouse](
	[Prod_Code] [int] NOT NULL,
	[Warehouse_Id] [int] NOT NULL,
	[Available_Quantity] [int] NULL,
 CONSTRAINT [PK_Product_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC,
	[Warehouse_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[Prod_Code] [int] NOT NULL,
	[Warehouse_Id] [int] NOT NULL,
	[Supplier_Id] [int] NOT NULL,
	[Req_No] [int] NOT NULL,
	[Req_Date] [date] NOT NULL,
	[Prod_Quantity] [int] NOT NULL,
	[Production_Date] [date] NULL,
	[Validity_Period] [date] NULL,
	[Req_Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC,
	[Warehouse_Id] ASC,
	[Supplier_Id] ASC,
	[Req_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Supplier_Id] [int] NOT NULL,
	[Supplier_Name] [nvarchar](50) NOT NULL,
	[Telephone] [int] NOT NULL,
	[Mobile] [int] NOT NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Supplier_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer_Products]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer_Products](
	[Prod_Code] [int] NOT NULL,
	[Source_Warehouse] [int] NOT NULL,
	[Destination_Warehouse] [int] NOT NULL,
	[Transfer_Id] [int] NOT NULL,
	[Supplier_Id] [int] NULL,
	[Prod_Quantity] [int] NOT NULL,
	[Production_Date] [date] NULL,
	[Validity_Period] [date] NULL,
	[Transfer_Date] [date] NULL,
 CONSTRAINT [PK_Transfer_Products] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC,
	[Source_Warehouse] ASC,
	[Destination_Warehouse] ASC,
	[Transfer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 3/27/2023 8:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Warehouse_Id] [int] NOT NULL,
	[Ware_Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Manager] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Warehouse_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([Client_Id], [Client_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (1, N'Aletehad', 5049332, 1234567891, N'1123-448-4489', N'aletehad@gmail.com', N'www.aletehad.com')
INSERT [dbo].[Client] ([Client_Id], [Client_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (2, N'M group', 34495099, 112263789, N'2345-4645-777', N'mg@gmail.com', N'www.mg.com')
GO
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (10, N'Kilo')
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (20, N'Kilo')
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (30, N'gram')
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (30, N'Kilo')
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (40, N'unit')
INSERT [dbo].[MeasurementUnits] ([Prod_Code], [Measurement_Unit]) VALUES (50, N'Packet')
GO
INSERT [dbo].[Product] ([Prod_Code], [Name], [Entry_Date]) VALUES (10, N'Cheese', CAST(N'2023-03-20' AS Date))
INSERT [dbo].[Product] ([Prod_Code], [Name], [Entry_Date]) VALUES (20, N'Milk', CAST(N'2023-03-19' AS Date))
INSERT [dbo].[Product] ([Prod_Code], [Name], [Entry_Date]) VALUES (30, N'coconut Milk', CAST(N'2023-03-18' AS Date))
INSERT [dbo].[Product] ([Prod_Code], [Name], [Entry_Date]) VALUES (40, N'Mango Juice', CAST(N'2023-03-27' AS Date))
INSERT [dbo].[Product] ([Prod_Code], [Name], [Entry_Date]) VALUES (50, N'Juhayna Yugort', CAST(N'2023-03-27' AS Date))
GO
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (10, 1, 50)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (10, 2, 50)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (10, 3, 180)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (20, 1, 40)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (20, 2, 30)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (20, 3, 30)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (30, 3, 50)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (40, 4, 120)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (40, 6, 80)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (50, 1, 50)
INSERT [dbo].[Product_Warehouse] ([Prod_Code], [Warehouse_Id], [Available_Quantity]) VALUES (50, 5, 250)
GO
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (10, 1, 1, 1, CAST(N'2023-03-20' AS Date), 100, CAST(N'2023-03-20' AS Date), CAST(N'2023-04-01' AS Date), N'Import')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (10, 1, 1, 3, CAST(N'2023-03-25' AS Date), 30, CAST(N'2023-03-24' AS Date), CAST(N'2023-04-28' AS Date), N'Import')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (10, 3, 2, 6, CAST(N'2023-03-27' AS Date), 100, CAST(N'2023-03-27' AS Date), CAST(N'2023-05-30' AS Date), N'Import')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (20, 1, 1, 2, CAST(N'2023-03-24' AS Date), 100, CAST(N'2023-03-24' AS Date), CAST(N'2023-04-01' AS Date), N'Import')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (20, 2, 2, 4, CAST(N'2023-03-26' AS Date), 120, CAST(N'2023-03-26' AS Date), CAST(N'2023-04-29' AS Date), N'Export')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (30, 3, 2, 5, CAST(N'2023-03-26' AS Date), 150, CAST(N'2023-03-26' AS Date), CAST(N'2023-05-30' AS Date), N'Export')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (40, 4, 2, 7, CAST(N'2023-03-01' AS Date), 200, CAST(N'2023-02-01' AS Date), CAST(N'2023-06-30' AS Date), N'Import')
INSERT [dbo].[Request] ([Prod_Code], [Warehouse_Id], [Supplier_Id], [Req_No], [Req_Date], [Prod_Quantity], [Production_Date], [Validity_Period], [Req_Type]) VALUES (50, 5, 2, 8, CAST(N'2023-03-01' AS Date), 300, CAST(N'2023-02-01' AS Date), CAST(N'2023-06-30' AS Date), N'Import')
GO
INSERT [dbo].[Supplier] ([Supplier_Id], [Supplier_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (1, N'ElMara3i', 35059141, 1226187878, N'707-555-0199', N'Elmara3i@gmail.com', N'www.Elmara3i.com')
INSERT [dbo].[Supplier] ([Supplier_Id], [Supplier_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (2, N'Elmotaheda', 34538938, 1223847784, N'5555-7878-666', N'motaheda@gmail.com', N'www.motaheda.com')
INSERT [dbo].[Supplier] ([Supplier_Id], [Supplier_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (3, N'juhayna', 3688469, 1265689768, N'4554-6787-888', N'juhayna@gmail.com', N'www.juhayna.com')
INSERT [dbo].[Supplier] ([Supplier_Id], [Supplier_Name], [Telephone], [Mobile], [Fax], [Mail], [Website]) VALUES (4, N'elsalam', 36768499, 1283894896, N'3344-6780-888', N'salam@gmail.com', N'www.salam.com')
GO
INSERT [dbo].[Transfer_Products] ([Prod_Code], [Source_Warehouse], [Destination_Warehouse], [Transfer_Id], [Supplier_Id], [Prod_Quantity], [Production_Date], [Validity_Period], [Transfer_Date]) VALUES (20, 1, 3, 1, 1, 60, CAST(N'2023-03-26' AS Date), CAST(N'2023-04-29' AS Date), CAST(N'2023-03-26' AS Date))
INSERT [dbo].[Transfer_Products] ([Prod_Code], [Source_Warehouse], [Destination_Warehouse], [Transfer_Id], [Supplier_Id], [Prod_Quantity], [Production_Date], [Validity_Period], [Transfer_Date]) VALUES (20, 3, 2, 2, 1, 30, CAST(N'2023-03-24' AS Date), CAST(N'2023-04-30' AS Date), CAST(N'2023-03-27' AS Date))
INSERT [dbo].[Transfer_Products] ([Prod_Code], [Source_Warehouse], [Destination_Warehouse], [Transfer_Id], [Supplier_Id], [Prod_Quantity], [Production_Date], [Validity_Period], [Transfer_Date]) VALUES (40, 4, 6, 3, 2, 80, CAST(N'2023-02-01' AS Date), CAST(N'2023-06-01' AS Date), CAST(N'2023-02-28' AS Date))
INSERT [dbo].[Transfer_Products] ([Prod_Code], [Source_Warehouse], [Destination_Warehouse], [Transfer_Id], [Supplier_Id], [Prod_Quantity], [Production_Date], [Validity_Period], [Transfer_Date]) VALUES (50, 5, 1, 4, 2, 50, CAST(N'2023-03-26' AS Date), CAST(N'2023-05-30' AS Date), CAST(N'2023-02-23' AS Date))
GO
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (1, N'AlZahraa', N'Cairo', N'Doaa Sherif')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (2, N'Smouha', N'Alexandria', N'Ahmed Adel')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (3, N'ElSharkawy', N'Alexandria', N'Mohamed Sherif')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (4, N'Elt7rer', N'Cairo', N'Mazen Ahmed')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (5, N'Elraml', N'Alexandria', N'Zeyad Talal')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (6, N'Elsherbeny', N'Alexandria', N'Fayez Sherbeny')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (7, N'elsalam', N'cairo', N'doaa sherif')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (8, N'elsalams', N'alex', N'ahmed adel')
INSERT [dbo].[Warehouse] ([Warehouse_Id], [Ware_Name], [Address], [Manager]) VALUES (10, N'aleman', N'alex', N'mohamed sherif')
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_Entry_Date]  DEFAULT (getdate()) FOR [Entry_Date]
GO
ALTER TABLE [dbo].[MeasurementUnits]  WITH CHECK ADD  CONSTRAINT [FK_MeasurementUnits_Product] FOREIGN KEY([Prod_Code])
REFERENCES [dbo].[Product] ([Prod_Code])
GO
ALTER TABLE [dbo].[MeasurementUnits] CHECK CONSTRAINT [FK_MeasurementUnits_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Client] ([Client_Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([Prod_Code])
REFERENCES [dbo].[Product] ([Prod_Code])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Product_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Product_Warehouse_Product] FOREIGN KEY([Prod_Code])
REFERENCES [dbo].[Product] ([Prod_Code])
GO
ALTER TABLE [dbo].[Product_Warehouse] CHECK CONSTRAINT [FK_Product_Warehouse_Product]
GO
ALTER TABLE [dbo].[Product_Warehouse]  WITH CHECK ADD  CONSTRAINT [FK_Product_Warehouse_Warehouse] FOREIGN KEY([Warehouse_Id])
REFERENCES [dbo].[Warehouse] ([Warehouse_Id])
GO
ALTER TABLE [dbo].[Product_Warehouse] CHECK CONSTRAINT [FK_Product_Warehouse_Warehouse]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Product] FOREIGN KEY([Prod_Code])
REFERENCES [dbo].[Product] ([Prod_Code])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Product]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Supplier] FOREIGN KEY([Supplier_Id])
REFERENCES [dbo].[Supplier] ([Supplier_Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Supplier]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Warehouse] FOREIGN KEY([Warehouse_Id])
REFERENCES [dbo].[Warehouse] ([Warehouse_Id])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Warehouse]
GO
ALTER TABLE [dbo].[Transfer_Products]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Products_Product] FOREIGN KEY([Prod_Code])
REFERENCES [dbo].[Product] ([Prod_Code])
GO
ALTER TABLE [dbo].[Transfer_Products] CHECK CONSTRAINT [FK_Transfer_Products_Product]
GO
ALTER TABLE [dbo].[Transfer_Products]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Products_Warehouse] FOREIGN KEY([Source_Warehouse])
REFERENCES [dbo].[Warehouse] ([Warehouse_Id])
GO
ALTER TABLE [dbo].[Transfer_Products] CHECK CONSTRAINT [FK_Transfer_Products_Warehouse]
GO
ALTER TABLE [dbo].[Transfer_Products]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Products_Warehouse1] FOREIGN KEY([Destination_Warehouse])
REFERENCES [dbo].[Warehouse] ([Warehouse_Id])
GO
ALTER TABLE [dbo].[Transfer_Products] CHECK CONSTRAINT [FK_Transfer_Products_Warehouse1]
GO
USE [master]
GO
ALTER DATABASE [EFProject] SET  READ_WRITE 
GO
