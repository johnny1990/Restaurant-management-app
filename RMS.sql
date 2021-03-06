SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorii](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nume_categorie] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moneda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nume_moneda] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clienti](
	[Id_client] [nchar](10) NOT NULL,
	[Nume_client] [nchar](100)  NULL,
	[Adresa] [varchar](max)  NULL,
	[Oras] [varchar](250)  NULL,
	[Mobil] [nchar](15)  NULL,
	[Telefon] [nchar](15) NULL,
	[Email] [varchar](250) NULL,
	[Observatii] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Informatii_restaurante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nume_restaurant] [nchar](150)  NULL,
	[Adresa] [varchar](250)  NULL,
	[Mobil] [nchar](15) NULL,
	[Mobil_director] [nchar](15) NULL,
	[Email] [nchar](150)  NULL,
	[Serie] [nchar](50) NULL,
	[Id_nr] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 

GO
SET ANSI_PADDING OFF
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Informatii_facturi](
	[Id] [int] IDENTITY (1,1) NOT NULL,
	[Nr_plata] [nchar](15)  NULL,
	[Data_plata] [datetime]  NULL,
	[Subtotal] [float]  NULL,
	[TVA_per] [float]  NULL,
	[Valoare_TVA] [float]  NULL,
	[Reducere_per] [float]  NULL,
	[Valoare_reducere] [float]  NULL,
	[Total general] [float]  NULL,
	[Cash] [float]  NULL,
	[Change] [float]  NULL,
	[Opinii] [varchar](250) NULL,
	[Id_moneda] [int] NOT NULL,
	[Id_restaurant] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produse](
	[Id_produs] [int] IDENTITY(1,1) NOT NULL,
	[Nume_produs] [varchar](max)  NULL,
	[Id_categorie] [int] NOT NULL,
	[Pret] [float]  NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_produs] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Produse_vandute](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_factura] [int] NOT NULL,
	[Id_produs] [int] NOT NULL,
	[Nume_produs] [varchar](250)  NULL,
	[Pret] [float]  NULL,
	[Cantitate] [int] NULL,
	[Valoare_totala] [float]  NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inregistrare](
	[Id_utilizator] [int] IDENTITY(1,1) NOT NULL, 
	[Nume_utilizator] [nchar](30)  NULL,
	[Tip_utilizator] [nchar](20)  NULL,
	[Parola] [nchar](30)  NULL,
	[Nume] [varchar](250)  NULL,
	[Mobil] [nchar](15)  NULL,
	[Email] [varchar](250) NULL,
	[Data_inregistrare] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_utilizator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Informatii_facturi]  WITH CHECK ADD  CONSTRAINT [FK_Informatii_facturi_Moneda] FOREIGN KEY([Id_moneda])
REFERENCES [dbo].[Moneda] ([Id])
GO
ALTER TABLE [dbo].[Informatii_facturi] CHECK CONSTRAINT [FK_Informatii_facturi_Moneda]
GO
ALTER TABLE [dbo].[Informatii_facturi]  WITH CHECK ADD  CONSTRAINT [FK_Informatii_facturi_Informatii_restaurante] FOREIGN KEY([Id_restaurant])
REFERENCES [dbo].[Informatii_restaurante] ([Id])
GO
ALTER TABLE [dbo].[Informatii_facturi] CHECK CONSTRAINT [FK_Informatii_facturi_Informatii_restaurante]
GO
ALTER TABLE [dbo].[Produse]  WITH CHECK ADD  CONSTRAINT [FK_Produse_Categorii] FOREIGN KEY([Id_categorie])
REFERENCES [dbo].[Categorii] ([Id])
GO
ALTER TABLE [dbo].[Produse] CHECK CONSTRAINT [FK_Produse_Categorii]
GO
ALTER TABLE [dbo].[Produse_vandute]  WITH CHECK ADD  CONSTRAINT [FK_Produse_vandute_Produse] FOREIGN KEY([Id_produs])
REFERENCES [dbo].[Produse] ([Id_produs])
GO
ALTER TABLE [dbo].[Produse_vandute] CHECK CONSTRAINT [FK_Produse_vandute_Produse]
GO
ALTER TABLE [dbo].[Produse_vandute]  WITH CHECK ADD  CONSTRAINT [FK_T_informatii_facturi] FOREIGN KEY([Id_factura])
REFERENCES [dbo].[Informatii_facturi] ([Id])
GO
ALTER TABLE [dbo].[Produse_vandute] CHECK CONSTRAINT [FK_T_Informatii_facturi]



