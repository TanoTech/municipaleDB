SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verbali](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DataViolazione] [date] NOT NULL,
	[IndirizzoViolazione] [nvarchar](50) NOT NULL,
	[IDAgente] [int] NOT NULL,
	[DataTrascrizioneVerbale] [date] NOT NULL,
	[Importo] [decimal](18, 0) NOT NULL,
	[DecurtamentoPunti] [int] NOT NULL,
	[IDAnagrafe] [int] NOT NULL,
	[IDTipoViolazione] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Verbali] ADD  CONSTRAINT [PK_Verbali] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Verbali]  WITH CHECK ADD  CONSTRAINT [IDAgente] FOREIGN KEY([IDAgente])
REFERENCES [dbo].[Agenti] ([ID])
GO
ALTER TABLE [dbo].[Verbali] CHECK CONSTRAINT [IDAgente]
GO
ALTER TABLE [dbo].[Verbali]  WITH CHECK ADD  CONSTRAINT [IDAnagrafe] FOREIGN KEY([IDAnagrafe])
REFERENCES [dbo].[Anagrafica] ([ID])
GO
ALTER TABLE [dbo].[Verbali] CHECK CONSTRAINT [IDAnagrafe]
GO
