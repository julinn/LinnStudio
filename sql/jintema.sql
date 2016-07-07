-- MD5¼ÓÃÜ
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'func_GetMD5String' AND type = 'FN')
  DROP FUNCTION func_GetMD5String
GO
CREATE FUNCTION func_GetMD5String
(@str varchar(max))
RETURNS varchar(50)
BEGIN
  RETURN UPPER(substring(sys.fn_VarBinToHexStr(hashbytes('MD5',@str)), 3, 32))	
END
GO

IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'proc_GetMD5String' AND type = 'P')
  DROP PROC proc_GetMD5String
GO
CREATE PROC proc_GetMD5String
 @str varchar(max)
,@md5 varchar(50) out
AS
BEGIN
  SET @md5 = UPPER(substring(sys.fn_VarBinToHexStr(hashbytes('MD5',@str)), 3, 32))	
END
GO

-- ¼¤»îÂë
IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'proc_GetRegCode' AND type = 'P')
  DROP PROC proc_GetRegCode
GO
CREATE PROC proc_GetRegCode
 @code varchar(100) out 
AS 
BEGIN
  DECLARE @s1 varchar(50), @s2 varchar(50), @s3 varchar(100)
  SET @s1 = replace(NEWID(), '-', '')
  SET @s2 = CONVERT(varchar(19), getdate(), 121) 
  SET @s2 = replace(replace(@s2, '-', ''), ':', '')
  SET @s2 = dbo.func_GetMD5String(@s2)	
  SET @s3 = dbo.func_GetMD5String(@s1+@s2)
  SET @code = @s3+@s1+@s2
END
GO

-- ×¢²áÂë±í
IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name = 'jtm_Codes' AND type = 'U')
CREATE TABLE jtm_Codes
(
	ID int IDENTITY(1,1),
	Code varchar(100) NOT NULL PRIMARY KEY,
	CID int DEFAULT 1,
	CreateDate datetime DEFAULT getdate(),
	UseDate datetime, 
	UseID varchar(100),
	BuyID varchar(100),
	Valid tinyint DEFAULT 1
)
GO
