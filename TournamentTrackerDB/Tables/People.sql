﻿CREATE TABLE [TOURNAMENT_TRACKER].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](60) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TOURNAMENT_TRACKER].[People] ADD  CONSTRAINT [DF_People_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO


