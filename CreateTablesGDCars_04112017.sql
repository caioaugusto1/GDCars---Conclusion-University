USE [GDCars]
GO
/****** Object:  Table [dbo].[GDC_Bancos]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Bancos](
	[Id] [uniqueidentifier] NOT NULL,
	[Modelo] [varchar](10) NOT NULL,
	[Multimidia] [bit] NOT NULL,
	[Cor] [varchar](10) NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[IdUpload] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Banc__3214EC074F8C7527] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Clientes]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Clientes](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[RG] [varchar](12) NOT NULL,
	[CPF] [varchar](14) NOT NULL,
	[Tipo] [varchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Data_Nascimento] [datetime] NOT NULL,
	[IdEndereco] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Clie__3214EC073E8C11F2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Cor_Veiculos]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Cor_Veiculos](
	[Id] [uniqueidentifier] NOT NULL,
	[Estilo] [varchar](10) NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK__GDC_Core__3214EC07A3F94901] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Enderecos]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Enderecos](
	[Id] [uniqueidentifier] NOT NULL,
	[Endereco] [varchar](100) NULL,
	[Numero] [varchar](5) NULL,
	[Complemento] [varchar](25) NULL,
	[CEP] [varchar](9) NULL,
	[Bairro] [varchar](30) NULL,
	[Estado] [varchar](30) NULL,
	[Cidade] [varchar](30) NULL,
 CONSTRAINT [PK__GDC_Ende__3214EC07C7BD40EA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Formas_Pagamentos]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Formas_Pagamentos](
	[Id] [uniqueidentifier] NOT NULL,
	[Modelo] [varchar](30) NOT NULL,
	[Tipo_Cliente] [char](10) NOT NULL,
 CONSTRAINT [PK__GDC_Form__3214EC07BD0845B5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Logins]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Logins](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[SobreNome] [varchar](30) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Senha] [varchar](50) NOT NULL,
	[Confirmar_Senha] [varchar](50) NOT NULL,
	[Data_Inclusao] [datetime] NOT NULL,
 CONSTRAINT [PK__GDC_Logi__3214EC070CC96F61] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Perfomances]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Perfomances](
	[Id] [uniqueidentifier] NOT NULL,
	[ValorTotal] [float] NULL,
	[IdCliente] [uniqueidentifier] NOT NULL,
	[IdRoda] [uniqueidentifier] NULL,
	[IdBanco] [uniqueidentifier] NULL,
	[IdCor_Veiculo] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Perf__3214EC07AA4BD9E7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Rodas]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Rodas](
	[Id] [uniqueidentifier] NOT NULL,
	[Modelo] [varchar](30) NOT NULL,
	[Cor] [varchar](10) NOT NULL,
	[Aro] [int] NOT NULL,
	[Valor] [float] NOT NULL,
	[IdUpload] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Roda__3214EC078B4A2B11] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Uploads]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Uploads](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome_Arquivo] [varchar](500) NOT NULL,
	[Data_Inclusao] [datetime] NOT NULL,
 CONSTRAINT [PK__GDC_Uplo__3214EC075A3CAD3D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Veiculos]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Veiculos](
	[Id] [uniqueidentifier] NOT NULL,
	[Fabricante] [varchar](20) NOT NULL,
	[Modelo] [varchar](20) NOT NULL,
	[Ano] [int] NOT NULL,
	[Valor] [float] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[IdUpload] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Veic__3214EC07B6524FD9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GDC_Vendas]    Script Date: 04/11/2017 18:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GDC_Vendas](
	[Id] [uniqueidentifier] NOT NULL,
	[Valor] [float] NOT NULL,
	[Observacao] [varchar](500) NULL,
	[Tipo_Entrega] [char](10) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[Termo_Autorizacao] [bit] NOT NULL,
	[IdCliente] [uniqueidentifier] NOT NULL,
	[IdFormaPagamento] [uniqueidentifier] NOT NULL,
	[IdVeiculo] [uniqueidentifier] NOT NULL,
	[IdPerformance] [uniqueidentifier] NULL,
 CONSTRAINT [PK__GDC_Vend__3214EC07BE8E5589] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[GDC_Bancos]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Banco__IdUpl__1DE57479] FOREIGN KEY([IdUpload])
REFERENCES [dbo].[GDC_Uploads] ([Id])
GO
ALTER TABLE [dbo].[GDC_Bancos] CHECK CONSTRAINT [FK__GDC_Banco__IdUpl__1DE57479]
GO
ALTER TABLE [dbo].[GDC_Clientes]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Clien__IdEnd__145C0A3F] FOREIGN KEY([IdEndereco])
REFERENCES [dbo].[GDC_Enderecos] ([Id])
GO
ALTER TABLE [dbo].[GDC_Clientes] CHECK CONSTRAINT [FK__GDC_Clien__IdEnd__145C0A3F]
GO
ALTER TABLE [dbo].[GDC_Perfomances]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Perfo__IdBan__21B6055D] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[GDC_Bancos] ([Id])
GO
ALTER TABLE [dbo].[GDC_Perfomances] CHECK CONSTRAINT [FK__GDC_Perfo__IdBan__21B6055D]
GO
ALTER TABLE [dbo].[GDC_Perfomances]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Perfo__IdCli__22AA2996] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[GDC_Clientes] ([Id])
GO
ALTER TABLE [dbo].[GDC_Perfomances] CHECK CONSTRAINT [FK__GDC_Perfo__IdCli__22AA2996]
GO
ALTER TABLE [dbo].[GDC_Perfomances]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Perfo__IdCor__239E4DCF] FOREIGN KEY([IdCor_Veiculo])
REFERENCES [dbo].[GDC_Cor_Veiculos] ([Id])
GO
ALTER TABLE [dbo].[GDC_Perfomances] CHECK CONSTRAINT [FK__GDC_Perfo__IdCor__239E4DCF]
GO
ALTER TABLE [dbo].[GDC_Perfomances]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Perfo__IdRod__20C1E124] FOREIGN KEY([IdRoda])
REFERENCES [dbo].[GDC_Rodas] ([Id])
GO
ALTER TABLE [dbo].[GDC_Perfomances] CHECK CONSTRAINT [FK__GDC_Perfo__IdRod__20C1E124]
GO
ALTER TABLE [dbo].[GDC_Rodas]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Rodas__IdUpl__1920BF5C] FOREIGN KEY([IdUpload])
REFERENCES [dbo].[GDC_Uploads] ([Id])
GO
ALTER TABLE [dbo].[GDC_Rodas] CHECK CONSTRAINT [FK__GDC_Rodas__IdUpl__1920BF5C]
GO
ALTER TABLE [dbo].[GDC_Veiculos]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Veicu__IdUpl__267ABA7A] FOREIGN KEY([IdUpload])
REFERENCES [dbo].[GDC_Uploads] ([Id])
GO
ALTER TABLE [dbo].[GDC_Veiculos] CHECK CONSTRAINT [FK__GDC_Veicu__IdUpl__267ABA7A]
GO
ALTER TABLE [dbo].[GDC_Vendas]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Venda__IdCli__2C3393D0] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[GDC_Clientes] ([Id])
GO
ALTER TABLE [dbo].[GDC_Vendas] CHECK CONSTRAINT [FK__GDC_Venda__IdCli__2C3393D0]
GO
ALTER TABLE [dbo].[GDC_Vendas]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Venda__IdFor__2D27B809] FOREIGN KEY([IdFormaPagamento])
REFERENCES [dbo].[GDC_Formas_Pagamentos] ([Id])
GO
ALTER TABLE [dbo].[GDC_Vendas] CHECK CONSTRAINT [FK__GDC_Venda__IdFor__2D27B809]
GO
ALTER TABLE [dbo].[GDC_Vendas]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Venda__IdPer__2B3F6F97] FOREIGN KEY([IdPerformance])
REFERENCES [dbo].[GDC_Perfomances] ([Id])
GO
ALTER TABLE [dbo].[GDC_Vendas] CHECK CONSTRAINT [FK__GDC_Venda__IdPer__2B3F6F97]
GO
ALTER TABLE [dbo].[GDC_Vendas]  WITH CHECK ADD  CONSTRAINT [FK__GDC_Venda__IdVei__2E1BDC42] FOREIGN KEY([IdVeiculo])
REFERENCES [dbo].[GDC_Veiculos] ([Id])
GO
ALTER TABLE [dbo].[GDC_Vendas] CHECK CONSTRAINT [FK__GDC_Venda__IdVei__2E1BDC42]
GO
