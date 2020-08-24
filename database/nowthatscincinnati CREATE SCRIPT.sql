USE nowthatscincinnati

CREATE TABLE events (
	id int NOT NULL,
    title nvarchar(max) NOT NULL DEFAULT '(no title)',
	image_id int NOT NULL DEFAULT 1,
    [date] datetime NULL,
	venue nvarchar(max) NOT NULL DEFAULT '(no venue)',
	[description] nvarchar(max) NULL DEFAULT '(no venue)',
	venue_link nvarchar(max) NULL,
	facebook_link nvarchar(max) NOT NULL,
	PRIMARY KEY (id)
);
GO

ALTER DATABASE nowthatscincinnati
ADD FILEGROUP fs_fg_filestream CONTAINS FILESTREAM  
GO  
ALTER DATABASE nowthatscincinnati
ADD FILE  
(  
    NAME= 'filestream',  
    FILENAME = 'C:\Workspace\Portfolio\nowthatscincinnati\database\filestream'
)  
TO FILEGROUP fs_fg_filestream  
GO
ALTER DATABASE nowthatscincinnati  
   SET FILESTREAM ( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'FileStreamDirectory' )  

CREATE TABLE images AS FileTable;

