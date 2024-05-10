﻿CREATE TABLE [TOURNAMENT_TRACKER].[TournamentEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TournamentId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_TournamentEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [TOURNAMENT_TRACKER].[TournamentEntries]  WITH CHECK ADD  CONSTRAINT [FK_TournamentEntries_Teams] FOREIGN KEY([TeamId])
REFERENCES [TOURNAMENT_TRACKER].[Teams] ([Id])
GO

ALTER TABLE [TOURNAMENT_TRACKER].[TournamentEntries] CHECK CONSTRAINT [FK_TournamentEntries_Teams]
GO

ALTER TABLE [TOURNAMENT_TRACKER].[TournamentEntries]  WITH CHECK ADD  CONSTRAINT [FK_TournamentEntries_Tournaments] FOREIGN KEY([TournamentId])
REFERENCES [TOURNAMENT_TRACKER].[Tournaments] ([Id])
GO

ALTER TABLE [TOURNAMENT_TRACKER].[TournamentEntries] CHECK CONSTRAINT [FK_TournamentEntries_Tournaments]
GO

