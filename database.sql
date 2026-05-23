CREATE DATABASE RENTCAROTOMASYON;
GO

USE RENTCAROTOMASYON;
GO

CREATE TABLE Table_category (
    category_ıd INT IDENTITY(1,1) PRIMARY KEY,
    category_name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Table_customer (
    customer_ıd INT IDENTITY(1,1) PRIMARY KEY,
    customer_name NVARCHAR(50) NOT NULL,
    customer_surname NVARCHAR(50) NOT NULL,
    customer_email NVARCHAR(50) NOT NULL,
    customer_telephone NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Table_car (
    car_ıd INT IDENTITY(1,1) PRIMARY KEY,
    car_name NVARCHAR(50) NOT NULL,
    car_dailyprice DECIMAL(18,0) NOT NULL,
    category_ıd INT NOT NULL,
    car_plate NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_Table_car_Table_category FOREIGN KEY (category_ıd)
        REFERENCES Table_category(category_ıd)
);
GO

CREATE TABLE Table_customercar (
    rental_ıd INT IDENTITY(1,1) PRIMARY KEY,
    customer_ıd INT NOT NULL,
    car_ıd INT NOT NULL,
    rent_date DATE NOT NULL,
    return_date DATE NOT NULL,
    total_price DECIMAL(18,0) NOT NULL,
    CONSTRAINT FK_Table_customercar_Table_customer FOREIGN KEY (customer_ıd)
        REFERENCES Table_customer(customer_ıd),
    CONSTRAINT FK_Table_customercar_Table_car FOREIGN KEY (car_ıd)
        REFERENCES Table_car(car_ıd)
);
GO

INSERT INTO Table_category (category_name)
VALUES (N'Ekonomik'), (N'SUV'), (N'Lüks');
GO
