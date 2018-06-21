CREATE TABLE [dbo].[Food2Allergy] (
    [FoodId]    INT NOT NULL,
    [AllergyId] INT NOT NULL,
    CONSTRAINT [PK_Food2Allergy] PRIMARY KEY CLUSTERED ([FoodId] ASC, [AllergyId] ASC),
    CONSTRAINT [FK_Food2Allergy_Allergy] FOREIGN KEY ([AllergyId]) REFERENCES [dbo].[Allergy] ([Id]),
    CONSTRAINT [FK_Food2Allergy_Food] FOREIGN KEY ([FoodId]) REFERENCES [dbo].[Food] ([Id])
);

