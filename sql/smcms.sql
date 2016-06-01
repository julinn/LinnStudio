IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name = 'smcms_class' AND type = 'u')
CREATE TABLE smcms_class(
 ID int PRIMARY KEY 
,Name varchar(30)
,PID int DEFAULT 0
)
GO

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name = 'smcms_article' AND type = 'u')
CREATE TABLE smcms_article(
 ID int IDENTITY(1,1) PRIMARY KEY 
,Title varchar(200)
,Content text
,CID int DEFAULT 1
,UserID varchar(20)
,FDate datetime DEFAULT getdate()
)
GO

IF NOT EXISTS(SELECT 1 FROM sysobjects WHERE name = 'smcms_admin' AND type = 'u')
CREATE TABLE smcms_admin(
 UserID varchar(20)
,UserName varchar(20)
,Passwd varchar(50)
,LevID int DEFAULT 0
)
GO

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'proc_smcms_class_Edit' AND type = 'p')
  DROP PROC proc_smcms_class_Edit
GO
CREATE PROC proc_smcms_class_Edit
 @ID int 
,@Name varchar(30)
,@PID int = 0
AS
BEGIN
  IF @ID = 0
    SELECT @ID = MAX(ID)+1 FROM smcms_class 	
  IF EXISTS (SELECT  1 FROM smcms_class WHERE ID = @ID)
    UPDATE smcms_class SET Name = @Name, PID = @PID WHERE ID = @ID 
  ELSE 
  	INSERT INTO smcms_class (ID, Name, PID) VALUES(@ID, @Name, @PID)
END
GO

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'proc_smcms_Delete' AND type = 'p')
  DROP PROC proc_smcms_Delete
GO
CREATE PROC proc_smcms_Delete
 @Table varchar(20)
,@ID varchar(20)
AS
BEGIN
  IF @Table = 'class'
    DELETE FROM smcms_class WHERE ID = @ID 
  IF @Table = 'article'
    DELETE FROM smcms_article WHERE ID = @ID 	
  IF @Table = 'admin'
    DELETE FROM smcms_admin WHERE UserID = @ID 
END
GO

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'proc_smcms_article_Edit' AND type = 'p')
  DROP PROC proc_smcms_article_Edit
GO
CREATE PROC proc_smcms_article_Edit
 @ID int 
,@Title varchar(200)
,@Content text
,@CID int = 1
,@UserID varchar(20) = ''
AS
BEGIN
  IF @ID = 0
    INSERT INTO smcms_article(CID, Title, Content, UserID)VALUES(@CID, @Title, @Content, @UserID)
  ELSE 
  	UPDATE smcms_article SET CID = @CID, Title = @Title, Content = @Content WHERE ID = @ID 	
END
GO

IF EXISTS(SELECT 1 FROM sysobjects WHERE name = 'proc_smcms_admin_Edit' AND type = 'p')
  DROP PROC proc_smcms_admin_Edit
GO
CREATE PROC proc_smcms_admin_Edit
 @UserID varchar(20)
,@UserName varchar(20)
,@Passwd varchar(50)
,@LevID int = 0
AS
BEGIN
  IF @UserID = 'admin'
    SET @LevID = 9
  IF EXISTS (SELECT 1 FROM smcms_admin WHERE UserID = @UserID )	
    UPDATE smcms_admin SET UserName = @UserName , Passwd = @Passwd , LevID = @LevID WHERE UserID = @UserID 
  ELSE 
  	INSERT INTO smcms_admin(UserID, UserName, Passwd, LevID)VALUES(@UserID , @UserName , @Passwd, @LevID)
END
GO

-- 初始化
IF NOT EXISTS (SELECT 1 FROM smcms_class)
  INSERT INTO smcms_class(ID, Name)VALUES(1, '默认分类')
GO
IF NOT EXISTS(SELECT 1 FROM smcms_admin WHERE UserID = 'admin')
  INSERT INTO smcms_admin(UserID, UserName, Passwd, LevID) VALUES ('admin', 'admin', '21232F297A57A5A743894A0E4A801FC3', 9)
GO