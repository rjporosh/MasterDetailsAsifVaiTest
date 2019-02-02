use DbTest;
CREATE TABLE [dbo].[Categories] ( [CategoryID] INT
IDENTITY (1, 1) NOT NULL, 
[CategortyName] VARCHAR (50) NOT NULL,
 PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

CREATE TABLE [dbo].[Products](
[ProductID] INT IDENTITY (1, 1) NOT NULL, 
[CategoryID] INT NOT NULL, 
[ProductName] VARCHAR (50) NOT NULL, 
PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

CREATE TABLE [dbo].[OrderMaster]
(
[OrderID] INT IDENTITY (1, 1) NOT NULL,
 [OrderNo] VARCHAR (20) NOT NULL,
  [OrderDate] DATETIME NOT NULL,
  [Description] NVARCHAR (200) NULL,
 PRIMARY KEY CLUSTERED ([OrderID] ASC)
);

CREATE TABLE [dbo].[OrderDetails] (
[OrderDetailsId] INT IDENTITY (1, 1) NOT NULL,
[OrderID]INT NOT NULL, 
[ProductID] INT NOT NULL,
[Rate]NUMERIC (12, 2) NULL, 
[Quantity] INT NOT NULL, 
 PRIMARY KEY CLUSTERED ([OrderDetailsId] ASC),
 CONSTRAINT [FK_Order_Details_OrderMaster] 
 FOREIGN KEY ([OrderID]) REFERENCES
  [dbo].[OrderMaster] ([OrderID])
);