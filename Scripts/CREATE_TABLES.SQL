IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Candidate'))
BEGIN
	CREATE TABLE [dbo].[Candidate](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [varchar](150) NOT NULL,
		[ViceName] [varchar](150) NOT NULL,
		[RegisterDate] [datetime] NOT NULL,
		[Subtitle] [int] NOT NULL,
		CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY]
END;

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Vote'))
BEGIN
    CREATE TABLE [dbo].[Vote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VoteDate] [datetime] NOT NULL,
	[CandidateId] [int] NOT NULL,
	
	CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];

	ALTER TABLE [dbo].[Vote] WITH CHECK ADD  CONSTRAINT [FK_Vote_Candidates] FOREIGN KEY([CandidateId])
	REFERENCES [dbo].[Candidate] ([Id])
	ON DELETE CASCADE
	ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Candidates]

END;
