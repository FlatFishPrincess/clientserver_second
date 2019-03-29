CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerName] NVARCHAR(50) NULL, 
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_Orders_ToProducts] FOREIGN KEY ([ProductId]) REFERENCES [Products]([ProductId]) ON DELETE CASCADE
)
