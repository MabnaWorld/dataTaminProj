# Data Tamin Project

A simple RESTful API for managing books.

## Database Setup

### Create Database and Table

```sql
CREATE DATABASE [bookstore]

use bookstore;
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    PublishedYear INT NULL,
    Price DECIMAL(18, 2) NULL
);
```

### Seed Database

```sql
INSERT INTO Books (Title, Author, PublishedYear, Price) VALUES 
    ('1984', 'George Orwell', 1949, 9.99),
    ('The Art of the Good Life', 'Rolf Dobelli', 2017, 14.99),
    ('To Kill a Mockingbird', 'Harper Lee', 1960, 8.99),
    ('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 7.99),
    ('Atomic Habits', 'James Clear', 2018, 11.99),
    ('Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 2011, 12.99),
    ('The Alchemist', 'Paulo Coelho', 1988, 10.99),
    ('The Catcher in the Rye', 'J.D. Salinger', 1951, 9.49),
    ('The Subtle Art of Not Giving a F*ck', 'Mark Manson', 2016, 13.99),
    ('Pride and Prejudice', 'Jane Austen', 1813, 6.99);
```

## Stored Procedures

### Get All Books

```sql
CREATE PROCEDURE GetAllBooks_sp 
AS
BEGIN
    SELECT Id, Title, Author, PublishedYear, Price 
    FROM Books;
END
```

### Get Book by ID

```sql
CREATE PROCEDURE GetBookById_sp 
    @Id INT
AS
BEGIN
    SELECT Id, Title, Author, PublishedYear, Price 
    FROM Books 
    WHERE Id = @Id;
END
```

### Add New Book

```sql
CREATE PROCEDURE AddBook_sp 
    @Title NVARCHAR(255), 
    @Author NVARCHAR(255), 
    @PublishedYear INT = NULL, 
    @Price DECIMAL(18, 2) = NULL
AS
BEGIN
    INSERT INTO Books (Title, Author, PublishedYear, Price) 
    VALUES (@Title, @Author, @PublishedYear, @Price);
    
    SELECT SCOPE_IDENTITY() AS Id;
END
```

### Update Book 

```sql
CREATE PROCEDURE UpdateBook_sp
    @Id INT,
    @Title NVARCHAR(255),
    @Author NVARCHAR(255),
    @PublishedYear INT = NULL,
    @Price DECIMAL(10, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Books
    SET 
        Title = @Title,
        Author = @Author,
        PublishedYear = @PublishedYear,
        Price = @Price
    WHERE Id = @Id;
END;
```

### DELETE Book 

```sql
CREATE PROCEDURE DeleteBook_sp
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Books WHERE Id = @Id;
END;
```
