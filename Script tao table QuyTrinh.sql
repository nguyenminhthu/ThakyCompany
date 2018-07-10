USE [thaky]
GO

/****** Object:  Table [dbo].[QuyTrinhs]    Script Date: 7/10/2018 3:04:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuyTrinhs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostDate] [datetime] NOT NULL,
	[Actived] [bit] NOT NULL,
	[EnTitle] [nvarchar](max) NULL,
	[EnDetail] [nvarchar](max) NULL,
	[ViTitle] [nvarchar](max) NULL,
	[ViDetail] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuyTrinhs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


