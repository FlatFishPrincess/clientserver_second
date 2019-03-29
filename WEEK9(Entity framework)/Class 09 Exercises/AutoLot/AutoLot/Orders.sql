CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustId] INT NOT NULL, 
    [CarId] INT NOT NULL,
	CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY ([CarId]) REFERENCES [Inventory]([CarId]) on delete cascade,
	CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustId]) REFERENCES [Customers]([CustId]) on delete cascade
)
