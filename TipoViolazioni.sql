SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoViolazione](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](200) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TipoViolazione] ADD  CONSTRAINT [PK_TipoViolazione] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
