USE [master]
GO
/****** Object:  Database [product_delivery]    Script Date: 16.08.2024 16:01:18 ******/
CREATE DATABASE [product_delivery]

ALTER DATABASE [product_delivery] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [product_delivery].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [product_delivery] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [product_delivery] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [product_delivery] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [product_delivery] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [product_delivery] SET ARITHABORT OFF 
GO
ALTER DATABASE [product_delivery] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [product_delivery] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [product_delivery] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [product_delivery] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [product_delivery] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [product_delivery] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [product_delivery] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [product_delivery] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [product_delivery] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [product_delivery] SET  DISABLE_BROKER 
GO
ALTER DATABASE [product_delivery] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [product_delivery] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [product_delivery] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [product_delivery] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [product_delivery] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [product_delivery] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [product_delivery] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [product_delivery] SET RECOVERY FULL 
GO
ALTER DATABASE [product_delivery] SET  MULTI_USER 
GO
ALTER DATABASE [product_delivery] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [product_delivery] SET DB_CHAINING OFF 
GO
ALTER DATABASE [product_delivery] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [product_delivery] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [product_delivery] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [product_delivery] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'product_delivery', N'ON'
GO
ALTER DATABASE [product_delivery] SET QUERY_STORE = ON
GO
ALTER DATABASE [product_delivery] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [product_delivery]
GO
/****** Object:  Table [dbo].[address]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[city_id] [int] NULL,
	[street_name] [nvarchar](150) NOT NULL,
	[building_number] [nvarchar](80) NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bank_detail]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bank_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bank_id] [int] NULL,
	[number] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_bank_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[city]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type_id] [int] NULL,
	[name] [nvarchar](150) NOT NULL,
	[address_id] [int] NULL,
	[identity_document] [nvarchar](150) NULL,
	[bank_detail_id] [int] NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client_type]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_client_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[delivery_note]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[delivery_note](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NULL,
	[price] [float] NULL,
	[phone_number] [nvarchar](50) NULL,
	[address_id] [int] NULL,
	[product_id] [int] NULL,
 CONSTRAINT [PK_delivery_note] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[category_id] [int] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 16.08.2024 16:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](150) NOT NULL,
	[password] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[address] ON 

INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2004, 1003, N'Broadway Street', N'456')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2005, 1003, N'Wall Street', N'22')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2006, 1004, N'Sunset Boulevard', N'12')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2007, 1004, N'Hollywood Boulevard', N'46')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2008, 1005, N'Yonge Street', N'33')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2009, 1005, N'Queen Street West', N'52')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2010, 1006, N'Robson Street', N'3')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2011, 1007, N'Oxford Street', N'5')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2012, 1008, N'Deansgate', N'221B')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2013, 1009, N'Rue de Rivoli', N'75')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2014, 1010, N'Quai Saint-Antoine', N'2')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2015, 1010, N'Unter den Linden', N'42')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2016, 1017, N'Dotonbori Street', N'7')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2017, 1021, N'Corso Buenos Aires', N'100A')
INSERT [dbo].[address] ([id], [city_id], [street_name], [building_number]) VALUES (2018, 1023, N'Chandni Chowk', N'12')
SET IDENTITY_INSERT [dbo].[address] OFF
GO
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([id], [name]) VALUES (6, N'PrimeTrust Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (7, N'Capital Nexus Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (8, N'GlobalEdge Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (9, N'Summit Financial')
INSERT [dbo].[Bank] ([id], [name]) VALUES (10, N'Pioneer Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (11, N'Liberty Capital Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (12, N'NordicTrust Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (13, N'Vanguard Bank')
INSERT [dbo].[Bank] ([id], [name]) VALUES (14, N'Horizon Financial Group')
INSERT [dbo].[Bank] ([id], [name]) VALUES (15, N'Evergreen Bank')
SET IDENTITY_INSERT [dbo].[Bank] OFF
GO
SET IDENTITY_INSERT [dbo].[bank_detail] ON 

INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (7, 6, N'4053 2987 6541 0932')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (8, 6, N'5891 7462 3201 8794')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (9, 6, N'1204 6573 8902 3417')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (10, 6, N'7635 1948 0021 6587')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (11, 6, N'9076 2145 8390 5612')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (12, 7, N'4812 6903 1457 8396')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (13, 7, N'3207 8914 5602 7149')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (14, 7, N'6579 3410 8921 6743')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (15, 12, N'2374 9805 1632 7481')
INSERT [dbo].[bank_detail] ([id], [bank_id], [number]) VALUES (16, 15, N'8457 3291 5603 8174')
SET IDENTITY_INSERT [dbo].[bank_detail] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 

INSERT [dbo].[category] ([id], [name]) VALUES (1, N'Rods and Reels')
INSERT [dbo].[category] ([id], [name]) VALUES (3, N'Lures and Baits')
INSERT [dbo].[category] ([id], [name]) VALUES (4, N'Fishing Tackle and Rigs')
INSERT [dbo].[category] ([id], [name]) VALUES (5, N'Fish Finders and GPS Devices')
INSERT [dbo].[category] ([id], [name]) VALUES (6, N'Tackle Boxes and Storage')
INSERT [dbo].[category] ([id], [name]) VALUES (7, N'Camping Equipment')
INSERT [dbo].[category] ([id], [name]) VALUES (8, N'Fishing Apparel and Footwear')
INSERT [dbo].[category] ([id], [name]) VALUES (9, N'Spinning Gear and Floats')
INSERT [dbo].[category] ([id], [name]) VALUES (10, N'Nets and Landing Gear')
INSERT [dbo].[category] ([id], [name]) VALUES (2003, N'Boating Accessories')
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[city] ON 

INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1003, N'New York', 12)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1004, N'Los Angeles', 12)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1005, N'Toronto', 13)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1006, N'Vancouver', 13)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1007, N'London', 14)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1008, N'Manchester', 14)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1009, N'Paris', 15)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1010, N'Lyon', 15)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1011, N'Berlin', 16)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1012, N'Munich', 16)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1013, N'Moscow', 17)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1014, N'Saint Petersburg', 17)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1015, N'Sydney', 18)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1016, N'Melbourne', 18)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1017, N'Tokyo', 19)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1018, N'Osaka', 19)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1019, N'Rio de Janeiro', 20)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1020, N'Rome', 21)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1021, N'Milan', 21)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1022, N'Mumbai', 22)
INSERT [dbo].[city] ([id], [name], [country_id]) VALUES (1023, N'Delhi', 22)
SET IDENTITY_INSERT [dbo].[city] OFF
GO
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([id], [type_id], [name], [address_id], [identity_document], [bank_detail_id]) VALUES (1003, 2, N'David Brown', 2004, N'Passport, Number: 987654321', 8)
INSERT [dbo].[client] ([id], [type_id], [name], [address_id], [identity_document], [bank_detail_id]) VALUES (1004, 2, N'Sarah Johnson', 2008, N'Driver''s License, Number: D98765432', 12)
INSERT [dbo].[client] ([id], [type_id], [name], [address_id], [identity_document], [bank_detail_id]) VALUES (1005, 1, N'RiverTech Financial Services LLC', 2008, N'Business License, Number: BL-1224152', 16)
INSERT [dbo].[client] ([id], [type_id], [name], [address_id], [identity_document], [bank_detail_id]) VALUES (1006, 2, N'Maria Gonzalez', 2011, N'National ID Card, Number: ID098765432', 15)
SET IDENTITY_INSERT [dbo].[client] OFF
GO
SET IDENTITY_INSERT [dbo].[client_type] ON 

INSERT [dbo].[client_type] ([id], [name]) VALUES (1, N'Legal entity')
INSERT [dbo].[client_type] ([id], [name]) VALUES (2, N'Individual')
INSERT [dbo].[client_type] ([id], [name]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[client_type] OFF
GO
SET IDENTITY_INSERT [dbo].[country] ON 

INSERT [dbo].[country] ([id], [name]) VALUES (12, N'USA')
INSERT [dbo].[country] ([id], [name]) VALUES (13, N'Canada')
INSERT [dbo].[country] ([id], [name]) VALUES (14, N'United Kingdom')
INSERT [dbo].[country] ([id], [name]) VALUES (15, N'France')
INSERT [dbo].[country] ([id], [name]) VALUES (16, N'Germany')
INSERT [dbo].[country] ([id], [name]) VALUES (17, N'Russia')
INSERT [dbo].[country] ([id], [name]) VALUES (18, N'Australia')
INSERT [dbo].[country] ([id], [name]) VALUES (19, N'Japan')
INSERT [dbo].[country] ([id], [name]) VALUES (20, N'Brazil')
INSERT [dbo].[country] ([id], [name]) VALUES (21, N'Italy')
INSERT [dbo].[country] ([id], [name]) VALUES (22, N'India')
SET IDENTITY_INSERT [dbo].[country] OFF
GO
SET IDENTITY_INSERT [dbo].[delivery_note] ON 

INSERT [dbo].[delivery_note] ([id], [client_id], [price], [phone_number], [address_id], [product_id]) VALUES (12, 1003, 3200, N'+1 (555) 123-4567', 2004, 1)
INSERT [dbo].[delivery_note] ([id], [client_id], [price], [phone_number], [address_id], [product_id]) VALUES (13, 1004, 3200, N'+1 (555) 765-4321', 2008, 1002)
INSERT [dbo].[delivery_note] ([id], [client_id], [price], [phone_number], [address_id], [product_id]) VALUES (14, 1005, 1200, N'+34 91 123 4567', 2010, 1005)
INSERT [dbo].[delivery_note] ([id], [client_id], [price], [phone_number], [address_id], [product_id]) VALUES (15, 1006, 1245.86, N'+1 (555) 789-1234', 2017, 1009)
SET IDENTITY_INSERT [dbo].[delivery_note] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1, N'Shimano Stradic Spinning Reel', 1)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1002, N'Ugly Stik Elite Spinning Rod', 1)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1003, N'Rapala Original Floating Lure', 3)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1004, N'Berkley PowerBait Soft Plastic Worms', 3)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1005, N'Eagle Claw Fishing Hooks', 4)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1006, N'Bullet Weights Lead Sinkers', 4)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1007, N'Garmin Striker 4 Fish Finder', 5)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1008, N'Humminbird Helix 5 GPS', 5)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1009, N'Frabill Folding Fishing Net', 10)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1010, N'KastKing Fishing Lip Gripper', 10)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1011, N'Thill Pro Series Floats', 9)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1012, N'Daiwa BG Spinning Reel', 9)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1013, N'Columbia PFG Fishing Shirt', 8)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1014, N'Coleman Sundome Tent', 7)
INSERT [dbo].[product] ([id], [name], [category_id]) VALUES (1015, N'Minn Kota Trolling Motor', 2003)
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [login], [password]) VALUES (1, N'Admin', N'bbb7b19fe1ed2f32883d32234246d88462df528f1a05d358957aeed805a447e0')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (2, N'user2', N'password2')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (3, N'user3', N'password3')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (4, N'user4', N'password4')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (5, N'user5', N'password5')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (6, N'user6', N'password6')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (7, N'user7', N'password7')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (8, N'user8', N'password8')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (9, N'user9', N'password9')
INSERT [dbo].[user] ([id], [login], [password]) VALUES (10, N'user10', N'password10')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[address]  WITH CHECK ADD  CONSTRAINT [FK_address_city] FOREIGN KEY([city_id])
REFERENCES [dbo].[city] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[address] CHECK CONSTRAINT [FK_address_city]
GO
ALTER TABLE [dbo].[bank_detail]  WITH CHECK ADD  CONSTRAINT [FK_bank_detail_Bank] FOREIGN KEY([bank_id])
REFERENCES [dbo].[Bank] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[bank_detail] CHECK CONSTRAINT [FK_bank_detail_Bank]
GO
ALTER TABLE [dbo].[city]  WITH CHECK ADD  CONSTRAINT [FK_city_country] FOREIGN KEY([country_id])
REFERENCES [dbo].[country] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[city] CHECK CONSTRAINT [FK_city_country]
GO
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_address]
GO
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_bank_detail] FOREIGN KEY([bank_detail_id])
REFERENCES [dbo].[bank_detail] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_bank_detail]
GO
ALTER TABLE [dbo].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_client_type] FOREIGN KEY([type_id])
REFERENCES [dbo].[client_type] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[client] CHECK CONSTRAINT [FK_client_client_type]
GO
ALTER TABLE [dbo].[delivery_note]  WITH CHECK ADD  CONSTRAINT [FK_delivery_note_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[delivery_note] CHECK CONSTRAINT [FK_delivery_note_address]
GO
ALTER TABLE [dbo].[delivery_note]  WITH CHECK ADD  CONSTRAINT [FK_delivery_note_client] FOREIGN KEY([client_id])
REFERENCES [dbo].[client] ([id])
GO
ALTER TABLE [dbo].[delivery_note] CHECK CONSTRAINT [FK_delivery_note_client]
GO
ALTER TABLE [dbo].[delivery_note]  WITH CHECK ADD  CONSTRAINT [FK_delivery_note_product] FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[delivery_note] CHECK CONSTRAINT [FK_delivery_note_product]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_category]
GO
USE [master]
GO
ALTER DATABASE [product_delivery] SET  READ_WRITE 
GO
