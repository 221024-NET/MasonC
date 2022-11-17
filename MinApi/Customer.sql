ALTER TABLE Invoice DROP CONSTRAINT FK_InvoiceCustomerId;
ALTER TABLE Customer DROP CONSTRAINT PK_Customer;

DROP Table Customer;

GO
CREATE TABLE [dbo].[Customer]
(
    [CustomerId] INT NOT NULL IDENTITY(1,1),
    [FirstName] NVARCHAR(40) NOT NULL,
    [LastName] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(60) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId])
);

INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Luís', N'Gonçalves', N'luisg@embraer.com.br');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Leonie', N'Köhler', N'leonekohler@surfeu.de');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES ( N'François', N'Tremblay', N'ftremblay@gmail.com');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Bjørn', N'Hansen', N'bjorn.hansen@yahoo.no');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'František', N'Wichterlová', N'frantisekw@jetbrains.com');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Helena', N'Holý', N'hholy@gmail.com');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Astrid', N'Gruber', N'astrid.gruber@apple.at');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Daan', N'Peeters', N'daan_peeters@apple.be');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Kara', N'Nielsen', N'kara.nielsen@jubii.dk');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Eduardo', N'Martins',  N'eduardo@woodstock.com.br');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Alexandre', N'Rocha', N'alero@uol.com.br');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Roberto', N'Almeida', N'roberto.almeida@riotur.gov.br');
INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email]) VALUES (N'Fernanda', N'Ramos', N'fernadaramos4@uol.com.br');

SELECT * FROM Customer;