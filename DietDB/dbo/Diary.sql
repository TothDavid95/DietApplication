CREATE TABLE [dbo].[Diary] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FoodId]       INT            NOT NULL,
    [Amount_g]     DECIMAL (8, 2) NOT NULL,
    [TimeOfMealId] INT            NOT NULL,
    [UserId]       INT            NOT NULL,
    CONSTRAINT [PK_Diary] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Diary_Food] FOREIGN KEY ([FoodId]) REFERENCES [dbo].[Food] ([Id]),
    CONSTRAINT [FK_Diary_TimeOfMeal] FOREIGN KEY ([TimeOfMealId]) REFERENCES [dbo].[TimeOfMeal] ([Id]),
    CONSTRAINT [FK_Diary_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



