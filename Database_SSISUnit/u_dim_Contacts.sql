CREATE TABLE [dbo].[dim_Contacts]
(
	[key_Contact] INT NOT NULL IDENTITY , 
	[id_Number] INT NOT NULL,
    [Name] VARCHAR(60) NOT NULL,
	[Telephone] VARCHAR(60) NULL,
    [Address] VARCHAR(200) NOT NULL, 
    [AddressDate] DATE NOT NULL, 
    CONSTRAINT [pk_dim_Contacts] PRIMARY KEY NONCLUSTERED ([key_Contact])
)

GO

CREATE CLUSTERED INDEX [ni_dim_Contacts_id_Number] ON [dbo].[dim_Contacts] ([id_Number])
