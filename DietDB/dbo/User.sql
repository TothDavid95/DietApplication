CREATE TABLE [dbo].[User] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [UserName] NCHAR (50) NOT NULL,
    [Email]    NCHAR (30) NOT NULL,
    [Password] NCHAR (100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UNIQUE_User_Email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UNIQUE_User_Username] UNIQUE NONCLUSTERED ([Email] ASC)
);



