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

CREATE TABLE roles (
	id int NOT NULL PRIMARY KEY,
	role nvarchar(50) NOT NULL
);
GO

CREATE TABLE users (
	id int NOT NULL PRIMARY KEY,
	first_name nvarchar(max) NOT NULL,
	last_name nvarchar(max) NOT NULL,
    username nvarchar(max) NOT NULL,
	password nvarchar(max) NOT NULL,
	role_id int NOT NULL DEFAULT 2,
	email nvarchar(max) NOT NULL,
	is_verified bit NOT NULL DEFAULT 0,
	FOREIGN KEY (role_id) REFERENCES roles(id)
);
GO

CREATE TABLE images (
	id UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY,
    name nvarchar(max) NOT NULL,
	stream varbinary(max) FILESTREAM NOT NULL,
    created_date datetime NOT NULL,
	modified_date datetime NOT NULL
);
GO

CREATE TABLE events (
	id int NOT NULL PRIMARY KEY,
    title nvarchar(max) NOT NULL DEFAULT '(no title)',
	image_id UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL UNIQUE,
    date datetime NULL,
	venue nvarchar(max) NOT NULL DEFAULT '(no venue)',
	description nvarchar(max) NULL DEFAULT '(no venue)',
	venue_link nvarchar(max) NULL,
	facebook_link nvarchar(max) NOT NULL,
	user_id int NOT NULL DEFAULT 1,
	FOREIGN KEY (image_id) REFERENCES images(id),
	FOREIGN KEY (user_id) REFERENCES users(id),
);
GO

INSERT INTO [dbo].[roles] VALUES (1, N'Admin')
INSERT INTO [dbo].[roles] VALUES (2, N'User')

INSERT INTO [dbo].[users] VALUES (1, N'Admin', N'Admin', N'admin', N'password', 1, N'mpmarkgraf@gmail.com', 1)