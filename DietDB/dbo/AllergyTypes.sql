CREATE TABLE [dbo].[AllergyTypes] (
    [Id]                INT NOT NULL,
    [Gluten]            BIT NOT NULL,
    [Soy]               BIT NOT NULL,
    [Milk]              BIT NOT NULL,
    [MilkSugar]         BIT NOT NULL,
    [InsulinResistance] BIT NOT NULL,
    CONSTRAINT [PK_AllergyTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AllergyTypes_unique] UNIQUE NONCLUSTERED ([Gluten] ASC, [InsulinResistance] ASC, [Milk] ASC, [MilkSugar] ASC, [Soy] ASC)
);

