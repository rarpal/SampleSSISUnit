CREATE TABLE [dbo].[dim_Contacts]
(
	[key_Contact] INT NOT NULL IDENTITY , 
	[id_Number] INT NOT NULL,
    [Name] VARCHAR(60) NOT NULL, 
    [Address] VARCHAR(200) NOT NULL, 
    [AddressDate] DATE NOT NULL, 
    [is_Current] BIT NULL, 
    CONSTRAINT [pk_dim_Contacts] PRIMARY KEY NONCLUSTERED ([key_Contact])
)

GO

CREATE CLUSTERED INDEX [ni_dim_Contacts_id_Number] ON [dbo].[dim_Contacts] ([id_Number])
