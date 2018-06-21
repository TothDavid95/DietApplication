CREATE TABLE [dbo].[Food] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NCHAR (40)     NOT NULL,
    [Energy_kJ]      INT            NOT NULL,
    [Energy_kcal]    INT            NOT NULL,
    [Protein_g]      INT NOT NULL,
    [Fat_g]          INT NOT NULL,
    [Carbohydrate_g] INT NOT NULL,
    [Sodium_mg]      INT NOT NULL,
    [Potassium_mg]   INT NOT NULL,
    [Calcium_mg]     INT NOT NULL,
    [Magnesium_mg]   INT NOT NULL,
    CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED ([Id] ASC)
);



