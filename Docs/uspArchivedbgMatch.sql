/***********************************************************************************
Procedure	Staging.uspArchivedbgMatch
Author		Gareth Hopkins
Created		2015-12-12 

Purpose		Archives Staging.dbgMatch to Staging.dbgMatchHistory

Modified	2015-12-28	Gareth Hopkins	Initials column added
			2015-12-30	BrandKey was missing from the insert to history, making hard to pick out UUID matches
**********************************************************************************/ 
CREATE PROCEDURE Staging.uspArchivedbgMatch
										
AS

SET NOCOUNT ON; 
DECLARE 
	@Process NVARCHAR(128) = N'Staging.uspArchivedbgMatch'
	,@Message NVARCHAR(512)	
	,@ArchiveDate DATETIME2
	,@Rows INT;

SET @ArchiveDate = SYSDATETIME();

BEGIN TRY

	EXEC dbo.uspAuditAddLocalAudit @AuditType = N'Trace Start', @Process = @Process, @ProcessStep = N'Insert Staging.dbgMatchHistory', @Message = NULL, @CodeExecuted = NULL, @Rows = NULL; 	
		
	INSERT Staging.dbgMatchHistory(
		dbgMatchKey
		,dbgID
		,FeedFileKey
		,FileRowNumber
		,DTVURN
		,PersonURN
		,HouseURN
		,CompanyURN
		,EmailAddress
		,Address1
		,Postcode
		,Title
		,Surname
		,Forename
		,MobilePhoneNumber
		,HomePhoneNumber
		,DoubleMetaphoneForename
		,DoubleMetaphoneSurname
		,DoubleMetaphoneFullName
		,CustomerID
		,SystemID
		,BrandKey
		,MatchGroup
		,MatchRule
		,GenderCode
		,DateOfBirth
		,DateArchived
		,Initials)
	SELECT 
		dbgMatchKey
		,dbgID
		,FeedFileKey
		,FileRowNumber
		,DTVURN
		,PersonURN
		,HouseURN
		,CompanyURN
		,EmailAddress
		,Address1
		,Postcode
		,Title
		,Surname
		,Forename
		,MobilePhoneNumber
		,HomePhoneNumber
		,DoubleMetaphoneForename
		,DoubleMetaphoneSurname
		,DoubleMetaphoneFullName
		,CustomerID
		,SystemID
		,BrandKey
		,MatchGroup
		,MatchRule
		,GenderCode
		,DateOfBirth
		,@ArchiveDate
		,Initials
	FROM Staging.dbgMatch;

	SELECT @Rows = @@ROWCOUNT;
	EXEC dbo.uspAuditAddLocalAudit @AuditType = N'Trace End', @Process = @Process, @ProcessStep = N'Insert Staging.dbgMatchHistory', @Message = NULL, @CodeExecuted = NULL, @Rows = @Rows; 

	TRUNCATE TABLE Staging.dbgMatch;		
END TRY

BEGIN CATCH	 
	
	SET @Message = LEFT(ERROR_MESSAGE(), 512);

	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;	

	EXEC dbo.uspAuditAddLocalAudit @AuditType = N'Error', @Process = @Process, @ProcessStep = N'Insert Staging.dbgMatchHistory', @Message = @Message, @CodeExecuted = NULL, @Rows = NULL; 
	
	TRUNCATE TABLE Staging.dbgMatch;
END CATCH