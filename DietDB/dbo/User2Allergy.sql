CREATE TABLE [dbo].[User2Allergy] (
    [UserId]    INT NOT NULL,
    [AllergyId] INT NOT NULL,
    CONSTRAINT [PK_User2Allergy] PRIMARY KEY CLUSTERED ([UserId] ASC, [AllergyId] ASC),
    CONSTRAINT [FK_User2Allergy_Allergy] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergy] ([Id]),
    CONSTRAINT [FK_User2Allergy_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

