USE [Assignment]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/14/2021 5:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[Price] [decimal](18, 2) NULL,
	[Image] [nvarchar](150) NULL,
	[views] [int] NULL,
	[impressions] [int] NULL,
	[Vendor_UID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 6/14/2021 5:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[Vendor_UID] [int] IDENTITY(1,1) NOT NULL,
	[Vendor_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Vendor_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Vendor] FOREIGN KEY([Vendor_UID])
REFERENCES [dbo].[Vendor] ([Vendor_UID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Vendor]
GO
ALTER TABLE [dbo].[Vendor]  WITH CHECK ADD  CONSTRAINT [FK_Vendor_Vendor] FOREIGN KEY([Vendor_UID])
REFERENCES [dbo].[Vendor] ([Vendor_UID])
GO
ALTER TABLE [dbo].[Vendor] CHECK CONSTRAINT [FK_Vendor_Vendor]
GO
