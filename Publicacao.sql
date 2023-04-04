
CREATE TABLE [dbo].[Publicacao] (
  [id] nvarchar(100) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Titulo] varchar(100) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Descricao] varchar(max) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Area] varchar(100) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Autor] varchar(100) COLLATE Latin1_General_CI_AS  NOT NULL,
  [DataPublicacao] varchar(100) COLLATE Latin1_General_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Publicacao] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table Publicacao
-- ----------------------------
ALTER TABLE [dbo].[Publicacao] ADD CONSTRAINT [PK__Publicac__3213E83F68E488E0] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

