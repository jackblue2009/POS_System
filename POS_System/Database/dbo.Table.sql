CREATE TABLE [dbo].[order_transactions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [invoice_no] INT NULL, 
    [paid_amount] FLOAT NULL, 
    [pay_method] NCHAR(10) NULL, 
    [date] DATETIME NULL
)
