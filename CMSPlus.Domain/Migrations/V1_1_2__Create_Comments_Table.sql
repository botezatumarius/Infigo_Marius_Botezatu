CREATE TABLE [dbo].[Comments] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [FullName] NVARCHAR(255) NOT NULL, 
    [Body] NVARCHAR(MAX) NOT NULL,      
    [CreatedOnUtc] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [UpdatedOnUtc] DATETIME NULL,       
    [TopicId] INT NOT NULL,
    
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comment_Topic_TopicId] 
        FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topics] ([Id]) 
        ON DELETE CASCADE
);
GO
