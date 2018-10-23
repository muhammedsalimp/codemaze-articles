CREATE DATABASE BookStore

GO

USE BookStore

GO

CREATE TABLE Author(
	Id bigint IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
    PRIMARY KEY (Id)
)

GO

CREATE TABLE dbo.AuthorContact(
	AuthorId bigint NOT NULL,
	ContactNumber nvarchar(15) NULL,
	Address nvarchar(100) NULL, 
	PRIMARY KEY (AuthorId),
	FOREIGN KEY (AuthorId) REFERENCES Author(Id)
)

GO

CREATE TABLE dbo.BookCategory(
	Id bigint IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	PRIMARY KEY (Id)
)

GO

CREATE TABLE dbo.Publisher(
	Id bigint IDENTITY(1,1) NOT NULL,
	Name nvarchar(100) NOT NULL, 
	PRIMARY KEY (Id)
)

GO

CREATE TABLE Book(
	Id bigint IDENTITY(1,1) NOT NULL,
	Title nvarchar(100) NOT NULL,
	CategoryId bigint NOT NULL,
	PublisherId bigint NOT NULL,
	PRIMARY KEY (Id),
    FOREIGN KEY (CategoryId) REFERENCES BookCategory(Id),
	FOREIGN KEY (PublisherId) REFERENCES Publisher(Id)
)

GO

CREATE TABLE BookAuthors(
	BookId bigint NOT NULL,
	AuthorId bigint NOT NULL
	PRIMARY KEY (BookId, AuthorId),
    FOREIGN KEY (BookId) REFERENCES Book(Id),
	FOREIGN KEY (AuthorId) REFERENCES Author(Id)
)


