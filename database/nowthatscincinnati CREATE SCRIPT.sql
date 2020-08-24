CREATE DATABASE nowthatscincinnati
GO
USE nowthatscincinnati
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

CREATE TABLE users (
	id int NOT NULL,
	first_name nvarchar(max) NOT NULL,
	last_name nvarchar(max) NOT NULL,
    username nvarchar(max) NOT NULL,
	password nvarchar(max) NOT NULL,
	email nvarchar(max) NOT NULL,
	is_verified bit NOT NULL DEFAULT 0,
	PRIMARY KEY (id)
);
GO

CREATE TABLE images (
	[ROWGUID] UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL UNIQUE,
	id int NOT NULL,
    name nvarchar(max) NOT NULL,
	stream varbinary(max) FILESTREAM NOT NULL,
    created_date datetime NOT NULL,
	modified_date datetime NOT NULL,
	PRIMARY KEY (id)
);
GO

CREATE TABLE events (
	id int NOT NULL,
    title nvarchar(max) NOT NULL DEFAULT '(no title)',
	image_id int NOT NULL DEFAULT 1,
    date datetime NULL,
	venue nvarchar(max) NOT NULL DEFAULT '(no venue)',
	description nvarchar(max) NULL DEFAULT '(no venue)',
	venue_link nvarchar(max) NULL,
	facebook_link nvarchar(max) NOT NULL,
	user_id int NOT NULL DEFAULT 0,
	PRIMARY KEY (id),
	FOREIGN KEY (image_id) REFERENCES images(id),
	FOREIGN KEY (user_id) REFERENCES users(id),
);
GO

