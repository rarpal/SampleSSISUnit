CREATE TABLE [dbo].[dim_ContactTelephone]
(
	[key_Contact] INT NOT NULL , 
    [TelephoneNumber] VARCHAR(15) NULL
)

GO

CREATE INDEX [ni_dim_ContactTelephone_key_Contact] ON [dbo].[dim_ContactTelephone] ([key_Contact])
